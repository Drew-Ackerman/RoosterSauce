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
    {
        int selectedIndex = (int)(Mathf.Floor(Random.Range(0, possibleLocations.Count)));
        Location newLocation = possibleLocations[selectedIndex];
        possibleLocations.RemoveAt(selectedIndex);

        targetLocation = newLocation.location;
        Navigation navScript = compassHolder.GetComponentInChildren<Navigation>();
        navScript.targetLocation = targetLocation;
        navScript.startTracking();

    }

    void generateCompass()
    {
        GameObject compass = Instantiate(compassPrefab); //Instantiate the compass prefab. 
        compass.transform.parent = compassHolder.transform; // The compass is now a child under the compassHolder.
        compass.transform.Translate(compassPosition, compassHolder.transform); // Compass is now translated by the compassPositon relative to the holder of the compass.
    }

    void locationHit(Collider2D locationCollider)
    {
        if (true)
        {
            Debug.Log("Collide with: " + locationCollider.ToString());
        }
    }

}

[System.Serializable]
public class Location
{
    public Transform location;
    public int locationName;
}
