using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class areaTreasureNewScene : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "Player"){
			SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
		}
	}
}
