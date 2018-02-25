using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour {
	private GameObject crab;
	private float time1, time2;

	void Start(){
		crab = GameObject.Find("Crab");
		time1 = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		//while below view area
		time2 = Time.time;
		if(time2 - time1 > 4) {
			GameObject newCrab = Object.Instantiate(crab);
			newCrab.GetComponent<mainMenuCrabWalk>().isWalking = true;
			time1 = Time.time;
		}

		
	}

	public void closeGame(){
		Application.Quit();
	}

	public void startGame(){
		SceneManager.LoadScene ("Area1", LoadSceneMode.Single);
	}
}
