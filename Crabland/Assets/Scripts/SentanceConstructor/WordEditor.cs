using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class WordEditor : EditorWindow
{

    public WordList wordList;
    private int viewIndex = 1;

    [MenuItem("Window/Word Editor %#e")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(WordEditor));
    }

    void OnEnable()
    {
        if (EditorPrefs.HasKey("ObjectPath"))
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            wordList = AssetDatabase.LoadAssetAtPath(objectPath, typeof(WordList)) as WordList;
        }

    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Word List Editor", EditorStyles.boldLabel);
        if (wordList != null)
        {
            if (GUILayout.Button("Show Word List"))
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = wordList;
            }
        }
        if (GUILayout.Button("Open Word List"))
        {
            OpenItemList();
        }
        if (GUILayout.Button("New Word List"))
        {
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = wordList;
        }
        GUILayout.EndHorizontal();

        if (wordList == null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            if (GUILayout.Button("Create New Word List", GUILayout.ExpandWidth(false)))
            {
                CreateNewWordList();
            }
            if (GUILayout.Button("Open Existing Word List", GUILayout.ExpandWidth(false)))
            {
                OpenItemList();
            }
            GUILayout.EndHorizontal();
        }

        GUILayout.Space(20);

        if (wordList != null)
        {
            GUILayout.BeginHorizontal();

            GUILayout.Space(10);

            if (GUILayout.Button("Prev", GUILayout.ExpandWidth(false)))
            {
                if (viewIndex > 1)
                    viewIndex--;
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Next", GUILayout.ExpandWidth(false)))
            {
                if (viewIndex < wordList.wordList.Count)
                {
                    viewIndex++;
                }
            }

            GUILayout.Space(60);

            if (GUILayout.Button("Add Word", GUILayout.ExpandWidth(false)))
            {
                AddItem();
            }
            if (GUILayout.Button("Delete Word", GUILayout.ExpandWidth(false)))
            {
                DeleteItem(viewIndex - 1);
            }

            GUILayout.EndHorizontal();
            if (wordList.wordList == null)
                Debug.Log("wtf");
            if (wordList.wordList.Count > 0)
            {
                GUILayout.BeginHorizontal();
                viewIndex = Mathf.Clamp(EditorGUILayout.IntField("Current Word", viewIndex, GUILayout.ExpandWidth(false)), 1, wordList.wordList.Count);
                //Mathf.Clamp (viewIndex, 1, inventoryItemList.itemList.Count);
                EditorGUILayout.LabelField("of   " + wordList.wordList.Count.ToString() + "  items", "", GUILayout.ExpandWidth(false));
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                wordList.wordList[viewIndex - 1].englishText = EditorGUILayout.TextField("English Text", wordList.wordList[viewIndex - 1].englishText as string);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                wordList.wordList[viewIndex - 1].thaiText = EditorGUILayout.TextField("Thai Text", wordList.wordList[viewIndex - 1].thaiText as string);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                wordList.wordList[viewIndex - 1].englishAudio = EditorGUILayout.ObjectField("English Audio", wordList.wordList[viewIndex - 1].englishAudio, typeof(AudioClip), false) as AudioClip;
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                wordList.wordList[viewIndex - 1].thaiAudio = EditorGUILayout.ObjectField("Thai Audio", wordList.wordList[viewIndex - 1].thaiAudio, typeof(AudioClip), false) as AudioClip;
                GUILayout.EndHorizontal();

                GUILayout.Space(10);
            }
            else
            {
                GUILayout.Label("This Word List is Empty.");
            }
        }
        if (GUI.changed)
        {
            EditorUtility.SetDirty(wordList);
        }
    }

    void CreateNewWordList()
    {
        // There is no overwrite protection here!
        // There is No "Are you sure you want to overwrite your existing object?" if it exists.
        // This should probably get a string from the user to create a new name and pass it ...
        viewIndex = 1;
        wordList = CreateWordList.Create();
        if (wordList)
        {
            wordList.wordList = new List<Word>();
            string relPath = AssetDatabase.GetAssetPath(wordList);
            EditorPrefs.SetString("ObjectPath", relPath);
        }
    }

    void OpenItemList()
    {
        string absPath = EditorUtility.OpenFilePanel("Select Word List", "", "");
        if (absPath.StartsWith(Application.dataPath))
        {
            string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
            wordList = AssetDatabase.LoadAssetAtPath(relPath, typeof(WordList)) as WordList;
            if (wordList.wordList == null)
                wordList.wordList = new List<Word>();
            if (wordList)
            {
                EditorPrefs.SetString("ObjectPath", relPath);
            }
        }
    }

    void AddItem()
    {
        Word newWord = new Word();
        newWord.englishText = "english text";
        newWord.thaiText = "thai text";
        newWord.englishAudio = null;
        newWord.thaiAudio = null;
        wordList.wordList.Add(newWord);
        viewIndex = wordList.wordList.Count;
    }

    void DeleteItem(int index)
    {
        wordList.wordList.RemoveAt(index);
    }
}
