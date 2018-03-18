using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class bilingualTextBox : MonoBehaviour, IPointerClickHandler {
	public string englText, thaiText;
	public bool textToggle = false;

	//simple toggle between texts
	public void OnPointerClick(PointerEventData p){
		if(textToggle)
			this.gameObject.GetComponent<Text>().text = englText;
		else
			this.gameObject.GetComponent<Text>().text = thaiText;
		textToggle = !textToggle;
	}
}
