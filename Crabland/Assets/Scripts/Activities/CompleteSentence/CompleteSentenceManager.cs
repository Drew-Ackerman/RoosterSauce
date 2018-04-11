using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteSentenceManager : MonoBehaviour {
	public string item1, item2, item3;
	public GameObject selected;

	private int questionNum = 1;

	//player must finish the sentence with the word of the item to be grabbed.
	//ex 'Uncle, I found the [watermelon, the hat, and the trumpet]'
	//receive items from main forest item selection

	void Start() {
		item1 = "Apple";
		item2 = "Trumpet";
		item3 = "Hat";
		TTSManager.Initialize(transform.name, "OnTTSInit");

		GameObject ButtonsHead = GameObject.Find("SelectionItemButtons");
		Button b1 = ButtonsHead.transform.GetChild(0).GetComponent<Button>();
		b1.onClick.RemoveAllListeners();
		b1.onClick.AddListener(delegate {speakItem(b1.GetComponentInChildren<Text>().text);});

		Button b2 = ButtonsHead.transform.GetChild(1).GetComponent<Button>();
		b2.onClick.RemoveAllListeners();
		b2.onClick.AddListener(delegate {speakItem(b2.GetComponentInChildren<Text>().text);});

		Button b3 = ButtonsHead.transform.GetChild(2).GetComponent<Button>();
		b3.onClick.RemoveAllListeners();
		b3.onClick.AddListener(delegate {speakItem(b3.GetComponentInChildren<Text>().text);});

		Button b4 = ButtonsHead.transform.GetChild(3).GetComponent<Button>();
		b4.onClick.RemoveAllListeners();
		b4.onClick.AddListener(delegate {speakItem(b4.GetComponentInChildren<Text>().text);});
	}

	//check if correct button is selected
	public void checkItem(string itemToCheck) {
		if(itemToCheck == item1 || itemToCheck == item2 || itemToCheck == item3) {
			speakItem(itemToCheck);
		}
	}

	//pass the string to this function to read the item out loud
	public void speakItem(string itemToSpeak) {
		TTSManager.Speak(itemToSpeak, true, TTSManager.STREAM.Music, 1f, 0f, transform.name);
		if(itemToSpeak == item1 || itemToSpeak == item2 || itemToSpeak == item3) {		
			if (questionNum == 1){

				GameObject ButtonsHead = GameObject.Find("SelectionItemButtons");
				Button b1 = ButtonsHead.transform.GetChild(0).GetComponent<Button>();
				b1.GetComponentInChildren<Text>().text = "Water";
				b1.onClick.RemoveAllListeners();
				b1.onClick.AddListener(delegate {speakItem(b1.GetComponentInChildren<Text>().text);});

				Button b2 = ButtonsHead.transform.GetChild(1).GetComponent<Button>();
				b2.GetComponentInChildren<Text>().text = "Trumpet";
				b2.onClick.RemoveAllListeners();
				b2.onClick.AddListener(delegate {speakItem(b2.GetComponentInChildren<Text>().text);});

				Button b3 = ButtonsHead.transform.GetChild(2).GetComponent<Button>();
				b3.GetComponentInChildren<Text>().text = "Crayon";
				b3.onClick.RemoveAllListeners();
				b3.onClick.AddListener(delegate {speakItem(b3.GetComponentInChildren<Text>().text);});

				Button b4 = ButtonsHead.transform.GetChild(3).GetComponent<Button>();
				b4.GetComponentInChildren<Text>().text = "Salad";
				b4.onClick.RemoveAllListeners();
				b4.onClick.AddListener(delegate {speakItem(b4.GetComponentInChildren<Text>().text);});

				questionNum++;
			} else if (questionNum == 2){

				GameObject ButtonsHead = GameObject.Find("SelectionItemButtons");
				Button b1 = ButtonsHead.transform.GetChild(0).GetComponent<Button>();
				b1.GetComponentInChildren<Text>().text = "Chair";
				b1.onClick.RemoveAllListeners();
				b1.onClick.AddListener(delegate {speakItem(b1.GetComponentInChildren<Text>().text);});

				Button b2 = ButtonsHead.transform.GetChild(1).GetComponent<Button>();
				b2.GetComponentInChildren<Text>().text = "Smile";
				b2.onClick.RemoveAllListeners();
				b2.onClick.AddListener(delegate {speakItem(b2.GetComponentInChildren<Text>().text);});

				Button b3 = ButtonsHead.transform.GetChild(2).GetComponent<Button>();
				b3.GetComponentInChildren<Text>().text = "Hat";
				b3.onClick.RemoveAllListeners();
				b3.onClick.AddListener(delegate {speakItem(b3.GetComponentInChildren<Text>().text);});

				Button b4 = ButtonsHead.transform.GetChild(3).GetComponent<Button>();
				b4.GetComponentInChildren<Text>().text = "Top";
				b4.onClick.RemoveAllListeners();
				b4.onClick.AddListener(delegate {speakItem(b4.GetComponentInChildren<Text>().text);});

				questionNum++;
			}
		}
	}
		
	void OnTTSInit(string message) {
		
	}

}
