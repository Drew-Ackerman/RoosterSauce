using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class areaGameManager : MonoBehaviour {
	public int health;
	private GameObject textLose, btnOkay;
	private Text livesText;
	private float xOff, yOff;
	private bool isAlive;
	// Use this for initialization
	void Start () {
		//set intial player conditions, to be placed in function
		livesText = GameObject.Find("txtLives").GetComponent<Text>();
		livesText.text = "Lives: " + health.ToString();
		isAlive = true;

		//get UI components
		textLose = GameObject.Find("txtLose");
		textLose.SetActive(false);
		btnOkay = GameObject.Find("btnOkay");
		btnOkay.SetActive(false);

		//fill area with tiles
		GameObject groundTiles = GameObject.Find("Ground Tiles");
		tilesCollection tc = groundTiles.GetComponent<tilesCollection>();

		//set initial offsets to GameObject values
		xOff = tc.xOffset;
		yOff = tc.yOffset;

		//intialize background tileset
		//row
		for(int i = 0; i < 4; ++i) {
			//col
			for(int j = 0; j < 8; ++j) {
				BgTile newTile = Object.Instantiate(tc.GetComponent<tilesCollection>().tiles[(i + j) % 2]);
				newTile.transform.Translate(
					xOff + (i * (1.28f * newTile.transform.localScale.x)),
					yOff + (j * (1.28f * newTile.transform.localScale.y)), 0);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		livesText.text = "Lives: " + health.ToString();
		if(isAlive) {
			if(health <= 0) {
				textLose.SetActive(true);
				btnOkay.SetActive(true);
				isAlive = false;
			}
		}
	}

}
