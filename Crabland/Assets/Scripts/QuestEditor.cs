using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class QuestEditor : EditorWindow
{

    public QuestList questList;
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
            questList = AssetDatabase.LoadAssetAtPath(objectPath, typeof(QuestList)) as QuestList;
        }

    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Sentance List Editor", EditorStyles.boldLabel);
        if (questList != null)
        {
            if (GUILayout.Button("Show Quest List"))
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = questList;
            }
        }
        if (GUILayout.Button("Open Quest List"))
        {
            OpenItemList();
        }
        if (GUILayout.Button("New Quest List"))
        {
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = questList;
        }
        GUILayout.EndHorizontal();

        if (questList == null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            string stringListName = GUILayout.TextArea("Quest asset name");
            if (GUILayout.Button("Create New Quest List", GUILayout.ExpandWidth(false)))
            {
                stringListName = stringListName.Trim();
                if (string.IsNullOrEmpty(stringListName))
                {
                    EditorUtility.DisplayDialog("Unable to save prefab", "Please specify a valid prefab name.", "Close");
                    return;
                }
                CreateNewSentanceList(stringListName);
            }
            if (GUILayout.Button("Open Existing Quest List", GUILayout.ExpandWidth(false)))
            {
                OpenItemList();
            }
            GUILayout.EndHorizontal();
        }

        GUILayout.Space(20);

        if (questList != null)
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
                if (viewIndex < questList.questList.Count)
                {
                    viewIndex++;
                }
            }

            GUILayout.Space(60);

            if (GUILayout.Button("Add Quest", GUILayout.ExpandWidth(false)))
            {
                AddItem();
            }
            if (GUILayout.Button("Delete Quest", GUILayout.ExpandWidth(false)))
            {
                DeleteItem(viewIndex - 1);
            }

            GUILayout.EndHorizontal();
            if (questList.questList == null)
                Debug.Log("wtf");
            if (questList.questList.Count > 0)
            {
                GUILayout.BeginHorizontal();
                viewIndex = Mathf.Clamp(EditorGUILayout.IntField("Current Quest", viewIndex, GUILayout.ExpandWidth(false)), 1, questList.questList.Count);
                Mathf.Clamp(viewIndex, 1, questList.questList.Count);
                EditorGUILayout.LabelField("of   " + questList.questList.Count.ToString() + "  items", "", GUILayout.ExpandWidth(false));
                GUILayout.EndHorizontal();

//                GUILayout.BeginHorizontal();
//                questList.questList[viewIndex - 1].sentance = EditorGUILayout.TextField("English Text", questList.questList[viewIndex - 1].sentance as string);
//                GUILayout.EndHorizontal();
//
//                GUILayout.BeginHorizontal();
//                questList.questList[viewIndex - 1].thaiSentance = EditorGUILayout.TextField("Thai Text", questList.questList[viewIndex - 1].thaiSentance as string);
//                GUILayout.EndHorizontal();
//
//                GUILayout.BeginHorizontal();
//                questList.questList[viewIndex - 1].englishAudio = EditorGUILayout.ObjectField("English Audio", questList.questList[viewIndex - 1].englishAudio, typeof(AudioClip), false) as AudioClip;
//                GUILayout.EndHorizontal();
//
//                GUILayout.BeginHorizontal();
//                questList.questList[viewIndex - 1].thaiAudio = EditorGUILayout.ObjectField("Thai Audio", questList.questList[viewIndex - 1].thaiAudio, typeof(AudioClip), false) as AudioClip;
//                GUILayout.EndHorizontal();

                GUILayout.Space(10);
            }
            else
            {
                GUILayout.Label("This Scentance List is Empty.");
            }
        }
        if (GUI.changed)
        {
            EditorUtility.SetDirty(questList);
        }
    }

    void CreateNewSentanceList(string stringListName)
    {
        // There is no overwrite protection here!
        // There is No "Are you sure you want to overwrite your existing object?" if it exists.
        // This should probably get a string from the user to create a new name and pass it ...
        viewIndex = 1;
        questList = CreateQuestList.Create(stringListName);
        if (questList)
        {
            questList.questList = new List<Quest>();
            string relPath = AssetDatabase.GetAssetPath(questList);
            EditorPrefs.SetString("ObjectPath", relPath);
        }
    }

    void OpenItemList()
    {
        string absPath = EditorUtility.OpenFilePanel("Select Quest List", "", "");
        if (absPath.StartsWith(Application.dataPath))
        {
            string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
            questList = AssetDatabase.LoadAssetAtPath(relPath, typeof(QuestList)) as QuestList;
            if (questList.questList == null)
                questList.questList = new List<Quest>();
            if (questList)
            {
                EditorPrefs.SetString("ObjectPath", relPath);
            }
        }
    }

    void AddItem()
    {
        Quest quest = new Quest();
//        quest.sentance = "New Quest";
        questList.questList.Add(quest);
        viewIndex = questList.questList.Count;
    }

    void DeleteItem(int index)
    {
        questList.questList.RemoveAt(index);
    }
}
