#include <SPI.h>
#include <MFRC522.h>

#define RST_PIN         5          
#define SS_1_PIN        53       
#define SS_2_PIN        48      
#define NR_OF_READERS   2

byte ssPins[] = {SS_1_PIN, SS_2_PIN};

int senzorvlez = 1;
int senzorizlez = 1;
int kopcegore = 0;
int kopcedole = 0;


MFRC522 mfrc522[NR_OF_READERS];

void setup() {
  pinMode(49,INPUT);
  pinMode(47,INPUT);
  pinMode(46,INPUT);
  pinMode(45,INPUT);
  
  pinMode(13,OUTPUT);
  pinMode(12,OUTPUT);

  Serial.begin(9600);
  while (!Serial);   

  SPI.begin();  

  for (uint8_t reader = 0; reader < NR_OF_READERS; reader++) {
    mfrc522[reader].PCD_Init(ssPins[reader], RST_PIN);
  }
}

void loop() {

  senzorvlez=digitalRead(49);
  senzorizlez=digitalRead(47);
  kopcedole=digitalRead(46);
  kopcegore=digitalRead(45);

  if(senzorvlez==HIGH || senzorizlez==HIGH){

        for (uint8_t reader = 0; reader < NR_OF_READERS; reader++) {
          // Look for new cards
      
          if (mfrc522[reader].PICC_IsNewCardPresent() && mfrc522[reader].PICC_ReadCardSerial()) {
            dump_byte_array(mfrc522[reader].uid.uidByte, mfrc522[reader].uid.size);
            mfrc522[reader].PICC_HaltA();
            mfrc522[reader].PCD_StopCrypto1();
          } 
        }

  }


 if(kopcedole==HIGH){
    digitalWrite(13,LOW);
    digitalWrite(12,LOW);
 }
 
 if(kopcegore==HIGH){
    digitalWrite(13,LOW);
    digitalWrite(12,LOW);
    if(senzorvlez==HIGH){
      motorkontrolanadole();
    }
 }

}




void dump_byte_array(byte *buffer, byte bufferSize) {
  senzorvlez=digitalRead(49);
  senzorizlez=digitalRead(47);
  
  for (byte i = 0; i < 1; i++) {
    Serial.print(buffer[i] < 0x10 ? "0" : " ");
    //Serial.print(buffer[i] < 0x10 ? "0" : "");
    Serial.print(buffer[i], HEX);
    
  }
  motorkontrolanagore();
}




int motorkontrolanagore(){
  digitalWrite(13,HIGH);
}


int motorkontrolanadole(){
  digitalWrite(12,HIGH);
}
