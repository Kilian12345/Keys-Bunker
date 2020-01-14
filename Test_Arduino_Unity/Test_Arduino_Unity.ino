 int button01 = 12;
 int button02 = 10;
 int button03 = 7;
 int button04 = 5;

 int buttonState1 = 0;
 int buttonState2 = 0;
 int buttonState3 = 0;
 int buttonState4 = 0;

 bool xAxisCheck = true;
 bool yAxisCheck = true;

void setup() 
{
  // put your setup code here, to run once:

  Serial.begin(9600);

  pinMode(button01, INPUT);
  pinMode(button02, INPUT);

  pinMode(button03, INPUT);
  pinMode(button04, INPUT);
}

void loop() 
{
  // put your main code here, to run repeatedly:

   buttonState1 = digitalRead(button01);
   buttonState2 = digitalRead(button02);
   buttonState3 = digitalRead(button03);
   buttonState4 = digitalRead(button04);
  
  if (buttonState1 == HIGH && xAxisCheck == true)
  {
    Serial.write(1);
    Serial.flush();

    xAxisCheck = false;
    delay(20);
  } 
  else
  {
    Serial.write(0);
    Serial.flush();
    
    xAxisCheck = true;
    delay(20);
  }

  if (buttonState2 == HIGH && xAxisCheck == true)
  {
    Serial.write(2);
    Serial.flush();

    xAxisCheck = false;
    delay(20);
  } 
  else
  {
    Serial.write(0);
    Serial.flush();
    
    xAxisCheck = true;
    delay(20);
  }

  if (buttonState3  == HIGH && yAxisCheck == true)
  {
    Serial.write(3);
    Serial.flush();

    yAxisCheck = false;
    delay(20);
  } 
  else
  {
    Serial.write(0);
    Serial.flush();
    
    yAxisCheck = true;
    delay(20);
  }

  if (buttonState4  == HIGH && yAxisCheck == true)
  {
    Serial.write(4);
    Serial.flush();

    yAxisCheck = false;
    delay(20);
  } 
  else
  {
    Serial.write(0);
    Serial.flush();
    
    yAxisCheck = true;
    delay(20);
  }
}
