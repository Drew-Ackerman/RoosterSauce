using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class SentanceEditor : EditorWindow
{
    
    public SentanceList sentanceList;
    private int viewIndex = 1;

    [MenuItem("Window/Sentance Editor %#e")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(SentanceEditor));
    }

    void OnEnable()
    {
        if (EditorPrefs.HasKey("ObjectPath"))
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            sentanceList = AssetDatabase.LoadAssetAtPath(objectPath, typeof(SentanceList)) as SentanceList;
        }

    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Sentance List Editor", EditorStyles.boldLabel);
        if (sentanceList != null)
        {
            if (GUILayout.Button("Show Sentance List"))
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = sentanceList;
            }
        }
        if (GUILayout.Button("Open Sentance List"))
        {
            OpenItemList();
        }
        if (GUILayout.Button("New Sentance List"))
        {
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = sentanceList;
        }
        GUILayout.EndHorizontal();

        if (sentanceList == null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            string stringListName = GUILayout.TextArea("StringList asset name");
            if (GUILayout.Button("Create New Sentance List", GUILayout.ExpandWidth(false)))
            {
                    stringListName = stringListName.Trim();
                    if (string.IsNullOrEmpty(stringListName))
                    { 
                        EditorUtility.DisplayDialog("Unable to save prefab", "Please specify a valid prefab name.", "Close");
                        return;
                    }
                    CreateNewSentanceList(stringListName);
            }
            if (GUILayout.Button("Open Existing Sentance List", GUILayout.ExpandWidth(false)))
            {
                OpenItemList();
            }
            GUILayout.EndHorizontal();
        }

        GUILayout.Space(20);

        if (sentanceList != null)
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
                if (viewIndex < sentanceList.sentanceList.Count)
                {
                    viewIndex++;
                }
            }

            GUILayout.Space(60);

            if (GUILayout.Button("Add Sentance", GUILayout.ExpandWidth(false)))
            {
                AddItem();
            }
            if (GUILayout.Button("Delete Sentance", GUILayout.ExpandWidth(false)))
            {
                DeleteItem(viewIndex - 1);
            }

            GUILayout.EndHorizontal();
            if (sentanceList.sentanceList == null)
                Debug.Log("wtf");
            if (sentanceList.sentanceList.Count > 0)
            {
                GUILayout.BeginHorizontal();
                viewIndex = Mathf.Clamp(EditorGUILayout.IntField("Current Sentance", viewIndex, GUILayout.ExpandWidth(false)), 1, sentanceList.sentanceList.Count);
                Mathf.Clamp (viewIndex, 1, sentanceList.sentanceList.Count);
                EditorGUILayout.LabelField("of   " + sentanceList.sentanceList.Count.ToString() + "  items", "", GUILayout.ExpandWidth(false));
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                sentanceList.sentanceList[viewIndex - 1].sentance = EditorGUILayout.TextField("English Text", sentanceList.sentanceList[viewIndex - 1].sentance as string);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                sentanceList.sentanceList[viewIndex - 1].thaiSentance = EditorGUILayout.TextField("Thai Text", sentanceList.sentanceList[viewIndex - 1].thaiSentance as string);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                sentanceList.sentanceList[viewIndex - 1].englishAudio = EditorGUILayout.ObjectField("English Audio", sentanceList.sentanceList[viewIndex - 1].englishAudio, typeof(AudioClip), false) as AudioClip;
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                sentanceList.sentanceList[viewIndex - 1].thaiAudio = EditorGUILayout.ObjectField("Thai Audio", sentanceList.sentanceList[viewIndex - 1].thaiAudio, typeof(AudioClip), false) as AudioClip;
                GUILayout.EndHorizontal();

                GUILayout.Space(10);
            }
            else
            {
                GUILayout.Label("This Scentance List is Empty.");
            }
        }
        if (GUI.changed)
        {
            EditorUtility.SetDirty(sentanceList);
        }
    }

    void CreateNewSentanceList(string stringListName)
    {
        // There is no overwrite protection here!
        // There is No "Are you sure you want to overwrite your existing object?" if it exists.
        // This should probably get a string from the user to create a new name and pass it ...
        viewIndex = 1;
        sentanceList = CreateSentanceList.Create(stringListName);
        if (sentanceList)
        {
            sentanceList.sentanceList = new List<Sentance>();
            string relPath = AssetDatabase.GetAssetPath(sentanceList);
            EditorPrefs.SetString("ObjectPath", relPath);
        }
    }

    void OpenItemList()
    {
        string absPath = EditorUtility.OpenFilePanel("Select Sentance List", "", "");
        if (absPath.StartsWith(Application.dataPath))
        {
            string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
            sentanceList = AssetDatabase.LoadAssetAtPath(relPath, typeof(SentanceList)) as SentanceList;
            if (sentanceList.sentanceList == null)
                sentanceList.sentanceList = new List<Sentance>();
            if (sentanceList)
            {
                EditorPrefs.SetString("ObjectPath", relPath);
            }
        }
    }

    void AddItem()
    {
        Sentance sentance = new Sentance();
        sentance.sentance = "New Sentance";
        sentance.englishAudio = null;
        sentance.thaiAudio = null;
        sentanceList.sentanceList.Add(sentance);
        viewIndex = sentanceList.sentanceList.Count;
    }

    void DeleteItem(int index)
    {
        sentanceList.sentanceList.RemoveAt(index);
    }
}
