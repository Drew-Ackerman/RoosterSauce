using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script to be used to control the flow and state of game events
//will handle closing text when appropriate, keeping track of current event progress
public class areaGameManager : MonoBehaviour {

    public List<string> areaNameList; // A string list of area names.
    public NavigationManager navigationManager; //Reference to a NavgationManager
    public CollectableManager collectableManager; //Reference to a CollectableManager 
    public Canvas dialogUI;
    public Canvas cardUI;

	// Use this for initialization
	void Start () {
        navigationManager.SendMessage("GenerateCompass"); 
        NextQuest(); 
	}

    public void NextQuest()
    {
        int selectedIndex = (int)(Mathf.Floor(Random.Range(0, areaNameList.Count))); //Determine a random index
        string selectedAreaName = areaNameList[selectedIndex]; //select at selectedIndex
        areaNameList.Remove(selectedAreaName);

        NextDialog();
        navigationManager.SendMessage("SelectLocation", selectedAreaName);
        collectableManager.SendMessage("GenerateItemsAtLocation", selectedAreaName);
    }

    public void NextDialog()
    {
        FindObjectOfType<DialogManager>().SendMessage("displayNextDialog");
    }

    public void QuestCompleted()
    {

    }

    public void TalkToUncle()
    {

    }

}
