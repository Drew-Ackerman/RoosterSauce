using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBase : MonoBehaviour {
	public int health;
	public float speed;
	public float timeAlive;

	void Start(){
		
	}

	void FixedUpdate(){
		this.transform.Translate(new Vector3(0, -1.0f * speed, 0));
	}
}
