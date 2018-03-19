using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* TODO
 * UI elements need to be further adjusted to fit any screen size. All displayed objects need to be
 * made proportionally scaled to the Screen.width / Screen.height
 */

public class loadDialogue : MonoBehaviour {

	public GameObject textDialog2;

	public void Awake() {
		textDialog2.SetActive (false);
	}

	//a function that when passed a number will display the coded text, and 2 sprites in a dialogue view
	public void showDialogue(int dialogueChoice){
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		player.GetComponent<PlayerController> ().moveActive = false;

		switch (dialogueChoice){
		case 1: 
			if (textDialog2 == null) {
				Debug.Log ("Missing TextDialog2");
				return;
			}

			textDialog2.SetActive (true);
			break;
//			//when dialogue starts, stop player movement. After dialogue completion, set back to true
//			GameObject canvas = GameObject.Find ("Canvas");
//
//			GameObject dialogueBox = (GameObject)Instantiate (Resources.Load ("UITextBox"));
//			RectTransform rt = (RectTransform)dialogueBox.transform;
//			//fit dialoguebox view to any view size
//			dialogueBox.transform.localScale = new Vector3 (1 * (Screen.width / rt.rect.width), 1 * (Screen.height * .4f / rt.rect.height), 0);
//			dialogueBox.transform.SetParent (canvas.transform);
//			dialogueBox.GetComponent<RectTransform> ().localPosition = new Vector3 (0, -220, 0);
//
//			GameObject left = (GameObject)Instantiate (Resources.Load ("DialogueSprites/UIPlayer"));
//			left.transform.SetParent (dialogueBox.transform);
//			left.transform.Translate (new Vector3 (150, 400, 0));
//
//			GameObject right = (GameObject)Instantiate (Resources.Load ("DialogueSprites/UITreasureBlue"));
//			right.transform.SetParent (dialogueBox.transform);
//			right.transform.Translate (new Vector3 (1130, 400, 0));
//
//			//maybe text can be arranged into sentence objects to be loaded? Need to be mindful of size
//			GameObject[] tex = new GameObject[4];
//			tex [0] = (GameObject)Instantiate (Resources.Load ("TextObjects/TextOb_test"));
//			tex [1] = (GameObject)Instantiate (Resources.Load ("TextObjects/TextOb_text"));
//			tex [2] = (GameObject)Instantiate (Resources.Load ("TextObjects/TextOb_on"));
//			tex [3] = (GameObject)Instantiate (Resources.Load ("TextObjects/TextOb_screen"));
//			for (int i = 0; i < tex.Length; ++i) {
//				tex [i].transform.SetParent (dialogueBox.transform);
//				tex [i].transform.Translate (new Vector3 (150 + (150 * i), 200, 0));
//			}
//
//			GameObject exitButton = (GameObject)Instantiate (Resources.Load ("UIButton"));
//
//			break;
		}
	}

}
