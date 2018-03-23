using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[CustomEditor(typeof(TextGenerator))]
public class TextGenerator : MonoBehaviour {

	[System.Serializable]
	public struct Word {
		public string english;
		public string thai;
	}

	Word[] words;
	public string englishText;
	public string thaiTranslation;
	public GameObject uiWordPrefab;

	void Awake() {
	}

	public void MakeText() {
		bilingualTextBox firstBilingualTextBox;
		if (firstBilingualTextBox = transform.GetComponentInChildren<bilingualTextBox>()) {
			DestroyImmediate (firstBilingualTextBox.gameObject);
		}

		var englishWords = englishText.Split ('|');
		var thaiWords = thaiTranslation.Split('|');
		words = new Word [englishWords.Length];
		for (var i = 0; i < englishWords.Length; i++) {
			words [i].english = englishWords [i];
			words [i].thai = thaiWords [i];
		}

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

		if (firstBilingualTextBox = transform.GetComponentInChildren<bilingualTextBox>())
		{
			var rectTransform = firstBilingualTextBox.gameObject.GetComponent<RectTransform> ();
			rectTransform.anchorMax = new Vector2 (0, 1);
			rectTransform.anchorMin = new Vector2 (0, 1);
			rectTransform.anchoredPosition = new Vector2 (50, -20);
		}
	}
}
