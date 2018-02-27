using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuCrabWalk : MonoBehaviour {
	public bool isWalking;
	private float walkSpeed, xStartPos;

	// Use this for initialization
	void Start () {
		xStartPos = Random.Range(-6f, 6f);
		this.transform.Translate(new Vector2(xStartPos, 0));
		walkSpeed = Random.Range(0.3f, 0.9f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(isWalking)
			walkUp();
	}

	private void walkUp(){
		if (this.transform.position.y < 8){
			this.transform.Translate(new Vector2(0, walkSpeed*Time.deltaTime));
		} else {
			Destroy(gameObject);
		}
	}

}
