using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CollectableLocation
{
    public string LocationName;
    public List<Vector3> PossibleLocations;
    public List<Sprite> PossibleSprites;
}
