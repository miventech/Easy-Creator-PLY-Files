# Save-PLY-File
By Jose Jaspe 

# [En-us] (translate)
  
  This is a code that allows you to save point cloud files in a PLY file so that it can be used or viewed later by other software
the script saves it exclusively in the format ```binary_little_endian 1.0```

In order to use the project, you must use the main class [SavePLY](/main/SavePLY.cs)
the following functions in the following order

 ## BeginPLY
 + BeginPLY (```String``` fileName,``` bool``` usePropertyColor = true, ```bool``` usePropertyNormal = false)
 
 This function creates the header of the file depending on the parameters to be used, the only mandatory parameter is the name of the file ```fileName``` which is the name
 The file to create will be assigned "Assets / PLY_FILES /```fileName``` "
 
 the other parameters indicate if the file at the time of adding points has the properties such as color or normal per point.
 
 
 ## addVertex
 + addVertex (```Vector3``` position)
 + addVertex (```Vector3``` position,``` Color32``` color)
 + addVertex (```Vector3``` position,``` Color32``` color, ```Vector3``` Normal)
 
 Depending on the properties assigned ```BeginPLY``` in you should use the corresponding function.
 
 What this function does is add a specific point to the PLY file, this function must be called every time you want to add a point to the file, and it can
 be called as many times as you want
 
 It is important to emphasize that these parameters defined in the ```BeginPLY``` function must be taken into account, since if at the time of creating the file header
 only the property of the color is assigned and not of the normal one, it will not be possible to add points with normals from that moment on. until a new one is built
 header which destroys all the points created and generates a new file or rewrites it.
 
 
 ## endWriteFile ()
 + endWriteFile ()
 
 This method is used once all the points have been added to the file and you want to finish writing the file in question. it is important to run it since it is
 the one in charge of adding all the remaining bytes to the file.
 
 ## Example [DemoCloudSavePLY.CS](/main/DemoCloudSavePLY.cs)
  The code within this file automatically generates a PLY file with random points ```int numberPointsRandom``` and a range of randomity
  ```float limit```
  
  ## Randomly generated example with 50,000 points
  

  <a target="_blank" href=""/> <img src = "https://github.com/miventech/Easy-Creator-PLY-Files/blob/main/ExmaplePLYr.png" /> </a>
  
  
# [ES-VE]
Este un codigo que permite guardar archivos nubes de puntos en un archivo PLY para que pueda ser utilizado o visualizado posteriormente por otro software
el script lo guarda esclusivamente en formato ```binary_little_endian 1.0```

Para poder usar el proyecto se debe usar de la clase principal [SavePLY](/main/SavePLY.cs)
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
 
 ## Ejemplo [DemoCloudSavePLY.CS](/main/DemoCloudSavePLY.cs)
  El codigo dentro de este archivo genera automaticamente un archivo PLY con puntos aleatorios ```int numberPointsRandom``` y un rango de aleatoridad 
  ```float limit```
  
  ## Ejemplo generado aleatoriamente con 50000 puntos
  

  <a target="_blank" href=""/> <img src = "https://github.com/miventech/Easy-Creator-PLY-Files/blob/main/ExmaplePLYr.png" /> </a>


