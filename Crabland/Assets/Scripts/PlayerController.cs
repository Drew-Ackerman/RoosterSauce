using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public bool moveActive = true;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update() {
		if(moveActive) {
			if(Input.touchCount > 0) {
				Touch touch = Input.GetTouch(0);
				//either touch is persistent, or moving
				if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
					// If the finger is on the screen, move the object smoothly to the touch position
					Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));                
					transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime);
				}
			}
			if(Input.GetMouseButton(0)) {
				Vector3 mousePos = Input.mousePosition;
				//reduced to vector 2, vec 3 moved player unpredictably up or down
				Vector2 touchPosition = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));                
				transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime);
			}
		}
	}
}
