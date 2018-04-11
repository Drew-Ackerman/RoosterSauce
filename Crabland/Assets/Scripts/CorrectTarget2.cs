using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectTarget2 : MonoBehaviour {

	public MarketManager marketManager;

	// Use this for initialization
	void Start () {
		//winText = GetComponent.<Text>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "WaterDrop" && marketManager.currentRound == 2) {
			Destroy (gameObject);
			marketManager.shotCorrectTarget ();

		}
	}
}
