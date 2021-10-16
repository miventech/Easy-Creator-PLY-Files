using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCloudSavePLY : MonoBehaviour
{
    public string fileName;
    public bool useColorProperty;
    public bool useNormalProperty;
    public List<RandomVertex> vertex;
    public int numberPointsRandom = 100;
    public float limit = 1;
    

    public void beginFile(){
        vertex = new List<RandomVertex>();
        SavePLY.BeginPLY(fileName , useColorProperty , useNormalProperty);
    }

    public void AddRandomPoints(){

        if(vertex == null) new List<RandomVertex>();
        SavePLY.BeginPLY(fileName , useColorProperty , useNormalProperty);
        RandomVertex _rv = new RandomVertex();
        for (int i = 0; i < numberPointsRandom; i++)
        {
            _rv = new RandomVertex(limit);
            vertex.Add(_rv);
            if(!useColorProperty && !useNormalProperty){
                SavePLY.addVertex(_rv.position);
            }else if(useColorProperty && !useNormalProperty){
                SavePLY.addVertex(_rv.position , _rv.Color);
            }else if(useColorProperty && useNormalProperty){
                SavePLY.addVertex(_rv.position , _rv.Color , _rv.Normal);
            }
        }
    }

    public void SaveFile(){
        SavePLY.endWriteFile();
        vertex.Clear();
    }
    
    [System.Serializable]
    public class RandomVertex 
    {
        public Vector3 position;
        public Color32 Color;
        public Vector3 Normal;
        
        public RandomVertex(float limit = 1){
            position = new Vector3(Random.Range(-limit , limit) , Random.Range(-limit , limit) ,Random.Range(-limit , limit));
            Color = new Color32((byte)Random.Range(0 , 255) , (byte)Random.Range(0 , 255) ,(byte)Random.Range(0 , 255) , 255);
            Normal = new Vector3(Random.Range(0 , 1) , Random.Range(0 , 1) ,Random.Range(0 , 1));
        }
    }
}
