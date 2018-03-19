using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour {

	[System.Serializable]
	public struct Word {
		public string english;
		public string thai;
	}

	public Word[] words;
	public GameObject uiWordPrefab;

	void Awake() {
		Transform previousTransform = transform;
		foreach (Word word in words) 
		{
			GameObject uiWord = (GameObject)Instantiate(uiWordPrefab, previousTransform);
			bilingualTextBox textBox = uiWord.GetComponent<bilingualTextBox> ();
			textBox.englText = word.english;
			textBox.thaiText = word.thai;
			uiWord.GetComponent<Text>().text = word.english;
			previousTransform = uiWord.transform;
		}

		GameObject firstUIWordGameObject;
		if (firstUIWordGameObject = transform.GetComponentInChildren<bilingualTextBox>().gameObject)
		{
			var rectTransform = firstUIWordGameObject.GetComponent<RectTransform> ();
			rectTransform.anchorMax = new Vector2 (0, 1);
			rectTransform.anchorMin = new Vector2 (0, 1);
			rectTransform.anchoredPosition = new Vector2 (50, -20);
		}
	}
}
