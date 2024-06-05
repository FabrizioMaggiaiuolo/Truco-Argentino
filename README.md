# Truco Argentino

### Sobre mi: 
Me llamo Fabrizio Maggiaiuolo y actualmente estoy cursando el segundo cuatrimestre de la Tecnicatura en Programacion de la UTN de Avellaneda.
Este trabajo tiene una dificultad moderada pero me demostro que para hacer un programa de estas caracteristicas se necesita mas constancia que motivacion.
___
### Resumen: 
Esta aplicacion es una simulacion del juego de mesa "Truco". Al principio aparecera un menu donde podra elegir alguna de las opciones, como resgistrarse en el caso de no estarlo.
Luego podra empezar a jugar junto algun amigo. Tambien podra ver el historial de partidas que existen en la base de datos.

![image](https://user-images.githubusercontent.com/98592742/202118425-f3e5482a-a8a4-4974-922c-d5ccd8853d0c.png)

___
### Diagrama de clases:
![Diagrama](https://user-images.githubusercontent.com/98592742/202116761-86f693a7-d8c2-4ad7-9c0e-c5fa2389e1ce.png)

___
### Justificacion Tecnica:
##### 1. SQL
Este tema se aplico en la clase ADO para poder generar una base de datos donde se vayan guardando tanto las partidas como los jugadores registrados.
##### 2. Manejo de excepciones
Estas se utilizaron al abrir y cerrar alguna conexion con la base de datos para poder controlar y notificar las excepciones.
##### 3. Escritura de archivos
Se utilizo para guardar las partidas jugadas de forma locar asi poder tener mas informacion de estas y sin la necesidad de estar conectado a la base de datos.
##### 4. Delegados
Se utilizo para poder ejecutar varios metodos que se repetian en varias ocaciones de manera mas sencilla y controlada.
##### 5. Task
Se utilizo para realizar el contador de puntos para las partidas ya que este se tiene que ir actualizando a la par de que se van sumando puntos a los jugadores.
##### 6. Eventos
Se utilizo para agregar acciones que realizaba el boton de Truco a la hora de jugar una partida.


