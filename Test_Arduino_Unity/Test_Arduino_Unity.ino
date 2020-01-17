 int button01 = 12;
 int button02 = 10;
 int button03 = 7;
 int button04 = 5;

 int pushButton = 12;

 int buttonState1 = 0;
 int buttonState2 = 0;
 int buttonState3 = 0;
 int buttonState4 = 0;

 int pushButtonState = 0;
 
void setup() 
{
  // put your setup code here, to run once:

  Serial.begin(9600);

  pinMode(button01, INPUT);
  pinMode(button02, INPUT);

  pinMode(button03, INPUT);
  pinMode(button04, INPUT);

  pinMode(pushButton, INPUT);
}

void loop() 
{
  // put your main code here, to run repeatedly:

   buttonState1 = digitalRead(button01);
   buttonState2 = digitalRead(button02);
   buttonState3 = digitalRead(button03);
   buttonState4 = digitalRead(button04);

   pushButtonState = digitalRead(pushButton);
  
  if (buttonState1 == HIGH)
  {
    Serial.write(1);
    Serial.flush();
    delay(20);
  } 

  else if (buttonState2 == HIGH)
  {
    Serial.write(2);
    Serial.flush();
    delay(20);
  } 

  else
  {
    Serial.write(0);
    Serial.flush();
    delay(20);
  }

  if (buttonState3  == HIGH)
  {
    Serial.write(3);
    Serial.flush();
    delay(20);
  } 

  else if (buttonState4  == HIGH)
  {
    Serial.write(4);
    Serial.flush();
    delay(20);
  } 
  
  else
  {
    Serial.write(5);
    Serial.flush();
    delay(20);
  }

  if (pushButtonState == HIGH)
  {
    Serial.write(6);
    Serial.flush();
    delay(20);
  }
}
