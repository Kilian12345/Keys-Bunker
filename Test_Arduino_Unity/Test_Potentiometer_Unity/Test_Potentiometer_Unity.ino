/*
  Button

  Turns on and off a light emitting diode(LED) connected to digital pin 13,
  when pressing a pushbutton attached to pin 2.

  The circuit:
  - LED attached from pin 13 to ground
  - pushbutton attached to pin 2 from +5V
  - 10K resistor attached to pin 2 from ground

  - Note: on most Arduinos there is already an LED on the board
    attached to pin 13.

  created 2005
  by DojoDave <http://www.0j0.org>
  modified 30 Aug 2011
  by Tom Igoe

  This example code is in the public domain.

  http://www.arduino.cc/en/Tutorial/Button
*/

// constants won't change. They're used here to set pin numbers:
const int buttonPin = 2;     // the number of the pushbutton pin    // the number of the pushbutton pin
const int buttonPinDos = 3;     // the number of the pushbutton pin    // the number of the pushbutton pin
const int ledPin =  7;      // the number of the LED pin     // the number of the LED pin
const int ledPinDos =  8;      // the number of the LED pin     // the number of the LED pin
const int ledPinTres =  9;      // the number of the LED pin     // the number of the LED pin

const int hallSensorPin = 4;  // MAGNET

const int potentiometer = A0;  // GUIDON


// variables will change:
int buttonState = 0;         // variable for reading the pushbutton status
int buttonStateDOS = 0;         // variable for reading the pushbutton status   
int magnetState = 0; 
int potValue = 0;
int potentiometerValue = 0;
int potentiometerValueV2 = 0;



void setup() {
  // initialize the LED pin as an output:
  pinMode(ledPin, OUTPUT);
  pinMode(ledPinDos, OUTPUT);
  pinMode(ledPinTres, OUTPUT);
  // initialize the pushbutton pin as an input:
  pinMode(buttonPin, INPUT);
  pinMode(buttonPinDos, INPUT);


  // MAGNET ----------------
  pinMode(hallSensorPin, INPUT);  

  Serial.begin(9600);
  // MAGNET ----------------
}

void loop() {
  // Potentiometre

  // GUIDON ----------------
  
  potValue = analogRead(potentiometer);
  potentiometerValue = map(potValue, 0, 1023, 0, 255);
  //potentiometerValueV2 = map(potentiometerValue, 0, 1023, 2, 21);

  //potentiometerValueV2 = potValue;
  
  //--//potentiometerValueV2 = int(potValue*20/1024)+2; //produit en croix
  potentiometerValueV2 = 1;
  
  
  Serial.println(potentiometerValueV2);

  analogWrite(ledPinTres, potentiometerValue);
  Serial.write(potValue);
  Serial.flush();

  delay(10);
  
  // GUIDON ----------------


  
  // MAGNET ----------------
  
  // read the state of the pushbutton value:
  buttonStateDOS = digitalRead(buttonPinDos);

  /*
  // read the state of the magnet Value:
  magnetState = digitalRead(hallSensorPin);
  
  if (magnetState == LOW)
  {        
    digitalWrite(ledPinDos, HIGH);  

    Serial.write(1);
    Serial.flush();

    delay(20);
  } 
  
  else
  { 
    digitalWrite(ledPinDos, LOW); 

    Serial.write(0);
    Serial.flush();

    delay(20);
  }
  */
  
  // MAGNET ----------------


  
}
