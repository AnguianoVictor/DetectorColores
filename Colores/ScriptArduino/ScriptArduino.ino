void setup() {
  pinMode(2, OUTPUT);//BLANCO
  pinMode(3, OUTPUT);//AZUL
  pinMode(4, OUTPUT);//VERDE
  pinMode(5, OUTPUT);//ROJO
  Serial.begin(9600); //velocidad del puerto serial
}
void loop() {
  int tiempo=100;
  do
  {
      digitalWrite(2, LOW);//BLANCO
      digitalWrite(3, LOW);//AZUL
      digitalWrite(4, LOW);//VERDE
      digitalWrite(5, LOW);//ROJO
      Serial.print(0);
      int sensorValue0 = analogRead(A0);
      Serial.println(sensorValue0);
      //Serial.println("Todo apagado");
      delay(tiempo); // Retardo entre lecturas
      
      digitalWrite(2, LOW);//BLANCO
      digitalWrite(3, LOW);//AZUL
      digitalWrite(4, LOW);//VERDE
      digitalWrite(5, HIGH);//ROJO
      Serial.print(1);
      int sensorValue1 = analogRead(A0);
      Serial.println(sensorValue1);
      delay(tiempo); // Retardo entre lecturas
      
      digitalWrite(2, LOW);//BLANCO
      digitalWrite(3, LOW);//AZUL
      digitalWrite(4, HIGH);//VERDE
      digitalWrite(5, LOW);//ROJO
      Serial.print(2);
      int sensorValue2 = analogRead(A0);
      Serial.println(sensorValue2);
      delay(tiempo); // Retardo entre lecturas
      
      digitalWrite(2, LOW);//BLANCO
      digitalWrite(3, LOW);//AZUL
      digitalWrite(4, HIGH);//VERDE
      digitalWrite(5, HIGH);//ROJO
      Serial.print(3);
      int sensorValue3 = analogRead(A0);
      Serial.println(sensorValue3);
      delay(tiempo); // Retardo entre lecturas
      
      digitalWrite(2, LOW);//BLANCO
      digitalWrite(3, HIGH);//AZUL
      digitalWrite(4, LOW);//VERDE
      digitalWrite(5, LOW);//ROJO
      Serial.print(4);
      int sensorValue4 = analogRead(A0);
      Serial.println(sensorValue4);
      delay(tiempo); // Retardo entre lecturas
      
      digitalWrite(2, LOW);//BLANCO
      digitalWrite(3, HIGH);//AZUL
      digitalWrite(4, LOW);//VERDE
      digitalWrite(5, HIGH);//ROJO
      Serial.print(5);
      int sensorValue5 = analogRead(A0);
      Serial.println(sensorValue5);
      delay(tiempo); // Retardo entre lecturas
      
      digitalWrite(2, LOW);//BLANCO
      digitalWrite(3, HIGH);//AZUL
      digitalWrite(4, HIGH);//VERDE
      digitalWrite(5, LOW);//ROJO
      Serial.print(6);
      int sensorValue6 = analogRead(A0);
      Serial.println(sensorValue6);
      delay(tiempo); // Retardo entre lecturas
      
      digitalWrite(2, LOW);//BLANCO
      digitalWrite(3, HIGH);//AZUL
      digitalWrite(4, HIGH);//VERDE
      digitalWrite(5, HIGH);//ROJO
      Serial.print(7);
      int sensorValue7 = analogRead(A0);
      Serial.println(sensorValue7);
      delay(tiempo); // Retardo entre lecturas
      
      digitalWrite(2, HIGH);//BLANCO
      digitalWrite(3, LOW);//AZUL
      digitalWrite(4, LOW);//VERDE
      digitalWrite(5, LOW);//ROJO
      Serial.print(8);
      int sensorValue8 = analogRead(A0);
      Serial.println(sensorValue8);
      delay(tiempo); // Retardo entre lecturas

      int prom=sensorValue0+sensorValue1+sensorValue2+sensorValue3+sensorValue4+sensorValue5+sensorValue6+sensorValue7+sensorValue8;
      float prome=prom/9;
      int promedio=(int)prome;
      Serial.print(9);
      Serial.println(promedio);
  }while(Serial.available());
}
