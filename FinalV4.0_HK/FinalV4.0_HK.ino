//bibliotecas
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

//pinos fim de curso - pinos com hardware interrupt
#define LSwitchY 18 //fim de curso ligado em NC com pull down
#define LSwitchZ 19 //fim de curso ligado em NC com pull down
#define LSwitchX 20 //fim de curso ligado em NC com pull down

//objetos dos motores
AccelStepper Yaxis(1, PulY, DirY); //motor Y
AccelStepper Zaxis(1, PulZ, DirZ); //motor Z
AccelStepper Xaxis(1, PulX, DirX); //motor X

//objeto para controlo conjunto
MultiStepper SYNCMovXYZ;

//configuração dos drivers
int PulPerRev = 200;

//variaveis
String msg_IN;
long finalposXYZ[3]; //array de movimentos XYZ

//posicionamento
int realPosX = 0;
int realPosY = 0;
int realPosZ = 0;
int posTomoveX = 0;
int posTomoveY = 0;
int posTomoveZ = 0;
int inc = 0;
double vector = 0.00;
double alphaRAD = 0.00;
double DeltaS = 0.35; //incrementos de 0.35 mm (menor excede a memoria)
double DeltaS_X = 0.0;
double PrevPosY; // =  realPosY + i * DeltaS * cos(alphaRAD);
double PrevPosZ; // =  realPosZ + i * DeltaS * sin(alphaRAD);
double PrevPosX;
short FINALPOSY[700];
short FINALPOSZ[700];
short FINALPOSX[700];

//multiplas posições
int YP1, YP2, YP3, YP4, YP5, YP6, YP7, YP8;
int ZP1, ZP2, ZP3, ZP4, ZP5, ZP6, ZP7, ZP8;
int XP1, XP2, XP3, XP4, XP5, XP6, XP7, XP8;

//braço RR plano
int L1 = 120;
int L2 = 200;
double theta1 = 0;
double theta2 = 0;
int coordY = 0;
int coordZ = 0;
int coordX = 0;

//ACC DCC aceleração desaceleração
double acc = 50000; //DELAYMICROSECONDS MAX entre pulsos
int MINdelay = 20; //DELAYMICROSECONDS min entre pulsos
int vel = 500; //STEPS PER SECOND
double contPul[360]; //array com quantidade de delays entre pulsos

//flags
bool DataReceived = false;
bool MoveArm = false;
bool HomingRotine = false;
bool WithACCDCC = false;

//iniciar as funçoes
void msgIn();
void CinInv(long coordY_CI, long coordZ_CI);
void Homing();
void HardLimitsFault();
void IncPos();
void CalcPos();
void Move();


void setup() {
  //iniciar o monitor serial
  Serial.begin(9600);

  //iniciar os pinos dos fins de curso como entradas
  pinMode(LSwitchY, INPUT);
  pinMode(LSwitchZ, INPUT);
  pinMode(LSwitchX, INPUT);

  //hardware interrupts (pino, função, modo)
  attachInterrupt(digitalPinToInterrupt(LSwitchY), HardLimitsFault, FALLING);
  attachInterrupt(digitalPinToInterrupt(LSwitchZ), HardLimitsFault, FALLING);
  attachInterrupt(digitalPinToInterrupt(LSwitchX), HardLimitsFault, FALLING);

  //iniciar o pino enable dos drivers como saída
  pinMode(Ena, OUTPUT);
  digitalWrite(Ena, HIGH); //começar com os motores desligados

  //agrupar os motores para posicionamento conjunto
  SYNCMovXYZ.addStepper(Yaxis);
  SYNCMovXYZ.addStepper(Zaxis);
  SYNCMovXYZ.addStepper(Xaxis);
}

void msgIn() {
  while (Serial.available()) {
    delay(3);  //delay para aguardar o recebimento total da string
    if (Serial.available() > 0) {
      char c = Serial.read();
      msg_IN += c;
    }
  }
  if (msg_IN.length() > 0) {
    if (msg_IN == "H") {
      HomingRotine = true;
      msg_IN = "";
    } else if (msg_IN == "ENA") {
      digitalWrite(Ena, LOW); // ligar motores
      msg_IN = "";
    } else if (msg_IN == "DIS") {
      digitalWrite(Ena, HIGH); // desligar motores
      msg_IN = "";
    } else if (msg_IN == "MOV") {
      MoveArm = true;
      msg_IN = "";
    } else if (msg_IN == "ACC+") {
      WithACCDCC = true;
      msg_IN = "";
    } else if (msg_IN == "ACC-") {
      WithACCDCC = false;
      msg_IN = "";
    } else if (msg_IN.startsWith("SET")) {
      int index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      vel = atol(msg_IN.substring(3, index).c_str()); //atribuir velocidade
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      acc = atol(msg_IN.substring(0, index).c_str()); //atribuir aceleração
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      MINdelay = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = "";
      //resposta de confirmação
      Serial.print("VEL");
      Serial.println(vel);
      delay(100);
      Serial.print("ACC");
      Serial.println(acc);
      delay(100);
      Serial.print("MDL");
      Serial.println(MINdelay);
    } else if (msg_IN.startsWith("SAV")) {
      int index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      YP1 = atol(msg_IN.substring(3, index).c_str()); //atribuir velocidade
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      YP2 = atol(msg_IN.substring(0, index).c_str()); //atribuir aceleração
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      YP3 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      YP4 = atol(msg_IN.substring(3, index).c_str()); //atribuir velocidade
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      YP5 = atol(msg_IN.substring(0, index).c_str()); //atribuir aceleração
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      YP6 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      YP7 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      YP8 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      ZP1 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      ZP2 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      ZP3 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      ZP4 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      ZP5 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      ZP6 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      ZP7 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      ZP8 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      XP1 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      XP2 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      XP3 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      XP4 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      XP5 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      XP6 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      XP7 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço (" ")
      XP8 = atol(msg_IN.substring(0, index).c_str()); //atribuir min delay
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      msg_IN = "";
      Serial.print("SAV");
    } else {
      //atribuir coordenadas lidas
      int index = msg_IN.indexOf(" "); //localizar o espaço
      coordY = atol(msg_IN.substring(0, index).c_str());
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço
      coordZ = atol(msg_IN.substring(0, index).c_str());
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      index = msg_IN.indexOf(" "); //localizar o espaço
      coordX = atol(msg_IN.substring(0, index).c_str());
      msg_IN = msg_IN.substring(index + 1); //eliminar texto lido
      //chamar função de calculo de posições
      CalcPos();
      //apagar dados de entrada
      msg_IN = "";
      DataReceived = true;
    }
  }
}

void CalcPos() {
  //------------------------------------------------------VARIAVEIS DE POSICIONAMENTO INCREMENTAL
  float zz = coordZ - realPosZ; //ZF - Z0
  float yy = coordY - realPosY; //YF - Y0
  PrevPosX = realPosX;
  vector = sqrt((pow(coordY - realPosY, 2)) + (pow(coordZ - realPosZ, 2))); //comprimento do vector deslocamento
  //ALTERAR ANGULO CONFORME EM AVNAÇO OU RECUO
  if (coordY > realPosY) {
    alphaRAD = atan((zz) / (yy)); //angulo do vetor deslocamento
  } else {
    alphaRAD = atan((zz) / (yy)) + PI; //angulo do vetor deslocamento + PI
  }
  inc = round(vector / DeltaS); //número de incrementos
  DeltaS_X = (coordX - realPosX)  / inc; //variação do deslocamento em X, conforme o valor de inc de YZ
  //ARRAY DE POSIÇÕES INTERMÉDIAS
  for (int i = 0; i <= (inc); i++) {
    PrevPosY =  realPosY + (i * DeltaS * cos(alphaRAD)); //NOVA POSIÇÃO Y
    PrevPosZ =  realPosZ + (i * DeltaS * sin(alphaRAD)); //NOVA POSIÇÃO Z
    PrevPosX = PrevPosX + DeltaS_X;
    CinInv(PrevPosY, PrevPosZ); //CALCULO DA CIN INV
    FINALPOSY[i] = finalposXYZ[0]; //VALOR DEVOLVIDO EM PUL
    FINALPOSZ[i] = finalposXYZ[1]; //VALOR DEVOLVIDO EM PUL
    FINALPOSX[i] = PrevPosX * 50; //50 = 200 Pul/Rev * 4 mm de passo
  }
  //--------------------------------------------ACC DCC
  float c0 = acc; //APROXIMAÇÃO DE VALOR INICIAL DE c0 = 1/t * sqrt(2*alpha / acc);
  float prevPulse = 0; //valor de cn-1
  int maxVel = MINdelay; //quanto MENOR, maior a velocidade, pq na verdade é um delay
  //array de delays de aceleração
  for (int i = 0; i < inc / 2; i++) {
    float c = c0;
    if (i > 0)
      c = prevPulse - (2 * prevPulse) / (4 * i + 1); //não substituir o valor no 1º loop
    if (c < maxVel)
      c = maxVel; //não passar a velocidade máxima estipulada
    contPul[i] = c; //atribuir valores ao array
    prevPulse = c; //atribuir o novo valor de cn-1
  }
}

void CinInv (double coordY_CI, double coordZ_CI) {
  //theta 2
  theta2 = -acos((((pow(120 - coordY_CI, 2)) + (pow(200 - coordZ_CI, 2)) - (pow(L1, 2)) - (pow(L2, 2)))) / (48000)); //48000 = 2*L1*L2
  //theta 1
  float posz = 200 - coordZ_CI;
  float posy = 120 - coordY_CI;
  float poszz = L2 * sin(theta2);
  float posyy = L1 + 200 * cos(theta2);
  theta1 = atan((posz) / (posy)) + atan((poszz) / (posyy));
  //converter para DEG
  theta1 = theta1 * (180 / PI);
  theta2 = theta2 * (180 / PI);
  //determinar pulsos a ser executados pelo motor
  finalposXYZ[0] = round(theta2 * 55.5555555); // 55.555555 = 100 * PulPerRev/360 conversão para pulsos com redutora de 100:1
  finalposXYZ[1] = round(theta1 * 55.5555555); // 100 * (PulPerRev/360)
  //atribuir as posições para mover às coordenadas recebidas
  posTomoveY = coordY_CI;
  posTomoveZ = coordZ_CI;
}

void Homing() {

  if (HomingRotine == true) {
    //definir posição atual como 0
    Yaxis.setCurrentPosition(0);
    Zaxis.setCurrentPosition(0);
    Xaxis.setCurrentPosition(0);
    //variaveis de homing
    int homeY = 0;
    int homeZ = 0;
    int homeX = 0;
    //aproximar do fim de cuso
    while (digitalRead(LSwitchZ) == 1) {
      Zaxis.setMaxSpeed(200.0); //definir velocidade
      Zaxis.moveTo(homeZ);
      homeZ--;
      Zaxis.run();
    }
    delay(500); //aguardar meio segundo
    //afastar do fim de curso
    while (digitalRead(LSwitchZ) == 0) {
      Zaxis.setMaxSpeed(20.0);
      homeZ = 1;
      Zaxis.moveTo(homeZ);
      homeZ++;
      Zaxis.run();
    }
    Serial.println("Zhome"); //eixo Z calibrado

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

    //------------------------------------------------X Homing

    while (digitalRead(LSwitchX) == 1) {
      Xaxis.setMaxSpeed(200.0);
      Xaxis.moveTo(homeX);
      homeX++;
      Xaxis.run();
    }
    delay(500); //tempo de espera antes de inverter a rotação
    while (digitalRead(LSwitchX) == 0) {
      Xaxis.setMaxSpeed(20.0);
      homeX = 1;
      Xaxis.moveTo(homeX);
      homeX--;
      Xaxis.run();
    }
    Serial.println("Xhome");

    //------------------------------------------------atualizar posição
    realPosY =  -107;
    realPosZ = 68;
    realPosX = -100;




    finalposXYZ[0] = -4001;
    finalposXYZ[1] = -886;
    finalposXYZ[2] = -5000;

    Yaxis.setCurrentPosition(finalposXYZ[0]);
    Zaxis.setCurrentPosition(finalposXYZ[1]);
    Xaxis.setCurrentPosition(finalposXYZ[2]);

    delay(100);
    Serial.println("HOMING COMPLETE");

    delay(100);
    //Serial.println("Actual position:");
    Serial.print("PosY");
    Serial.println(realPosY);

    delay(100);
    Serial.print("PosZ");
    Serial.println(realPosZ);

    delay(100);
    Serial.print("PosX");
    Serial.println(realPosX);

    HomingRotine = false;
  }
}

void HardLimitsFault() {

  if (DataReceived == true && HomingRotine == false) {
    MoveArm = false;
    DataReceived = false;
    digitalWrite(Ena, HIGH); //começar com o motor desligado
    Yaxis.stop();
    Zaxis.stop();
    Xaxis.stop();
    Serial.println("FAULT");
    //atualizar posições
    FINALPOSY[0] = FINALPOSY[inc];
    FINALPOSZ[0] = FINALPOSZ[inc];
    FINALPOSX[0] = FINALPOSX[inc];
    realPosY = coordY;
    realPosZ = coordZ;
    realPosX = coordX;
  }
}

void IncPos() {
  if (DataReceived == true) {

    //definir uma velocidade para o movimento
    Yaxis.setMaxSpeed(vel);
    Zaxis.setMaxSpeed(vel);
    Xaxis.setMaxSpeed(vel);

    //atribuir posição atual ao primeiro valor do array
    Yaxis.setCurrentPosition(FINALPOSY[0]);
    Zaxis.setCurrentPosition(FINALPOSZ[0]);
    Xaxis.setCurrentPosition(FINALPOSX[0]);

    //mover os motores pelo array
    for (int i = 1; i <= (inc); i++) {

      //verificar se o movimento é com ou sem aceleração
      if (i <= (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[i - 1]);
      } else if (i > (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[inc - i - 1]);
      }

      //atribuir valores dos arrays ao array comum (necessário devido à classe MultiStepper)
      finalposXYZ[0] = FINALPOSY[i];
      finalposXYZ[1] = FINALPOSZ[i];
      finalposXYZ[2] = FINALPOSX[i];
      SYNCMovXYZ.moveTo(finalposXYZ);
      SYNCMovXYZ.runSpeedToPosition();
    }

    //atualizar posições
    FINALPOSY[0] = FINALPOSY[inc];
    FINALPOSZ[0] = FINALPOSZ[inc];
    FINALPOSX[0] = FINALPOSX[inc];
    realPosY = coordY;
    realPosZ = coordZ;
    realPosX = coordX;

    //desativar flag (movimento concluido)
    DataReceived = false;

    //resposta de atualização de posições e vetor
    delay(100);
    Serial.print("PosY");
    Serial.println(realPosY);
    delay(100);
    Serial.print("PosZ");
    Serial.println(realPosZ);
    delay(100);
    Serial.print("PosX");
    Serial.println(realPosX);
    delay(100);
    Serial.print("VET");
    Serial.println(vector);
  }
}

void Move() {
  if (MoveArm == true) {

    //------------------------------------------------------------MOVE 1------------------------------
    coordY = 50;
    coordZ = 10;
    coordX = 10;
    CalcPos();

    //mover em linha recta
    Yaxis.setCurrentPosition(FINALPOSY[0]);
    Zaxis.setCurrentPosition(FINALPOSZ[0]);
    Xaxis.setCurrentPosition(FINALPOSX[0]);
    Yaxis.setMaxSpeed(vel);
    Zaxis.setMaxSpeed(vel);
    Xaxis.setMaxSpeed(vel);

    for (int i = 1; i <= (inc); i++) {

      if (i <= (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[i - 1]);
      } else if (i > (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[inc - i - 1]);
      }

      finalposXYZ[0] = FINALPOSY[i];
      finalposXYZ[1] = FINALPOSZ[i];
      finalposXYZ[2] = FINALPOSX[i];
      SYNCMovXYZ.moveTo(finalposXYZ);
      SYNCMovXYZ.runSpeedToPosition();
      //Serial.println(FINALPOSY[i]);
      //Serial.println(i);
      // Serial.println(FINALPOSZ[i]);
      //Serial.println(PrevPosY[i]);
      //Serial.print(" ");
      //Serial.print(PrevPosZ[i]); MOSTRAR POSIÇÃO REAL NA INTERFACE
    }
    FINALPOSY[0] = FINALPOSY[inc];
    FINALPOSZ[0] = FINALPOSZ[inc];
    FINALPOSX[0] = FINALPOSX[inc];


    realPosY = coordY;
    realPosZ = coordZ;
    realPosX = coordX;

    //------------------------------------------------------------MOVE 2------------------------------
    coordY = -107;
    coordZ = 68;
    coordX = -100;
    CalcPos();

    //mover em linha recta
    Yaxis.setCurrentPosition(FINALPOSY[0]);
    Zaxis.setCurrentPosition(FINALPOSZ[0]);
    Xaxis.setCurrentPosition(FINALPOSX[0]);
    Yaxis.setMaxSpeed(vel);
    Zaxis.setMaxSpeed(vel);
    Xaxis.setMaxSpeed(vel);

    for (int i = 1; i <= (inc); i++) {

      if (i <= (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[i - 1]);
      } else if (i > (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[inc - i - 1]);
      }

      finalposXYZ[0] = FINALPOSY[i];
      finalposXYZ[1] = FINALPOSZ[i];
      finalposXYZ[2] = FINALPOSX[i];
      SYNCMovXYZ.moveTo(finalposXYZ);
      SYNCMovXYZ.runSpeedToPosition();
      //Serial.println(FINALPOSY[i]);
      //Serial.println(i);
      // Serial.println(FINALPOSZ[i]);
      //Serial.println(PrevPosY[i]);
      //Serial.print(" ");
      //Serial.print(PrevPosZ[i]); MOSTRAR POSIÇÃO REAL NA INTERFACE
    }
    FINALPOSY[0] = FINALPOSY[inc];
    FINALPOSZ[0] = FINALPOSZ[inc];
    FINALPOSX[0] = FINALPOSX[inc];


    realPosY = coordY;
    realPosZ = coordZ;
    realPosX = coordX;

    //------------------------------------------------------------MOVE 3------------------------------
    coordY = 0;
    coordZ = 0;
    coordX = 0;
    CalcPos();

    //mover em linha recta
    Yaxis.setCurrentPosition(FINALPOSY[0]);
    Zaxis.setCurrentPosition(FINALPOSZ[0]);
    Xaxis.setCurrentPosition(FINALPOSX[0]);
    Yaxis.setMaxSpeed(vel);
    Zaxis.setMaxSpeed(vel);
    Xaxis.setMaxSpeed(vel);

    for (int i = 1; i <= (inc); i++) {

      if (i <= (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[i - 1]);
      } else if (i > (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[inc - i - 1]);
      }

      finalposXYZ[0] = FINALPOSY[i];
      finalposXYZ[1] = FINALPOSZ[i];
      finalposXYZ[2] = FINALPOSX[i];
      SYNCMovXYZ.moveTo(finalposXYZ);
      SYNCMovXYZ.runSpeedToPosition();
      //Serial.println(FINALPOSY[i]);
      //Serial.println(i);
      // Serial.println(FINALPOSZ[i]);
      //Serial.println(PrevPosY[i]);
      //Serial.print(" ");
      //Serial.print(PrevPosZ[i]); MOSTRAR POSIÇÃO REAL NA INTERFACE
    }
    FINALPOSY[0] = FINALPOSY[inc];
    FINALPOSZ[0] = FINALPOSZ[inc];
    FINALPOSX[0] = FINALPOSX[inc];


    realPosY = coordY;
    realPosZ = coordZ;
    realPosX = coordX;

    //------------------------------------------------------------MOVE 4------------------------------
    coordY = 20;
    coordZ = 10;
    coordX = 50;
    CalcPos();

    //mover em linha recta
    Yaxis.setCurrentPosition(FINALPOSY[0]);
    Zaxis.setCurrentPosition(FINALPOSZ[0]);
    Xaxis.setCurrentPosition(FINALPOSX[0]);
    Yaxis.setMaxSpeed(vel);
    Zaxis.setMaxSpeed(vel);
    Xaxis.setMaxSpeed(vel);

    for (int i = 1; i <= (inc); i++) {

      if (i <= (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[i - 1]);
      } else if (i > (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[inc - i - 1]);
      }

      finalposXYZ[0] = FINALPOSY[i];
      finalposXYZ[1] = FINALPOSZ[i];
      finalposXYZ[2] = FINALPOSX[i];
      SYNCMovXYZ.moveTo(finalposXYZ);
      SYNCMovXYZ.runSpeedToPosition();
      //Serial.println(FINALPOSY[i]);
      //Serial.println(i);
      // Serial.println(FINALPOSZ[i]);
      //Serial.println(PrevPosY[i]);
      //Serial.print(" ");
      //Serial.print(PrevPosZ[i]); MOSTRAR POSIÇÃO REAL NA INTERFACE
    }
    FINALPOSY[0] = FINALPOSY[inc];
    FINALPOSZ[0] = FINALPOSZ[inc];
    FINALPOSX[0] = FINALPOSX[inc];


    realPosY = coordY;
    realPosZ = coordZ;
    realPosX = coordX;

    //------------------------------------------------------------MOVE 5------------------------------
    coordY = 40;
    coordZ = 20;
    coordX = 40;
    CalcPos();

    //mover em linha recta
    Yaxis.setCurrentPosition(FINALPOSY[0]);
    Zaxis.setCurrentPosition(FINALPOSZ[0]);
    Xaxis.setCurrentPosition(FINALPOSX[0]);
    Yaxis.setMaxSpeed(vel);
    Zaxis.setMaxSpeed(vel);
    Xaxis.setMaxSpeed(vel);

    for (int i = 1; i <= (inc); i++) {

      if (i <= (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[i - 1]);
      } else if (i > (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[inc - i - 1]);
      }

      finalposXYZ[0] = FINALPOSY[i];
      finalposXYZ[1] = FINALPOSZ[i];
      finalposXYZ[2] = FINALPOSX[i];
      SYNCMovXYZ.moveTo(finalposXYZ);
      SYNCMovXYZ.runSpeedToPosition();
      //Serial.println(FINALPOSY[i]);
      //Serial.println(i);
      // Serial.println(FINALPOSZ[i]);
      //Serial.println(PrevPosY[i]);
      //Serial.print(" ");
      //Serial.print(PrevPosZ[i]); MOSTRAR POSIÇÃO REAL NA INTERFACE
    }
    FINALPOSY[0] = FINALPOSY[inc];
    FINALPOSZ[0] = FINALPOSZ[inc];
    FINALPOSX[0] = FINALPOSX[inc];


    realPosY = coordY;
    realPosZ = coordZ;
    realPosX = coordX;

    //------------------------------------------------------------MOVE 6------------------------------
    coordY = 80;
    coordZ = 10;
    coordX = 10;
    CalcPos();

    //mover em linha recta
    Yaxis.setCurrentPosition(FINALPOSY[0]);
    Zaxis.setCurrentPosition(FINALPOSZ[0]);
    Xaxis.setCurrentPosition(FINALPOSX[0]);
    Yaxis.setMaxSpeed(vel);
    Zaxis.setMaxSpeed(vel);
    Xaxis.setMaxSpeed(vel);

    for (int i = 1; i <= (inc); i++) {

      if (i <= (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[i - 1]);
      } else if (i > (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[inc - i - 1]);
      }

      finalposXYZ[0] = FINALPOSY[i];
      finalposXYZ[1] = FINALPOSZ[i];
      finalposXYZ[2] = FINALPOSX[i];
      SYNCMovXYZ.moveTo(finalposXYZ);
      SYNCMovXYZ.runSpeedToPosition();
      //Serial.println(FINALPOSY[i]);
      //Serial.println(i);
      // Serial.println(FINALPOSZ[i]);
      //Serial.println(PrevPosY[i]);
      //Serial.print(" ");
      //Serial.print(PrevPosZ[i]); MOSTRAR POSIÇÃO REAL NA INTERFACE
    }
    FINALPOSY[0] = FINALPOSY[inc];
    FINALPOSZ[0] = FINALPOSZ[inc];
    FINALPOSX[0] = FINALPOSX[inc];


    realPosY = coordY;
    realPosZ = coordZ;
    realPosX = coordX;

    //------------------------------------------------------------MOVE 7------------------------------
    coordY = 0;
    coordZ = 50;
    coordX = -35;
    CalcPos();

    //mover em linha recta
    Yaxis.setCurrentPosition(FINALPOSY[0]);
    Zaxis.setCurrentPosition(FINALPOSZ[0]);
    Xaxis.setCurrentPosition(FINALPOSX[0]);
    Yaxis.setMaxSpeed(vel);
    Zaxis.setMaxSpeed(vel);
    Xaxis.setMaxSpeed(vel);

    for (int i = 1; i <= (inc); i++) {

      if (i <= (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[i - 1]);
      } else if (i > (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[inc - i - 1]);
      }

      finalposXYZ[0] = FINALPOSY[i];
      finalposXYZ[1] = FINALPOSZ[i];
      finalposXYZ[2] = FINALPOSX[i];
      SYNCMovXYZ.moveTo(finalposXYZ);
      SYNCMovXYZ.runSpeedToPosition();
      //Serial.println(FINALPOSY[i]);
      //Serial.println(i);
      // Serial.println(FINALPOSZ[i]);
      //Serial.println(PrevPosY[i]);
      //Serial.print(" ");
      //Serial.print(PrevPosZ[i]); MOSTRAR POSIÇÃO REAL NA INTERFACE
    }
    FINALPOSY[0] = FINALPOSY[inc];
    FINALPOSZ[0] = FINALPOSZ[inc];
    FINALPOSX[0] = FINALPOSX[inc];


    realPosY = coordY;
    realPosZ = coordZ;
    realPosX = coordX;

    //------------------------------------------------------------MOVE 8------------------------------
    coordY = -107;
    coordZ = 68;
    coordX = -100;
    CalcPos();

    //mover em linha recta
    Yaxis.setCurrentPosition(FINALPOSY[0]);
    Zaxis.setCurrentPosition(FINALPOSZ[0]);
    Xaxis.setCurrentPosition(FINALPOSX[0]);
    Yaxis.setMaxSpeed(vel);
    Zaxis.setMaxSpeed(vel);
    Xaxis.setMaxSpeed(vel);

    for (int i = 1; i <= (inc); i++) {

      if (i <= (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[i - 1]);
      } else if (i > (inc / 2) && WithACCDCC == true) {
        delayMicroseconds(contPul[inc - i - 1]);
      }

      finalposXYZ[0] = FINALPOSY[i];
      finalposXYZ[1] = FINALPOSZ[i];
      finalposXYZ[2] = FINALPOSX[i];
      SYNCMovXYZ.moveTo(finalposXYZ);
      SYNCMovXYZ.runSpeedToPosition();
      //Serial.println(FINALPOSY[i]);
      //Serial.println(i);
      // Serial.println(FINALPOSZ[i]);
      //Serial.println(PrevPosY[i]);
      //Serial.print(" ");
      //Serial.print(PrevPosZ[i]); MOSTRAR POSIÇÃO REAL NA INTERFACE
    }
    FINALPOSY[0] = FINALPOSY[inc];
    FINALPOSZ[0] = FINALPOSZ[inc];
    FINALPOSX[0] = FINALPOSX[inc];


    realPosY = coordY;
    realPosZ = coordZ;
    realPosX = coordX;

  }
}

void loop() {
  msgIn();
  IncPos();
  Homing();
  Move();
}
