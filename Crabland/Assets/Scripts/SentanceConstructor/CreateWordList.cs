using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateWordList
{
    [MenuItem("Assets/Create/Word List")]
    public static WordList Create()
    {
        WordList wordList = ScriptableObject.CreateInstance<WordList>();

        AssetDatabase.CreateAsset(wordList, "Assets/WordList.asset");
        AssetDatabase.SaveAssets();
        return wordList;
    }
}