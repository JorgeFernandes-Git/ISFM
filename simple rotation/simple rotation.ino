#define PulY 2
#define DirY 3
#define EnaY 4

void setup() {
pinMode(PulY, OUTPUT);
pinMode(DirY, OUTPUT);
pinMode(EnaY, OUTPUT);
digitalWrite(EnaY, LOW);
}

void loop() {
  digitalWrite(DirY, HIGH);
  digitalWrite(PulY, HIGH);
  digitalWrite(PulY, LOW);
  delay(2);
}
