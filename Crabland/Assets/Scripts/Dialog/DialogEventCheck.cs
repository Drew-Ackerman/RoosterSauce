using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogEventCheck : MonoBehaviour {

    public DialogEventHandler TextEventHandler;

    void OnEnable()
    {
        if (TextEventHandler != null)
        {
            TextEventHandler.onCharacterSelection.AddListener(OnCharacterSelection);
            TextEventHandler.onWordSelection.AddListener(OnWordSelection);
            TextEventHandler.onLineSelection.AddListener(OnLineSelection);
        }
    }


    void OnDisable()
    {
        if (TextEventHandler != null)
        {
            TextEventHandler.onCharacterSelection.RemoveListener(OnCharacterSelection);
            TextEventHandler.onWordSelection.RemoveListener(OnWordSelection);
            TextEventHandler.onLineSelection.RemoveListener(OnLineSelection);
        }
    }


    void OnCharacterSelection(char c, int index)
    {
        Debug.Log("Character [" + c + "] at Index: " + index + " has been selected.");
    }

    void OnWordSelection(string word, int firstCharacterIndex, int length)
    {
        Debug.Log("Word [" + word + "] with first character index of " + firstCharacterIndex + " and length of " + length + " has been selected.");
        FindObjectOfType<DialogManager>().SendMessage("WordClicked", word);

    }

    void OnLineSelection(string lineText, int firstCharacterIndex, int length)
    {
        Debug.Log("Line [" + lineText + "] with first character index of " + firstCharacterIndex + " and length of " + length + " has been selected.");
    }

}