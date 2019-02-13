/* Typical pin layout used:
 * -----------------------------------------------------------------------------------------
 *             MFRC522      Arduino       Arduino   Arduino    Arduino          Arduino
 *             Reader/PCD   Uno           Mega      Nano v3    Leonardo/Micro   Pro Micro
 * Signal      Pin          Pin           Pin       Pin        Pin              Pin
 * -----------------------------------------------------------------------------------------
 * RST/Reset   RST          9             5         D9         RESET/ICSP-5     RST
 * SPI SS      SDA(SS)      10            53        D10        10               10
 * SPI MOSI    MOSI         11 / ICSP-4   51        D11        ICSP-4           16
 * SPI MISO    MISO         12 / ICSP-1   50        D12        ICSP-1           14
 * SPI SCK     SCK          13 / ICSP-3   52        D13        ICSP-3           15
 */
 
#include <SPI.h>
#include <MFRC522.h>
#include <EEPROM.h>

#define RST_PIN   9     // Configurable, see typical pin layout above
#define SS_PIN    10    // Configurable, see typical pin layout above

MFRC522 mfrc522(SS_PIN, RST_PIN);   // Create MFRC522 instance

String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete
String commandString = "";

void setup() {
  Serial.begin(9600);  // Initialize serial communications with the PC
  SPI.begin();         // Init SPI bus
  mfrc522.PCD_Init();  // Init MFRC522 card

  //int data = ReadData();
//  if(data >= 1 && data <= 2000) {WriteData(0);};
//
//  WriteData(1);
  //Serial.print("Put Your Card To The Reader");
  
  //Serial.println();
}

String currentTag = "";

long currentMil;
long milDelay = 500;

void loop() {

//  if(stringComplete)
//  {
//    stringComplete = false;
//    getCommand();
//
//    if(commandString.equals("GETA"))
//    {
//      Serial.print(ReadString(1));
//    }
//    
//    inputString = "";
//  }
  if((millis() - currentMil) > milDelay){
    currentTag = "";
  }
  
  if ( ! mfrc522.PICC_IsNewCardPresent()) {
    return;
  }
  if(! mfrc522.PICC_ReadCardSerial()){
    return;
  }

  if(currentTag.substring(1) != "" ){
    return;
  }
  
  // Dump UID
  String content = "";
  byte letter;
  
  for (byte i = 0; i < mfrc522.uid.size; i++) {
    //Serial.print(mfrc522.uid.uidByte[i] < 0x10 ? "" : "");
    //Serial.print(mfrc522.uid.uidByte[i], HEX);    

    content.concat(String(mfrc522.uid.uidByte[i] < 0x10 ? "0" : ""));  
    content.concat(String(mfrc522.uid.uidByte[i], HEX));  
  } 
  //Serial.println();

  //WriteString(content);
  content.toUpperCase();
  delay(50);
  Serial.println(content);

  currentTag = content;
  currentMil = millis();
}

//String Values[150];
//bool CheckData(String UID)
//{
//  if(ReadData() != 0){
//    GetAllData();
//    int i = 0;
//    while(i != "")
//    {
//      if(Values[i] == UID)
//      {return false;}
//    }    
//  }
//  return true;
//}

//void GetAllData()
//{
//  int counter = 1;
//  int i = 0;
//  String data = ReadString(0);
//  while(data != "")
//  {
//    Values[i] = ReadString(counter);
//    i++;
//    counter += 7;
//  }
//}
//
//String ReadString(char add)
//{
//  int i;
//  String data = "";
//  int len=0;
//  char k = EEPROM.read(add);
//    while(len < 8) //Read until null character
//    {    
//      k=EEPROM.read(add+len);
//      data.concat (String(k));
//      len++;
//    }
//  
//  return String(data);
//}
//
//int ReadData()
//{
//  return EEPROM.read(0);
//}
//
//void WriteString(String data)
//{
//  int _size = data.length();
//  int i;
//  int add = ReadData();
//  for(i=0;i<_size;i++)
//  {
//    EEPROM.write(add+i,data[i]);
//  }
//  EEPROM.write(add+_size,'S');
//  //WriteData(add+_size+1);
//}
//
//void WriteData(int Value)
//{
//  EEPROM.write(0, Value);
//}

//void getCommand()
//{
//  if(inputString.length()>0)
//  {
//     commandString = inputString.substring(1,5);
//  }
//}

//void serialEvent() {
//  while (Serial.available()) {
//    // get the new byte:
//    char inChar = (char)Serial.read();
//    // add it to the inputString:
//    inputString += inChar;
//    // if the incoming character is a newline, set a flag
//    // so the main loop can do something about it:
//    if (inChar == '\n') {
//      stringComplete = true;
//    }
//  }
//}
