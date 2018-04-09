using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour {
	//layer specified to detect light range
	public LayerMask layer;
	//update direction based on spoken word (UP, RIGHT, DOWN, LEFT)
	public Vector2 facingDirection = new Vector2(0, -1);
	public int maxLightDistance = 8;
	public int minLightDistance = 5;
	public GameObject player;

	//'flashlight' used by player
	new private Light light;

	void Start(){
		light = gameObject.GetComponent<Light>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update(){
		//send out ray in facing direction
		RaycastHit2D hit = Physics2D.Raycast(transform.parent.position, facingDirection, Mathf.Infinity, layer);
		if(hit.collider) {
			//find distance to hit object
			if(hit.distance/2 + minLightDistance < maxLightDistance) //light only extends a certain range
				light.range = hit.distance/2 + minLightDistance; //shine light to that distance + small buffer
			else
				light.range = maxLightDistance;
		}

		//get voice input from device
		//parse word, if word is Up, Down, Left, Right clear that overlay
		if(Input.GetMouseButton(1)) {
			Vector3 mousePos = Input.mousePosition;
			Vector2 touchPosition = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));   
			if(player.transform.position.y - touchPosition.y < 0) { //light up
				light.transform.eulerAngles = new Vector3(270, 0, 0);
				light.transform.localPosition = new Vector3(0, -0.75f, 0);
				facingDirection = new Vector2(0, 1);
			} else {
				light.transform.eulerAngles = new Vector3(90, 0, 0); //light down
				light.transform.localPosition = new Vector3(0, 0.75f, 0);
				facingDirection = new Vector2(0, -1);
			}
		}
	}
}
