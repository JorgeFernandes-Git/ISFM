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

void rotacao(int pulses) {
  digitalWrite(EnaY, LOW); //ligar o motor
  int intervalo = 3000; //definir o intervalo entre pulsos, ou seja a direção



  //ciclo de processamento de pulsos lidos no serial
  for (int i = 0; i < pulses; i++) {
    digitalWrite(PulY, HIGH);
    digitalWrite(PulY, LOW);
    delayMicroseconds(intervalo);
  }
  digitalWrite(EnaY, HIGH); //desligar o motor
}

void loop() {

  //ler valores do monitor
  if (Serial.available() > 0) {
    int valor = Serial.parseInt();
    Serial.println(valor);

    //sentido de rotação lendo o valor do serial
    if (valor > 0) {
      digitalWrite(DirY, LOW);
    }
    if (valor < 0) {
      digitalWrite(DirY, HIGH);
      valor = valor * (-1); //converte o valor para positivo
    }

    //executar movimento
    rotacao(valor);
  }

}
