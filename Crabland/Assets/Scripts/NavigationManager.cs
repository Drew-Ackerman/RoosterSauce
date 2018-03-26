using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour {

    public List<Location> possibleLocations; // List of possible locations that the manager can choose from. 
    public GameObject compassPrefab; // What gameobject will the compass be?
    public Vector3 compassPosition; // Where is the compass in relation to the holder. 

    public GameObject compassHolder; //Who becomes the parent of the compass holder. 

    public Transform targetLocation; //Whats the current targetLocation to navigate towards? Null until selectNewLocation is called.

    void Start () {
        generateCompass();  
        selectNewLocation(); 
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void selectNewLocation()
    //Randomly pick a location out of the possibleLocations List. 
    //Pass the location to the navigationscript that is attached to the compass holder
    //Remove the location from possibleLocations List.
    {
        int selectedIndex = (int)(Mathf.Floor(Random.Range(0, possibleLocations.Count)));
        Location newLocation = possibleLocations[selectedIndex];
        possibleLocations.RemoveAt(selectedIndex);

        targetLocation = newLocation.location;

        Navigation navScript = compassHolder.GetComponentInChildren<Navigation>();
        navScript.setTargetLocation(targetLocation);
        navScript.startTracking();

    }

    void generateCompass()
    //Generate the compass at compass Position relative to the compass holder
    {
        GameObject compass = Instantiate(compassPrefab); //Instantiate the compass prefab. 
        compass.transform.parent = compassHolder.transform; // The compass is now a child under the compassHolder.
        compass.transform.Translate(compassPosition, compassHolder.transform); // Compass is now translated by the compassPositon relative to the holder of the compass.
    }

    void locationHit(Collider2D hitCollider)
    {
        if(hitCollider.name == targetLocation.name)
        {
            Navigation navScript = compassHolder.GetComponentInChildren<Navigation>();
            navScript.stopTracking();
            navScript.setTargetLocation(null);
        }
    }

}

[System.Serializable]
public class Location
{
    public Transform location;
    public int locationName;
}
