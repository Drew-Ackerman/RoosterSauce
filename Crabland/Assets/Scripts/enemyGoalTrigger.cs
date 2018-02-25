using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGoalTrigger : MonoBehaviour {
	private areaGameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<areaGameManager>();;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log("enemyGoalTrigger: " + col);
		gameManager.health -= 1;
	}

}
