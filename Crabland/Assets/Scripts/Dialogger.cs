using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogger : MonoBehaviour {
	public GameObject diaglogCanvasGroup;
	//public PlayerController playerController;

	private void Awake() {
		//diaglogCanvasGroup.SetActive (false);
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		
		diaglogCanvasGroup.SetActive (true);
		//playerController.moveActive (false);
		if (collision.gameObject.tag == "Player") {
			collision.gameObject.GetComponent<PlayerController> ().moveActive = false;
			diaglogCanvasGroup.SetActive (true);
		}
	}
}
