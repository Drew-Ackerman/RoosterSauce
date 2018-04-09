using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour {
//
//	public Transform spriteTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Input.mousePosition;
		//reduced to vector 2, vec 3 moved player unpredictably up or down
		Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));  
		Vector2 d = touchPosition - transform.position;
		float angle = Mathf.Atan2 (d.y, d.x);
		angle = Mathf.Rad2Deg * angle;
		var scale = transform.localScale;
		if (angle > 90 || angle < -90) {
			scale.x = -1f;
			angle -= 180;
		} else {
			scale.x = 1f;
		}
		transform.localScale = scale;
		Debug.Log (angle);
		var rotation = transform.rotation;
		var angles = rotation.eulerAngles;
		angles.z = angle;
		rotation.eulerAngles = angles;
		transform.rotation = rotation;

		if(Input.GetMouseButton(1)) {
			// Shoot
		}
	}
}
