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
	// Use this for initialization
	void Start () {
        navigationManager.SendMessage("GenerateCompass"); 
        selectNextArea(); 
	}

    public void selectNextArea()
    {
        int selectedIndex = (int)(Mathf.Floor(Random.Range(0, areaNameList.Count))); //Determine a random index
        string selectedAreaName = areaNameList[selectedIndex]; //select at selectedIndex
        areaNameList.Remove(selectedAreaName);

        navigationManager.SendMessage("SelectLocation", selectedAreaName);
        collectableManager.SendMessage("GenerateItemsAtLocation", selectedAreaName);
    }
}
