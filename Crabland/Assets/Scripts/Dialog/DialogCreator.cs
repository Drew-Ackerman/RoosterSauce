using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class DialogCreator : MonoBehaviour {

    public TextMeshProUGUI textMeshProUGUI;
    public WordList wordList;

    public string currentDialog = "";
    public List<Word> currentWordList = new List<Word>();


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateDialog()
    {
        for (int i = 0; i < currentWordList.Count; i++)
        {
            if (currentWordList[i].isEnglish)
            {
                currentDialog += currentWordList[i].englishText;
                currentDialog += " ";
            }
            else
            {
                currentDialog += currentWordList[i].thaiText;
            }
        }

    }

    void ClearDialog()
    {
        textMeshProUGUI.SetText(string.Empty);
        currentDialog = string.Empty;
    }

    void ParseSentanceIntoWords(string dialog)
    {
        currentWordList.Clear();

        string[] words = dialog.Split(' '); //Split it up into individual strings.

        foreach (string word in words) //Lets go one word at a time now
        {
            for (int j = 0; j < wordList.wordList.Count; j++) //Loop through the wordList. Search for a word in wordlist that matches word
            {
                if (word.Equals(wordList.wordList[j].englishText, StringComparison.OrdinalIgnoreCase)) //if they match
                {
                    currentWordList.Add(wordList.wordList[j]); //copy the wordlist word object into the dialogs list of words.
                }
            }
        } //done with all the words from the split sentance
    }

    void PrintDialog(string dialog)
    {
        ParseSentanceIntoWords(dialog);
        ClearDialog();
        CreateDialog();
        textMeshProUGUI.SetText(currentDialog);
    }

    public void SpeakDialog(Sentance dialog)
    {
        GetComponent<AudioSource>().clip = dialog.englishAudio;
        GetComponent<AudioSource>().Play();
    }
}
