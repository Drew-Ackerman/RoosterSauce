﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForestEntranceTile : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D col){
		//if player hits exit barrier, load forest
		if (col.gameObject.tag == "Player"){
			SceneManager.LoadScene ("ActDirectionalLightMaze", LoadSceneMode.Single);
		}
	}
}
