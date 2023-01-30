using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MazeGenerator))]
public class MazeGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Generate")) 
        {
            var mg = (target as MazeGenerator);
            mg.Start();
        }
    }
}
