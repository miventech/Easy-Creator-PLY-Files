# Save-PLY-File
By Jose Jaspe [JaspeCode] [Miventech]

#### [ES-VE]
Este un codigo que permite guardar archivos nubes de puntos en un archivo PLY para que pueda ser utilizado o visualizado posteriormente por otro software
el script lo guarda esclusivamente en formato ```binary_little_endian 1.0```

Para poder usar el proyecto se debe usar de la clase principal [SavePLY](https://github.com/miventech/Create-PLY-File/blob/main/SavePLY.cs)
las siguientes funciones en el siguiente orden

 ## BeginPLY
 + BeginPLY ( ```String```  fileName , ```bool``` usePropertyColor = true ,```bool```  usePropertyNormal = false)
 
 esta funcion crea la cabecera del archivo dependiendo de los parametros a usar, el unico parametro obligatorio es el nombre del archivo ```fileName``` el cual es el nombre
 se le asignara el archivo a crear "Assets/PLY_FILES/```fileName```" 
 
 los demas parametros indican si el archivo al momento de agragar puntos posee las propiedades como el color o la normal por punto.
 
 
 ## addVertex
 + addVertex ( ```Vector3```  position)
 + addVertex ( ```Vector3```  position , ```Color32``` color )
 + addVertex ( ```Vector3```  position , ```Color32``` color,```Vector3``` Normal)
 
 Dependiendo de las propiedades asignadas ```BeginPLY``` en deberas utilizar la funcion correspondiente.
 
 Esta funcion lo que hace es agregar un punto especifico al archivo PLY, esta funcion debe ser llamada cada ves que desee agregar un punto al archivo, y puede
 ser llamada las veces que se desee 
 
 es importante recalcar que dichos parametros definidos en la funcion ```BeginPLY``` deben ser tomados en cuanta,  ya que si al momento de crear la cabecera del archivo 
 se asigna el unicamente la propiedad del color y no de la normal , no se podra añadir puntos con normales apartir de ese momento. hasta que se construna una nueva
 cabecera lo cual destruye todos los puntos creados y genere un archivo nuevo o lo re-escriba.
 
 
 ## endWriteFile()
 + endWriteFile()
 
 Este metodo se usa una vez se añadieron todos los puntos al archivo y desea finalizar la escritura del archivo en cuestion. es importante ejecutarlo ya que es
 el encargado de agregar todos los bytes restantes al archivo.
 
 ## Ejemplo [DemoCloudSavePLY.CS](https://github.com/miventech/Create-PLY-File/blob/main/DemoCloudSavePLY.cs)
  El codigo dentro de este archivo genera automaticamente un archivo PLY con puntos aleatorios ```int numberPointsRandom``` y un rango de aleatoridad 
  ```float limit```
  
  ## Ejemplo generado aleatoriamente con 50000 puntos
  

  <a target="_blank" href=""/><img src="https://github.com/miventech/Create-PLY-File/blob/main/ExmaplePLYr.png"/></a>

