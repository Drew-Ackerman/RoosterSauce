using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour {
    
    public Queue<Sentance> dialogQueue = new Queue<Sentance>();
    public SentanceList sentanceList;
    public WordList wordList;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public GameObject dialogOverlay;

    public string selectedWord;
    public string currentDialog;
    public Sentance dialog;

    // Use this for initialization
    void Start() {
        for (int i = 0; i < sentanceList.sentanceList.Count; i++)
        {
            dialogQueue.Enqueue(sentanceList.sentanceList[i]);
        }
        wordList = Instantiate<WordList>(wordList);
        FindObjectOfType<DialogCreator>().wordList = wordList;
    }

    // Update is called once per frame
    void Update() {

    }

    private void displayDialog(string dialog)
    {
        FindObjectOfType<DialogCreator>().SendMessage("PrintDialog", dialog);
        FindObjectOfType<DialogCreator>().SendMessage("SpeakDialog", this.dialog);
    }

    public void displayNextDialog()
    {
        if (dialogQueue.Count > 0)
        {
            dialog = dialogQueue.Dequeue();
            currentDialog = dialog.sentance;
            displayDialog(dialog.sentance);
        }
    }

    public void WordClicked(string word)
    {
        word = word.ToLower();
        selectedWord = word;

        Regex reg = new Regex("[a-z]*");

        if (reg.IsMatch(word))
        {
            for (int i = 0; i < wordList.wordList.Count; i++) //Loop through the wordList. Search for a word in wordlist that matches word
            {
                if (word.Equals(wordList.wordList[i].englishText, StringComparison.OrdinalIgnoreCase)) //if they match
                {
                    FindObjectOfType<PopUpManager>().SendMessage("CreatePopUp", wordList.wordList[i]);
                }
            }
           
        }

        FindObjectOfType<DialogCreator>().SendMessage("PrintDialog", currentDialog);
    }

}


