using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
/*
Statci fucntion for create file PLY 
By Jose Jaspe (JCode)
*/

public static class SavePLY
{
    public static string CurrentFilePath;
    public static List<byte> byteFile;
    public static bool BeginFile = false;
    public static int currentNumberVertex = 0;
    public static int postByteInitalNumberVertex = 0;
    public static int postByteEndNumberVertex = 0;
    static bool _usePropertyColor = true;
    static bool _usePropertyNormal = false;
    


    public static void BeginPLY(string fileName ="noName" , bool usePropertyColor = true , bool usePropertyNormla = false){
        currentNumberVertex = 0;
        BeginFile = true;
        //estandar header
        _usePropertyColor = usePropertyColor;
        _usePropertyNormal = usePropertyNormla;
        char[] charArray = ("ply\nformat binary_little_endian 1.0\ncomment Created by CameleonSystem (Jaspe) \nobj_info Created by CameleonSystem UwU\nelement vertex ").ToCharArray();
        byteFile = new List<byte>();
        for (int i = 0; i < charArray.Length; i++)
        {
            byteFile.Add((byte)(charArray[i]));
        }
        charArray = ("                     ").ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            byteFile.Add((byte)(charArray[i]));
            if(i == 0) postByteInitalNumberVertex = byteFile.Count-1;
            if(i == charArray.Length-1) postByteEndNumberVertex = byteFile.Count-1;
        }
        byteFile.Add((byte)('\n'));
        string lestHeader = "property float x\nproperty float y\nproperty float z\n";
        if(usePropertyColor) lestHeader += "property uchar red\nproperty uchar green\nproperty uchar blue\n";
        if(usePropertyNormla) lestHeader += "property float nx\nproperty float ny\nproperty float nz\n";
        lestHeader += "end_header\n";
        charArray =  lestHeader.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            byteFile.Add((byte)(charArray[i]));
        }
        CurrentFilePath = getPathPLY() + fileName +".PLY";
        writeBytesPLY();
    }

    public static void writeBytesPLY(){
        setNumberVertex();
        ThreadPool.QueueUserWorkItem(Task =>
        {
                //bool endHeader = false;
            File.WriteAllBytes(CurrentFilePath , byteFile.ToArray());
            

        });

            
    }

    public static void endWriteFile(){
        setNumberVertex();
        ThreadPool.QueueUserWorkItem(Task =>
        {
            File.WriteAllBytes(CurrentFilePath , byteFile.ToArray());
            BeginFile = false;
            currentNumberVertex = 0;
            postByteInitalNumberVertex = 0;
            postByteEndNumberVertex = 0;
            byteFile.Clear();
        });
    }
    public static void addVertex(Vector3 position){
        if(!BeginFile) {
            Debug.LogError("dont beginPLY");
            return;
        }
        if(_usePropertyColor || _usePropertyNormal){
            Debug.LogError("The Current file to save, has included property normal o color and not only position");
            Debug.LogError($"PropertyColor: {_usePropertyColor}");
            Debug.LogError($"PropertyNormal: {_usePropertyNormal}");
            return;
        }
        currentNumberVertex++;
        byteFile.AddRange(floatToByte(position.x));
        byteFile.AddRange(floatToByte(position.y));
        byteFile.AddRange(floatToByte(position.z));
    }

    public static void addVertex(Vector3 position , Color32 color){
        if(!BeginFile) {
            Debug.LogError("dont beginPLY");
            return;
        }
        if(!_usePropertyColor || _usePropertyNormal){
            Debug.LogError("The Current file to save, has included property normal o no include porperty color");
            Debug.LogError($"PropertyColor: {_usePropertyColor}");
            Debug.LogError($"PropertyNormal: {_usePropertyNormal}");
            return;
        }
        currentNumberVertex++;
        byteFile.AddRange(floatToByte(position.x));
        byteFile.AddRange(floatToByte(position.y));
        byteFile.AddRange(floatToByte(position.z));
        byteFile.Add(uCharToByte(color.r));
        byteFile.Add(uCharToByte(color.g));
        byteFile.Add(uCharToByte(color.b));
    }

     public static void addVertex(Vector3 position , Color32 color, Vector3 Normal ){
        if(!BeginFile) {
            Debug.LogError("dont beginPLY");
            return;
        }
        if(!_usePropertyColor || !_usePropertyNormal){
            Debug.LogError("The Current file to save, has not included property normal or color");
            Debug.LogError($"PropertyColor: {_usePropertyColor}");
            Debug.LogError($"PropertyNormal: {_usePropertyNormal}");
            return;
        }
        currentNumberVertex++;
        byteFile.AddRange(floatToByte(position.x));
        byteFile.AddRange(floatToByte(position.y));
        byteFile.AddRange(floatToByte(position.z));
        byteFile.Add(uCharToByte(color.r));
        byteFile.Add(uCharToByte(color.g));
        byteFile.Add(uCharToByte(color.b));
        byteFile.AddRange(floatToByte(Normal.x));
        byteFile.AddRange(floatToByte(Normal.y));
        byteFile.AddRange(floatToByte(Normal.z));
    }


    public static string getPathPLY()
    {
        #if UNITY_EDITOR
        
            string path = Application.dataPath + "/PLY_FILES/" ;
            string path1 = Application.dataPath + "/PLY_FILES";
            if (!Directory.Exists(path1)) Directory.CreateDirectory(path1);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path;

        #elif UNITY_ANDROID
                
            string path = Application.persistentDataPath + "/PLY_FILES/";
            string path1 = Application.persistentDataPath + "/PLY_FILES";
            if (!Directory.Exists(path1)) Directory.CreateDirectory(path1);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path;

        #elif UNITY_IPHONE
                
            string path = Application.persistentDataPath + "/PLY_FILES/";
            string path1 = Application.persistentDataPath + "/PLY_FILES";
            if (!Directory.Exists(path1)) Directory.CreateDirectory(path1);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path;

        #else

            string path = Application.dataPath + "/PLY_FILES/";
            string path1 = Application.dataPath + "/PLY_FILES";
            if (!Directory.Exists(path1)) Directory.CreateDirectory(path1);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path;

        #endif
    }
    static void setNumberVertex(){
        char[] charArray = (currentNumberVertex.ToString()).ToCharArray();
        int startIndex = postByteInitalNumberVertex;
        for (int i = 0; i < charArray.Length; i++)
        {
            byteFile[startIndex] = (byte)charArray[i];
            startIndex++;
        }
    }

    
    static byte[] IntToByte(int intValue){
        byte[] intBytes = BitConverter.GetBytes(intValue);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(intBytes);
        return intBytes;
    }

    static byte[] floatToByte(float Value){
        byte[] bytes = BitConverter.GetBytes((Single)Value);
        return bytes;
    }

    static byte uCharToByte(int _Value){
        char Value = (char)_Value;
        byte bytes = (byte)(Value);
        return bytes;
    }
}
