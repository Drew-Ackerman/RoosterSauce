using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Directional Light Maze Game Manager
public class GameManager : MonoBehaviour {
	GameObject directionalLight;
	GameObject player;

	void Start(){
		directionalLight = GameObject.Find("Directional light");
		player = GameObject.Find("Player");
	}

	void Update(){
		//get voice input from device
		//parse word, if word is Up, Down, Left, Right clear that overlay
		if(Input.GetMouseButton(1)) {
			Vector3 mousePos = Input.mousePosition;
			Vector2 touchPosition = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));   
			Debug.Log("Right Click at X: " + touchPosition.x + " Y: " + touchPosition.y);
			if(player.transform.position.y - touchPosition.y < 0)
				directionalLight.transform.eulerAngles = new Vector3(270, 0, 0);
			else
				directionalLight.transform.eulerAngles = new Vector3(90, 0, 0);
		}
	}
}
