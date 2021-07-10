#define PulY 2 //pino pulse
#define DirY 3 //pino direção
#define EnaY 8 //pino enable



void setup() {

  Serial.begin(9600); //iniciar o monitor serial
  pinMode(PulY, OUTPUT); //defenir pino como output
  pinMode(DirY, OUTPUT); //defenir pino como output
  pinMode(EnaY, OUTPUT); //defenir pino como output
  digitalWrite(EnaY, HIGH); //começar com o motor desligado
}

void rotacaoACCDCC(int pulses, int vel, float acc) {
  digitalWrite(EnaY, LOW); //ligar o motor

  //sentido de rotação após ler o valor do monitor
  if (pulses > 0) {
    digitalWrite(DirY, LOW);
  }
  if (pulses < 0) {
    digitalWrite(DirY, HIGH);
    pulses = pulses * (-1); //converte o valor para positivo
  }

  int contPul[pulses]; //array com quantidade de delays entre pulsos

  //float alpha = 1;
  //float acc = 0.01;

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


  //com esta configuração o número de pulsos é duplicado - exemplo: 200 = 2 voltas em vez de 1
  // FASE DE ACELERAÇÃO
  for (int i = 0; i < pulses; i++) {
    digitalWrite(PulY, HIGH);
    digitalWrite(PulY, LOW);
    delayMicroseconds(contPul[i]);
  }

  // FASE DE DESACELERAÇÃO
  for (int i = 0; i < pulses; i++) {
    digitalWrite(PulY, HIGH);
    digitalWrite(PulY, LOW);
    delayMicroseconds(contPul[pulses - i - 1]);
  }

  digitalWrite(EnaY, HIGH); //desligar o motor
}

void loop() {

  //ler valores do monitor
  if (Serial.available() > 0) {
    int valor = Serial.parseInt();
    Serial.println(valor);



    //executar movimento
    rotacaoACCDCC(valor, 1000, 25000); //pulsos, velocidade máxima, aceleração; valores menores = maior velmax e maior acc inicial
/*
    rotacaoACCDCC(-3000, 100, 15000);

    rotacaoACCDCC(20, 200, 25000);
    rotacaoACCDCC(20, 200, 25000);
    rotacaoACCDCC(20, 200, 25000);
    rotacaoACCDCC(20, 200, 25000);
    rotacaoACCDCC(20, 200, 25000);

    rotacaoACCDCC(-20, 200, 25000);
    rotacaoACCDCC(-20, 200, 25000);
    rotacaoACCDCC(-20, 200, 25000);
    rotacaoACCDCC(-20, 200, 25000);
    rotacaoACCDCC(-20, 200, 25000);

    rotacaoACCDCC(-600, 500, 10000);

    rotacaoACCDCC(600, 900, 20000);

    rotacaoACCDCC(-20, 200, 20000);
    rotacaoACCDCC(-20, 200, 20000);
    rotacaoACCDCC(-20, 200, 20000);
    rotacaoACCDCC(-20, 200, 20000);
    rotacaoACCDCC(-20, 200, 20000);

    rotacaoACCDCC(20, 200, 20000);
    rotacaoACCDCC(20, 200, 20000);
    rotacaoACCDCC(20, 200, 20000);
    rotacaoACCDCC(20, 200, 20000);
    rotacaoACCDCC(20, 200, 20000);

    rotacaoACCDCC(600, 500, 15000);
    */
  }

}
