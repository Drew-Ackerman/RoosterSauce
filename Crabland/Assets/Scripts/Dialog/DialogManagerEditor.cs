using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialogManager))]
public class DialogManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogManager myScript = (DialogManager)target;
        if (GUILayout.Button("Continue Dialog"))
        {
            myScript.displayNextDialog();
        }
    }
}