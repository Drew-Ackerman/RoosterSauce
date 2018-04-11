using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour {

    public Collider2D player;
    public List<TransitionZone> transitionZones;


    private void OnCollisionEnter(Collision collision)
    {
        
    }



}

[System.Serializable]
public class TransitionZone
{
    public GameObject transitionZone;
    public string sceneName;

}