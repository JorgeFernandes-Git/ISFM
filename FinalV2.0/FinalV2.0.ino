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
int actinc = 0 ;
double vector = 0.00;
double alphaRAD = 0.00;
int DeltaS = 1; //incrementos de 1 mm
int PrevPosY[500];// =  realPosY + i * DeltaS * cos(alphaRAD);
int PrevPosZ[500];// =  realPosZ + i * DeltaS * sin(alphaRAD);
int FINALPOSY[500];// =  realPosY + i * DeltaS * cos(alphaRAD);
int FINALPOSZ[500];// =  realPosZ + i * DeltaS * sin(alphaRAD);

//braço RR plano
const int L1 = 120;
const int L2 = 200;
double theta1 = 0;
double theta2 = 0;
long coordY = 0;
long coordZ = 0;

//flags
bool datareceived = false;
bool moveArm = false;
bool HomingRotine = false;
bool ManualJog = false;

//iniciar as funçoes
void msgIn();
void CinInv(long coordY_CI, long coordZ_CI);
void moveYZ(long pos1, long pos2);
void Homing();
void HardLimitsFault();
void ManJog();
void IncPos();


void setup() {
  Serial.begin(9600); //iniciar o monitor serial

  pinMode(LSwitchY, INPUT_PULLUP);
  pinMode(LSwitchZ, INPUT_PULLUP);
  attachInterrupt(digitalPinToInterrupt(LSwitchY), HardLimitsFault, FALLING);
  attachInterrupt(digitalPinToInterrupt(LSwitchZ), HardLimitsFault, FALLING);
  pinMode(Ena, OUTPUT); //defenir pino como output
  digitalWrite(Ena, HIGH); //começar com o motor desligado

  //iniciar velocidade máxima e aceleração
  Xaxis.setMaxSpeed(1000.0);
  Xaxis.setAcceleration(1000.0);

  Yaxis.setMaxSpeed(100.0);
  Yaxis.setAcceleration(1000.0);

  Zaxis.setMaxSpeed(100.0);
  Zaxis.setAcceleration(1000.0);

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

    } else if (ManualJog == false) {
      //ler dados e atribuir a strings

      //atribuir coordenadas lidas
      int index = msg_IN.indexOf(" "); //localizar o espaço
      coordY = atol(msg_IN.substring(0, index).c_str());
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido

      index = msg_IN.indexOf(" "); //localizar o espaço
      coordZ = atol(msg_IN.substring(0, index).c_str());

      //strposY = msg_IN.readStringUntil(" ")//(msg_IN.substring(0, 4));
      //coordY = strposY.toInt();

      //strposZ = (msg_IN.substring(5, 7));
      //coordZ = strposZ.toInt();


      //------------------------------------------------------VARIAVEIS DE POSICIONAMENTO INCREMENTAL
      float zz = coordZ - realPosZ;
      float yy = coordY - realPosY;
      //Serial.println(zz);
      //Serial.println(yy);
      vector = sqrt((pow(coordY - realPosY, 2)) + (pow(coordZ - realPosZ, 2))); //comprimento do vector deslocamento
      //Serial.println(vector);

      alphaRAD = atan((zz) / (yy)); //angulo do vetor deslocamento
      //Serial.println(alphaRAD);
      //double alphaDEG = alphaRAD * (180 / PI);

      inc = vector / DeltaS; //número de incrementos
      //Serial.println(inc);


      //ARRAY DE POSIÇÕES INTERMÉDIAS
      for (int i = 0; i <= inc + 1; i++) {
        PrevPosY[i] =  realPosY + (i * DeltaS * cos(alphaRAD));
        PrevPosZ[i] =  realPosZ + (i * DeltaS * sin(alphaRAD));
        //Serial.println(PrevPosY[i]);
        //Serial.println(PrevPosZ[i]);
        CinInv(PrevPosY[i], PrevPosZ[i]);
        FINALPOSY[i] = finalposYZ[0];
        FINALPOSZ[i] = finalposYZ[1];
        Serial.println(FINALPOSY[i]);
        Serial.println(FINALPOSZ[i]);
      }

      //debug
      //Serial.println("Position Y and Z:");
      //Serial.println(coordY);
      //Serial.println(coordZ);


      //apagar dados de entrada
      msg_IN = "";
      digitalWrite(Ena, LOW); //LIGAR MOTOR
      datareceived = true;
      return coordY;
      return coordZ;

    }
  }

}

void CinInv (long coordY_CI, long coordZ_CI) {



  theta2 = -acos((((pow(120 - coordY_CI, 2)) + (pow(200 - coordZ_CI, 2)) - (pow(L1, 2)) - (pow(L2, 2)))) / (48000)); //48000 = 2*L1*L2
  //Serial.println(2 * L1 * L2); ???????


  theta1 = atan(((200 - coordZ_CI) * (L1 + (L2 * cos(theta2))) - (120 - coordY_CI) * (L2 * sin(theta2))) / ((120 - coordY_CI) * (L1 + (L2 * cos(theta2))) + (200 - coordZ_CI) * (L2 * sin(theta2))));

  /*Serial.println("theta1 e theta2 em RAD");
  Serial.println(theta2);
  Serial.println(theta1);*/

  //converter para DEG
  theta1 = theta1 * (180 / PI);
  theta2 = theta2 * (180 / PI);

  /*Serial.println("theta1 e theta2 em DEG");
  Serial.println(theta2);
  Serial.println(theta1);*/

  //determinar pulsos a ser executados pelo motor
  finalposYZ[0] = theta2 * 55.5555555; // 55.555555 = 100 * PulPerRev/360 conversão para pulsos com redutora de 100:1
  finalposYZ[1] = theta1 * 55.5555555; // 100 * (PulPerRev/360);

  posTomoveY = coordY_CI;
  posTomoveZ = coordZ_CI;


  /*if (posTomoveY != realPosY) {
    moveArm = true;
    }
    if (posTomoveZ != realPosZ) {
    moveArm = true;
    }*/



  //Serial.println("Motor pulses:");
  /*Serial.println(finalposYZ[0]);
  Serial.println(finalposYZ[1]);
  //moveYZ(finalposYZ[0], finalposYZ[1]);*/
  return finalposYZ[0];
  return finalposYZ[1];

}

void moveYZ(long pos1, long pos2) {

  if ( moveArm == true) {

    Xaxis.setMaxSpeed(1000.0);

    Yaxis.setMaxSpeed(200.0);

    Zaxis.setMaxSpeed(200.0);

    finalposYZ[0] = pos1;
    finalposYZ[1] = pos2;

    eixoYZ.moveTo(finalposYZ);
    eixoYZ.runSpeedToPosition();

    realPosY = posTomoveY;
    realPosZ = posTomoveZ;

    moveArm = false;

    //Serial.println("Actual position:");
    //Serial.println(realPosY);
    //Serial.println(realPosZ);
    delay(100);
    //Serial.println("Actual position:");

    Serial.print("PosY");
    Serial.println(realPosY);

    delay(100);
    Serial.print("PosZ");
    Serial.println(realPosZ);

  } else {
    //digitalWrite(Ena, HIGH); //começar com o motor desligado
  }
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
      Zaxis.setMaxSpeed(50.0);
      Zaxis.moveTo(homeZ);
      homeZ++;
      Zaxis.run();
    }
    delay(500);
    while (digitalRead(LSwitchZ) == 0) {

      Zaxis.setMaxSpeed(20.0);
      homeZ = 1;
      Zaxis.moveTo(homeZ);
      homeZ--;
      Zaxis.run();
    }
    Serial.println("Zhome");
    //------------------------------------------------Y Homing
    while (digitalRead(LSwitchY) == 1) {
      Yaxis.setMaxSpeed(50.0);
      Yaxis.moveTo(homeY);
      homeY--;
      Yaxis.run();
    }
    delay(500); //tempo de espera antes de inverter a rotação
    while (digitalRead(LSwitchY) == 0) {
      Yaxis.setMaxSpeed(20.0);
      homeY = 1;
      Yaxis.moveTo(homeY);
      homeY++;
      Yaxis.run();
    }
    Serial.println("Yhome");

    //------------------------------------------------atualizar posição
    realPosY =  -107;
    realPosZ = 68;

    HomingRotine = false;

    finalposYZ[0] = -4019;
    finalposYZ[1] = 4261;

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

  if (moveArm == true) {
    moveArm = false;
    datareceived = false;
    Yaxis.stop();
    Zaxis.stop();
    Xaxis.stop();
    Serial.println("FAULT");
  }

}


void ManJog() {

  if (ManualJog == true) {

  }
}

void IncPos() {

  if (datareceived == true) {
    moveArm = true;
    for (int i = 0; i <= inc + 1; i++) {
      moveYZ(FINALPOSY[i], FINALPOSZ[i]);
    }
    moveArm = false;
    datareceived = false;
  }

}

void loop() {

  msgIn();
  IncPos();
  Homing();
  ManJog();

}
