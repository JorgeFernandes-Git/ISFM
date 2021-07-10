#define PulX 2 //pino pulso X
#define DirX 3 //pino direção X
#define PulY 4 //pino pulso Y
#define DirY 5 //pino direção Y
#define PulZ 6 //pino pulso Z
#define DirZ 7 //pino direção Z
#define Ena 8 //pino enable para X, Y, Z

//variaveis
String X, Y, Z;
String msg_IN, mmstrX, mmstrY, mmstrZ;
int mmX, mmY, mmZ, pulsesX, pulsesY, pulsesZ;
int Xini, Yini, Zini, Xfinal, Yfinal, Zfinal;

//rotinas
void mmToPulse( unsigned long calcmmX, unsigned long calcmmY, unsigned long calcmmZ );
void rotacaoACCDCC(int motor, int pulses, int vel, float acc);

void setup() {
  Serial.begin(9600); //iniciar o monitor serial
  pinMode(PulX, OUTPUT); //defenir pino como output
  pinMode(DirX, OUTPUT); //defenir pino como output
  pinMode(PulY, OUTPUT); //defenir pino como output
  pinMode(DirY, OUTPUT); //defenir pino como output
  pinMode(PulZ, OUTPUT); //defenir pino como output
  pinMode(DirZ, OUTPUT); //defenir pino como output
  pinMode(Ena, OUTPUT); //defenir pino como output
  digitalWrite(Ena, HIGH); //começar com o motor desligado
}

//------------------------------------------------ACC e DCC--------------------------------------------------//
void rotacaoACCDCC(int motor, int pulses, int vel, float acc) {

  digitalWrite(Ena, LOW); //LIGAR MOTOR
  int Dir, Pul;

  //Serial.println(motor);

  if (motor == 1) {
    Dir = DirX;
    Pul = PulX;
  }
  else if (motor == 2) {
    Dir = DirY;
    Pul = PulY;
  }
  else if (motor == 3) {
    Dir = DirZ;
    Pul = PulZ;
  }

  //Serial.println(Dir);
  //Serial.println(Pul);

  //sentido de rotação após ler o valor do monitor
  if (pulses > 0) {
    digitalWrite(Dir, LOW);
  }
  if (pulses < 0) {
    digitalWrite(Dir, HIGH);
    pulses = pulses * (-1); //converte o valor para positivo
  }

  int contPul[pulses]; //array com quantidade de delays entre pulsos

  //float alpha = 1;
  //float acc = 0.01;
  //float t = 0.0018;

  //quanto MENOR, mais rapido acelera, devido ao valor inicial de c0
  float c0 = acc; //APROXIMAÇÃO DE VALOR INICIAL DE c0 = 1/t * sqrt(2*alpha / acc);
  float prevPulse = 0; //valor de cn-1
  int maxVel = vel; //quanto MENOR, maior a velocidade, pq na verdade é um delay

  for (int i = 0; i < pulses; i++) {
    float c = c0;

    if (i > 0)
      c = prevPulse - (2 * prevPulse) / (4 * i + 1); //não substituir o valor no 1º loop

    if (c < maxVel)
      c = maxVel; //não passar a velocidade máxima estipulada

    contPul[i] = c; //atribuir valores ao array
    prevPulse = c; //atribuir o novo valor de cn-1
  }

  //debug
  //Serial.println(Dir);
  //Serial.println(Pul);

  //com esta configuração o número de pulsos é duplicado - exemplo: 200 = 2 voltas em vez de 1
  // FASE DE ACELERAÇÃO
  for (int i = 0; i < pulses; i++) {
    digitalWrite(Pul, HIGH);
    digitalWrite(Pul, LOW);
    delayMicroseconds(contPul[i]);
  }

  // FASE DE DESACELERAÇÃO
  for (int i = 0; i < pulses; i++) {
    digitalWrite(Pul, HIGH);
    digitalWrite(Pul, LOW);
    delayMicroseconds(contPul[pulses - i - 1]);
  }
}

//------------------------------------------------mm para pulsos--------------------------------------------------//
void mmToPulse( unsigned long calcmmX, unsigned long calcmmY, unsigned long calcmmZ ) {
  int pulsosPrevol = 100;
  int passo = 8;
  pulsesX = (calcmmX * pulsosPrevol) / passo;
  pulsesY = (calcmmY * pulsosPrevol) / passo;
  pulsesZ = (calcmmZ * pulsosPrevol) / passo;

  //debug
  Serial.println(pulsesX);
  Serial.println(pulsesY);
  Serial.println(pulsesZ);

  return pulsesX;
  return pulsesY;
  return pulsesZ;
}


void loop() {
  while (Serial.available()) {
    delay(3);  //sem este delay não preenche corretamente a string
    if (Serial.available() > 0) {
      char c = Serial.read();  //gets one byte from serial buffer
      msg_IN += c; //makes the string msg_IN
    }
  }

  if (msg_IN.length() > 0 && msg_IN.substring(0, 1) == "X") {
    Serial.println(msg_IN); //debug

    //ler dados e atribuir a strings

    //calcular os mm a deslocar
    mmstrX = (msg_IN.substring(1, 3)); //AVALIAR A POSIÇÃO FINAL - INICIAL
    Xfinal = mmstrX.toInt();
    mmX = Xfinal - Xini;

    mmstrY = (msg_IN.substring(4, 6));
    Yfinal = mmstrY.toInt();
    mmY = Yfinal - Yini;

    mmstrZ = (msg_IN.substring(7, 9));
    Zfinal = mmstrZ.toInt();
    mmZ = Zfinal - Zini;

    //debug
    //Serial.println(mmX);
    //Serial.println(mmY);
    //Serial.println(mmZ);


    //apagar dados de entrada
    msg_IN = "";

    //converter mm para pulsos
    mmToPulse(mmX, mmY, mmZ);

    //executar movimentos (motor, pulsos, velocidade máxima ou intervalo mínimo entre pulsos, aceleração ou  intervalo inicial entre pulsos)
    rotacaoACCDCC(1, pulsesX, 1000, 35000);
    rotacaoACCDCC(2, pulsesY, 1000, 25000);
    rotacaoACCDCC(3, pulsesZ, 1000, 25000);

    //atualizar posição
    Xini = Xfinal;
    Yini = Yfinal;
    Zini = Zfinal;
  }
}
