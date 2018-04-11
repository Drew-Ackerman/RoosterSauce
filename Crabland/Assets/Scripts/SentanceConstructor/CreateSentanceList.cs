using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateSentanceList
{
    [MenuItem("Assets/Create/Sentance List")]
    public static SentanceList Create(string path)
    {
        SentanceList sentanceList = ScriptableObject.CreateInstance<SentanceList>();

        AssetDatabase.CreateAsset(sentanceList, "Assets/SentanceList/ " + path + ".asset");
        AssetDatabase.SaveAssets();
        return sentanceList;
    }
}

