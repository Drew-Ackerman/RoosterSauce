using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour {

	public GameObject water;
	//public MarketManager mm;
	public GameObject correctTarget;
	private int score;

//	PlayerScript playerScript = thePlayer.GetComponent<PlayerScript>();
//	playerScript.Health -= 10.0f;

	void Start(){
		//mm = GetComponent<MarketManager> ();
	
	}
	void Update() {
		//Debug.Log (score);
	}


	void OnTriggerEnter2D(Collider2D col){
		Instantiate (water, transform.position, Quaternion.identity);
		Destroy (gameObject);
//		if (col.gameObject.tag != "correctTarget1") {
//			
//			if (score <= 0) {
//				score = 0;
//			}
//			score -= 2; 
//		}
//		score += 5;
	}
}
