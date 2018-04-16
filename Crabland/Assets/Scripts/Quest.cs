using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Quest{

    public string QuestName;
    public enum QuestEnum { Collection, Location };
    public QuestEnum QuestType;

}

public class CreateQuestList
{
    [MenuItem("Assets/Create/Quest List")]
    public static QuestList Create(string path)
    {
        QuestList questList = ScriptableObject.CreateInstance<QuestList>();

        AssetDatabase.CreateAsset(questList, "Assets/QuestList/ " + path + ".asset");
        AssetDatabase.SaveAssets();
        return questList;
    }
}


[CreateAssetMenu]
public class QuestList : ScriptableObject
{
    public List<Quest> questList;
}

