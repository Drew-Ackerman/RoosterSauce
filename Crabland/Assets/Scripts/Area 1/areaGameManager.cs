using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class areaGameManager : MonoBehaviour {
	private GameObject btnOkay;
	private Text livesText;

	// Use this for initialization
	void Start () {
		//set intial player conditions, to be placed in function

		//get UI components
		btnOkay = GameObject.Find("btnOkay");
		btnOkay.SetActive(false);

	}

	// Update is called once per frame
	void Update () {
		
	}

}
