using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(areaGameManager))]
public class AreaGameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        areaGameManager myScript = (areaGameManager)target;
        if (GUILayout.Button("Next Quest"))
        {
            myScript.NextQuest();
        }
    }
}
