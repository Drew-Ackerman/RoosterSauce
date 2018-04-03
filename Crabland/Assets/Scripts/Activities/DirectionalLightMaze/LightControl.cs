using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour {
	//layer specified to detect light range
	public LayerMask layer;
	//update direction based on spoken word (UP, RIGHT, DOWN, LEFT)
	public Vector2 facingDirection = new Vector2(0, -1);
	public int maxLightDistance = 10;

	//'flashlight' used by player
	private Light light;

	void Start(){
		light = gameObject.GetComponent<Light>();
	}

	void Update(){
		//send out ray in facing direction
		RaycastHit2D hit = Physics2D.Raycast(transform.parent.position, facingDirection, Mathf.Infinity, layer);
		if(hit.collider) {
			//find distance to hit object
			if(hit.distance + 3 < maxLightDistance) //light only extends a certain range
				light.range = hit.distance + 3; //shine light to that distance + small buffer
			else
				light.range = maxLightDistance;
		}
	}
}
