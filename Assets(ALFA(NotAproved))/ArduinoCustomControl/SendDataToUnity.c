const int buttonLeft=7;
void setup() 
{
  // put your setup code here, to run once:
  
  Serial.begin(9600);
  pinMode(buttonLeft,INPUT);
  digitalWrite(buttonLeft,LOW);
}

void loop() 
{
  if(digitalRead(buttonLeft)==HIGH)
  {
    Serial.write(1);
    Serial.flush();
    delay(20);
  }
}

