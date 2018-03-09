using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaTreasureTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "Player"){
			loadDialogue loadDialogue = GameObject.Find("UIScripts").GetComponent<loadDialogue>();
			loadDialogue.showDialogue(1);
		}
	}
}
