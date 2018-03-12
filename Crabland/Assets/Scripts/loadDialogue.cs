using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//call this function with 2 gameobjects to be shown in a dialogue view
//and a string to be displayed
public class loadDialogue : MonoBehaviour {
	
	public void showDialogue(int dialogueChoice){
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		switch (dialogueChoice){
		case 1: 
			//when dialogue starts, stop player movement. After dialogue completion, set back to true
			player.GetComponent<PlayerController>().moveActive = false;
			GameObject canvas = GameObject.Find("Canvas");

			GameObject dialogueBox = (GameObject)Instantiate(Resources.Load("UITextBox"));
			dialogueBox.transform.SetParent(canvas.transform);
			dialogueBox.GetComponent<RectTransform>().localPosition = new Vector3(0, -220, 0);

			GameObject left = (GameObject)Instantiate(Resources.Load("DialogueSprites/UIPlayer"));
			left.transform.SetParent(dialogueBox.transform);
			left.transform.Translate(new Vector3(150, 400, 0));

			GameObject right = (GameObject)Instantiate(Resources.Load("DialogueSprites/UITreasureBlue"));
			right.transform.SetParent(dialogueBox.transform);
			right.transform.Translate(new Vector3(1130, 400, 0));

			string dText = "The human condition";
			Text dt = GameObject.Find("textDialogue").GetComponent<Text>();
			dt.transform.SetParent(dialogueBox.transform);
			dt.text = dText.ToString();

			break;
		}
	}

}
