//------------------------------------------------------------------
// Ascom-Arduino Focusser
// Dave Wells
// Thanks for code snippets & inspiration:
//  o  Gina (Stargazers Lounge)
//------------------------------------------------------------------

//------ Change Log ------------------------------------------------
//  Version    Date        Change
//  0.0.2      26/05/2014  Initial - copied from Windows version
//
//------------------------------------------------------------------
  
const String programName = "Arduino Focuser";
const String programVersion = "0.0.2";

const int    motorPins[4] = {7,8,9,10};       // Declare pins to drive motor control board
const int    motorSpeedLo = 16000;            // Motor step delay for Lo speed (uS)
const int    motorSpeedHi = 2000;             // Motor step delay for Hi speed (uS)
const int    motorSpeedDefault = 16000;       // Default motor step speed (uS)(failsafe operation)
const int    speedThreshold = 25;             // motor speed Hi if steps to go is higher than this
int          motorSpeed = motorSpeedDefault;  // current delay for motor step speed (uS)

int          currentPosition = 0;             // current position
int          targetPosition = 0;              // target position

// lookup table to drive motor control board                                
const int stepPattern[8] = {B01000, B01100, B00100, B00110, B00010, B00011, B00001, B01001};

// For ASCOM connection
String inputString = "";         // string to hold incoming data
boolean stringComplete = false;  // whether the string is complete
boolean isMoving = false;        // is the motor currently moving

//------------------------------------------------------------------
// Move stepper anticlockwise 
//------------------------------------------------------------------
void anticlockwise()
{
  for(int i = 0; i < 8; i++)
  {
        setOutput(i);
        delayMicroseconds(motorSpeed);
  }
  clearOutput();
}
//------------------------------------------------------------------

//------------------------------------------------------------------
// Move stepper clockwise 
//------------------------------------------------------------------

void clockwise()
{
  for(int i = 7; i >= 0; i--)
  {
        setOutput(i);
        delayMicroseconds(motorSpeed);
  }
  clearOutput();
}
//------------------------------------------------------------------

//------------------------------------------------------------------
// Set output pins for stepper
//------------------------------------------------------------------
void setOutput(int out)
{
  for (int i=0; i<4; i++) {
    digitalWrite(motorPins[i], bitRead(stepPattern[out], i));
  }
}
//------------------------------------------------------------------

//------------------------------------------------------------------
// Clear output pins for stepper
// To ensure they are not left in an on state after movement
//------------------------------------------------------------------
void clearOutput()
{
  for (int i=0; i<4; i++) {
    digitalWrite(motorPins[i], 0);
  }
}
//------------------------------------------------------------------

//------------------------------------------------------------------
// ASCOM Serial Commands
//------------------------------------------------------------------
void serialCommand(String command) {

  switch(command.charAt(0)) {
  case '#':  // Confirm Connection
    Serial.print("OK!#");
    break;
  case 'T': // Set Target Position
    {
      int hashpos = command.indexOf('#');    // position of hash in string
      String targetPosS = command.substring(1,hashpos);
      int targetPosI = targetPosS.toInt();
      targetPosition = targetPosI;
      Serial.print("T" + targetPosS + ":OK#");
      break;
    }
  case 'P': // Get Current Position
    {
      String currentPositionS = String(currentPosition);
      Serial.print("P" + currentPositionS + ":OK#");
      break;
    }
  case 'M': // Is motor moving
    {
      if (isMoving) {
        Serial.print("M1:OK#");
      } else {
        Serial.print("M0:OK#");
      }
      break;
    }
  case 'V': // Get Version
    {
      Serial.print( programName + " V" + programVersion + "#");
      break;
    }
  default:
    {
      motorSpeed = motorSpeedDefault;
      Serial.print("ERR#");
      break;
    }
  }
  //Serial.print("#");
}
//------------------------------------------------------------------


//------------------------------------------------------------------
// Setup
//------------------------------------------------------------------
void setup() 
{
  // Declare the stepper motor pins as outputs
  for (int i=0; i<4; i++) {
    pinMode(motorPins[i], OUTPUT);
  }
  
  clearOutput();
      
  // initialize serial for ASCOM
  Serial.begin(9600);
  // reserve 200 bytes for the ASCOM driver inputString:
  inputString.reserve(200);

}
//------------------------------------------------------------------

//------------------------------------------------------------------
// Main Loop
//------------------------------------------------------------------
void loop()
{
  // process the command string when a hash arrives:
  if (stringComplete) {
    serialCommand(inputString); 
    
    // clear the command string:
    inputString = "";
    stringComplete = false;
  }
  
  // Move the position by a single step if target is different to current position
  if (targetPosition != currentPosition) {
    isMoving = true;
    
    // Adjust speed according to distance yet to travel
    if (abs(currentPosition - targetPosition) > speedThreshold) {
      motorSpeed = motorSpeedHi;
    } else {
      motorSpeed = motorSpeedLo;
    }
    
    // Going Anticlockwise to lower position
    if (targetPosition < currentPosition) {
      anticlockwise();
      currentPosition--;
    }
    
    // Going Clockwise to higher position
    if (targetPosition > currentPosition) {
      clockwise();
      currentPosition++;
    }
  } else {
    isMoving = false;
  }

}
//------------------------------------------------------------------

//------------------------------------------------------------------
// SerialEvent occurs whenever new data comes in the serial RX. 
//------------------------------------------------------------------
void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read(); 
    // add it to the inputString:
    inputString += inChar;
    // if incoming character is hash, set flag so main loop can action it
    if (inChar == '#') {
      stringComplete = true;
    } 
  }
}
//------------------------------------------------------------------

