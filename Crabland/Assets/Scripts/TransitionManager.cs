using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "EnterHouse") {
			Application.LoadLevel ("Inside");
		}
		else if (col.gameObject.tag == "Exit") {
			Application.LoadLevel ("Forest");
		}
		else if (col.gameObject.tag == "EnterMarket") {
			Application.LoadLevel ("Market");
		}
		else if (col.gameObject.tag == "EnterMaze") {
			Application.LoadLevel ("ActDirectionalLightMaze");
		}
	}
}
