using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//call this function with 2 gameobjects to be shown in a dialogue view
public class loadDialogue : MonoBehaviour {
	public GameObject left, right;

	public void showDialogue(){
		GameObject canvas = GameObject.Find("Canvas");
		GameObject dialogue = (GameObject)Instantiate(Resources.Load("UITextBox"));
		dialogue.transform.SetParent(canvas.transform);
		dialogue.GetComponent<RectTransform>().localPosition = new Vector3(0, -220, 0);
	}

}
