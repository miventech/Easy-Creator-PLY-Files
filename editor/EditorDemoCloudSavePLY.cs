using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DemoCloudSavePLY))]
public class EditorDemoCloudSavePLY : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GUILayout.Space(40);
        DemoCloudSavePLY demo = (DemoCloudSavePLY)target;
        
        if(GUILayout.Button("Begin File"))
        {
            demo.beginFile();
        }
        if(GUILayout.Button("Add Random Points "))
        {
            demo.AddRandomPoints();
        }
        if(GUILayout.Button("Save File File"))
        {
            demo.SaveFile();
        }
    }
}