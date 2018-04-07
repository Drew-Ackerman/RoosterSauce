using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Used to define what a collectable location is. 
/// A collectable location is a name, a list of locations within it, and possible sprites to generate in that Collectable Location. 
/// </summary>
[System.Serializable]
public class CollectableLocation
{
    public string LocationName;
    public List<Vector3> PossibleLocations;
    public List<Sprite> PossibleSprites;
}
