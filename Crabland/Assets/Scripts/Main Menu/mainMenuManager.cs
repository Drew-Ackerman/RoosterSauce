using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour {

	void Start(){

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void closeGame(){
		Application.Quit();
	}

	public void startGame(){
		SceneManager.LoadScene ("Forest", LoadSceneMode.Single);
	}
}
