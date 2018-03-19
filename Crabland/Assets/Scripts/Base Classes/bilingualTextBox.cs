using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class bilingualTextBox : MonoBehaviour, IPointerClickHandler {
	public string englText, thaiText;
	public bool textToggle = false;

	Text text;

	public void Awake() {
		text = GetComponent<Text> ();
	}

	//simple toggle between texts
	public void OnPointerClick(PointerEventData p){
		if(textToggle)
			text.text = englText;
		else
			text.text = thaiText;
		textToggle = !textToggle;
	}
}
