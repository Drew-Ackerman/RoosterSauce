using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour {
	private GameObject crab, crabBlue;
	private float time1, time2;

	void Start(){
		crab = GameObject.Find("Crab");
		crabBlue = GameObject.Find("CrabBlue");
		time1 = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		//while below view area
		time2 = Time.time;
		if(time2 - time1 > 4) {
			int rand = Random.Range(0, 10);
			if(rand > 8) {
				GameObject newCrabBlue = Object.Instantiate(crabBlue);
			} else {
				GameObject newCrab = Object.Instantiate(crab);
				time1 = Time.time;
			}
		}

		
	}

	public void closeGame(){
		Application.Quit();
	}

	public void startGame(){
		SceneManager.LoadScene ("Area1", LoadSceneMode.Single);
	}
}
