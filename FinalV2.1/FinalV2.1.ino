#include <AccelStepper.h>
#include <MultiStepper.h>
#include <math.h>

//pinos motores
#define PulY 2 //pino pulso Y
#define DirY 3 //pino direção Y
#define PulZ 4 //pino pulso Z
#define DirZ 5 //pino direção Z
#define PulX 6 //pino pulso X
#define DirX 7 //pino direção X
#define Ena 8 //pino enable para X, Y, Z

//pinos fins de curso - pinos com hardware interrupt
#define LSwitchY 19 //fim de curso real ligado gnd NC
#define LSwitchZ 18 //botao ligado ao gnd

//objetos stepper motor
AccelStepper Yaxis(1, PulY, DirY);
AccelStepper Zaxis(1, PulZ, DirZ);
AccelStepper Xaxis(1, PulX, DirX);

//objecto multistep para controlo conjunto de eixos
MultiStepper eixoYZ;

//configuração dos drivers
const int PulPerRev = 200;

//variaveis
String msg_IN, strposX , strposY, strposZ;
long finalposYZ[2]; //array de movimentos YZ

//posicionamento
int realPosX = 0;
int realPosY = 0;
int realPosZ = 0;
int posTomoveX = 0;
int posTomoveY = 0;
int posTomoveZ = 0;
int inc = 0;
float vector = 0.00;
float alphaRAD = 0.00;
double DeltaS = 0.20; //incrementos de 1 mm
float PrevPosY;// =  realPosY + i * DeltaS * cos(alphaRAD);
float PrevPosZ;// =  realPosZ + i * DeltaS * sin(alphaRAD);
int FINALPOSY[900];
int FINALPOSZ[900];

//braço RR plano
const int L1 = 120;
const int L2 = 200;
float theta1 = 0;
float theta2 = 0;
int coordY = 0;
int coordZ = 0;

//ACC DCC aceleração desaceleração
//float acc = 500;
int vel = 500;
//int contPul[500]; //array com quantidade de delays entre pulsos

//flags
bool datareceived = false;
bool moveArm = false;
bool HomingRotine = false;
bool ManualJog = false;
//bool freemove = true;
//bool straitline = false;

//iniciar as funçoes
void msgIn();
void CinInv(long coordY_CI, long coordZ_CI);
void Homing();
void HardLimitsFault();
void IncPos();
void CalcPos();


void setup() {
  Serial.begin(9600); //iniciar o monitor serial

  pinMode(LSwitchY, INPUT_PULLUP);
  pinMode(LSwitchZ, INPUT_PULLUP);
  attachInterrupt(digitalPinToInterrupt(LSwitchY), HardLimitsFault, FALLING);
  attachInterrupt(digitalPinToInterrupt(LSwitchZ), HardLimitsFault, FALLING);
  pinMode(Ena, OUTPUT); //defenir pino como output
  digitalWrite(Ena, HIGH); //começar com o motor desligado

  //iniciar velocidade máxima e aceleração
  Xaxis.setMaxSpeed(100.0);
  Xaxis.setAcceleration(100.0);

  Yaxis.setMaxSpeed(5000.0);
  Yaxis.setAcceleration(500.0);

  Zaxis.setMaxSpeed(5000.0);
  Zaxis.setAcceleration(500.0);

  eixoYZ.addStepper(Yaxis); // finalposYZ[0]
  eixoYZ.addStepper(Zaxis); // finalposYZ[1]
}

void msgIn() {

  while (Serial.available()) {
    delay(3);  //sem este delay não preenche corretamente a string
    if (Serial.available() > 0) {
      char c = Serial.read();  //gets one byte from serial buffer
      msg_IN += c; //makes the string msg_IN
    }
  }

  if (msg_IN.length() > 0) {
    // Serial.println("Recived message:");
    //Serial.println(msg_IN); //debug

    if (msg_IN == "H") {
      HomingRotine = true;
      msg_IN = "";

    } else if (msg_IN == "ENA") {
      digitalWrite(Ena, LOW); // ligar motores
      msg_IN = "";

    } else if (msg_IN == "DIS") {
      digitalWrite(Ena, HIGH); // ligar motores
      msg_IN = "";

    } else if (msg_IN == "M+") {
      ManualJog = true;
      msg_IN = "";

    } else if (msg_IN == "M-") {
      ManualJog = false;
      msg_IN = "";

    } else if (msg_IN.startsWith("V")) {
      vel = atol(msg_IN.substring(1).c_str());
      msg_IN = "";
      Serial.print("VEL");
      Serial.println(vel);

    } else if (ManualJog == false) {
      //ler dados e atribuir a strings

      //atribuir coordenadas lidas
      int index = msg_IN.indexOf(" "); //localizar o espaço
      coordY = atol(msg_IN.substring(0, index).c_str());
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido

      index = msg_IN.indexOf(" "); //localizar o espaço
      coordZ = atol(msg_IN.substring(0, index).c_str());

      //debug
      //Serial.println("Position Y and Z:");
      //Serial.println(coordY);
      //Serial.println(coordZ);

      //chamar função
      CalcPos();

      //apagar dados de entrada
      msg_IN = "";
      //digitalWrite(Ena, LOW); //LIGAR MOTOR
      datareceived = true;
      return coordY;
      return coordZ;
    }
  }

}

void CalcPos() {
  //------------------------------------------------------VARIAVEIS DE POSICIONAMENTO INCREMENTAL
  float zz = coordZ - realPosZ; // ZF - Z0
  float yy = coordY - realPosY; //YF - Y0
  //Serial.println(zz);
  //Serial.println(yy);

  vector = sqrt((pow(coordY - realPosY, 2)) + (pow(coordZ - realPosZ, 2))); //comprimento do vector deslocamento
  //Serial.println(vector);

  //ALTERAR ANGULO CONFORME EM AVNAÇO OU RECUO
  if (coordY > realPosY) {
    alphaRAD = atan((zz) / (yy)); //angulo do vetor deslocamento
  } else {
    alphaRAD = atan((zz) / (yy)) + PI; //angulo do vetor deslocamento + PI
  }
  //double alphaDEG = alphaRAD * (180 / PI);
  //Serial.println(alphaRAD);

  inc = round(vector / DeltaS); //número de incrementos
  //Serial.println(inc);

  memset(FINALPOSY, 0, inc);
  memset(FINALPOSZ, 0, inc);

  //ARRAY DE POSIÇÕES INTERMÉDIAS
  for (int i = 0; i <= (inc); i++) {
    PrevPosY =  realPosY + (i * DeltaS * cos(alphaRAD)); //NOVA POSIÇÃO Y
    PrevPosZ =  realPosZ + (i * DeltaS * sin(alphaRAD)); //NOVA POSIÇÃO Z
    //Serial.println(PrevPosY);
    //Serial.println(PrevPosZ);
    CinInv(PrevPosY, PrevPosZ); //CALCULO DA CIN INV
    FINALPOSY[i] = finalposYZ[0]; //VALOR DEVOLVIDO EM PUL
    FINALPOSZ[i] = finalposYZ[1]; //VALOR DEVOLVIDO EM PUL
    //Serial.println(FINALPOSY[i]);
    //Serial.println(FINALPOSZ[i]);
  }
}

void CinInv (float coordY_CI, float coordZ_CI) {
  theta2 = -acos((((pow(120 - coordY_CI, 2)) + (pow(200 - coordZ_CI, 2)) - (pow(L1, 2)) - (pow(L2, 2)))) / (48000)); //48000 = 2*L1*L2
  //Serial.println(2 * L1 * L2); ???????


  //theta1 = atan(((200 - coordZ_CI) * (L1 + (L2 * cos(theta2))) - (120 - coordY_CI) * (L2 * sin(theta2))) / ((120 - coordY_CI) * (L1 + (L2 * cos(theta2))) + (200 - coordZ_CI) * (L2 * sin(theta2))));

  float posz = 200 - coordZ_CI;
  float posy = 120 - coordY_CI;
  float poszz = L2 * sin(theta2);
  float posyy = L1 + 200 * cos(theta2);
  theta1 = atan((posz) / (posy)) + atan((poszz) / (posyy));
  //Serial.println("theta1 e theta2 em RAD");
  //Serial.println(theta2);
  //Serial.println(theta1);

  //converter para DEG
  theta1 = theta1 * (180 / PI);
  theta2 = theta2 * (180 / PI);

  /*Serial.println("theta1 e theta2 em DEG");
    Serial.println(theta2);
    Serial.println(theta1);*/

  //determinar pulsos a ser executados pelo motor
  finalposYZ[0] = round(theta2 * 55.5555555); // 55.555555 = 100 * PulPerRev/360 conversão para pulsos com redutora de 100:1
  finalposYZ[1] = round(theta1 * 55.5555555); // 100 * (PulPerRev/360);

  posTomoveY = coordY_CI;
  posTomoveZ = coordZ_CI;



  //Serial.println("Motor pulses:");
  //Serial.println(finalposYZ[0]);
  //Serial.println(finalposYZ[1]);
  //moveYZ(finalposYZ[0], finalposYZ[1]);*/
  return finalposYZ[0];
  return finalposYZ[1];

}

void Homing() {

  if (HomingRotine == true) {

    Yaxis.setCurrentPosition(0);
    Zaxis.setCurrentPosition(0);
    int homeY = 0;
    int homeZ = 0;

    digitalWrite(Ena, LOW); //LIGAR MOTOR

    //------------------------------------------------Z Homing
    while (digitalRead(LSwitchZ) == 1) {
      Zaxis.setMaxSpeed(200.0);
      Zaxis.moveTo(homeZ);
      homeZ--;
      Zaxis.run();
    }
    delay(500);
    while (digitalRead(LSwitchZ) == 0) {
      Zaxis.setMaxSpeed(20.0);
      homeZ = 1;
      Zaxis.moveTo(homeZ);
      homeZ++;
      Zaxis.run();
    }
    Serial.println("Zhome");
    //------------------------------------------------Y Homing
    while (digitalRead(LSwitchY) == 1) {
      Yaxis.setMaxSpeed(200.0);
      Yaxis.moveTo(homeY);
      homeY++;
      Yaxis.run();
    }
    delay(500); //tempo de espera antes de inverter a rotação
    while (digitalRead(LSwitchY) == 0) {
      Yaxis.setMaxSpeed(20.0);
      homeY = 1;
      Yaxis.moveTo(homeY);
      homeY--;
      Yaxis.run();
    }
    Serial.println("Yhome");

    //------------------------------------------------atualizar posição
    realPosY =  -107;
    realPosZ = 68;

    HomingRotine = false;

    finalposYZ[0] = -4001;
    finalposYZ[1] = -886;

    Yaxis.setCurrentPosition(finalposYZ[0]);
    Zaxis.setCurrentPosition(finalposYZ[1]);

    delay(100);
    Serial.println("HOMING COMPLETE");

    delay(100);
    //Serial.println("Actual position:");
    Serial.print("PosY");
    Serial.println(realPosY);

    delay(100);
    Serial.print("PosZ");
    Serial.println(realPosZ);

  }
}

void HardLimitsFault() {

  if (datareceived == true && HomingRotine == false) {
    moveArm = false;
    datareceived = false;
    digitalWrite(Ena, HIGH); //começar com o motor desligado
    Yaxis.stop();
    Zaxis.stop();
    Xaxis.stop();
    Serial.println("FAULT");
  }



}

void IncPos() {

  if (datareceived == true) {


    //mover em linha recta
    Yaxis.setCurrentPosition(FINALPOSY[0]);
    Zaxis.setCurrentPosition(FINALPOSZ[0]);
    Yaxis.setMaxSpeed(vel);
    Zaxis.setMaxSpeed(vel);
    moveArm = true;

    if (FINALPOSY[inc] != Yaxis.currentPosition()) {
      for (int i = 1; i <= (inc); i++) {

        finalposYZ[0] = FINALPOSY[i];
        finalposYZ[1] = FINALPOSZ[i];
        eixoYZ.moveTo(finalposYZ);
        eixoYZ.runSpeedToPosition();
        //Serial.println(FINALPOSY[i]);
        //Serial.println(i);
        // Serial.println(FINALPOSZ[i]);


      }
      FINALPOSY[0] = FINALPOSY[inc];
      FINALPOSZ[0] = FINALPOSZ[inc];


      realPosY = coordY;
      realPosZ = coordZ;
    }

    /*if (freemove == true); {

      Yaxis.setMaxSpeed(vel);
      Yaxis.setAcceleration(acc);

      Zaxis.setMaxSpeed(vel);
      Zaxis.setAcceleration(acc);

      Yaxis.moveTo(2000);
      Yaxis.run();

      Zaxis.moveTo(2000);
      Zaxis.run();
      }*/

    datareceived = false;
    moveArm = false;


    delay(100);
    Serial.print("PosY");
    Serial.println(realPosY);

    delay(100);
    Serial.print("PosZ");
    Serial.println(realPosZ);

    delay(100);
    Serial.print("VET");
    Serial.println(vector);

    //Serial.println(realPosY);
    //Serial.println(realPosZ);
  }
}

void loop() {

  msgIn();
  IncPos();
  Homing();

}
