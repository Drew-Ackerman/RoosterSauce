using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUIManager : MonoBehaviour {

    public Canvas canvas;
    public List<GameObject> collectableCards;


	public void UpdateCard(CardInformation cardInformation)
    {
        collectableCards[cardInformation.index].GetComponentInChildren<Image>().sprite = cardInformation.sprite;
        collectableCards[cardInformation.index].GetComponentInChildren<TextMeshProUGUI>().SetText(cardInformation.name.ToUpper());
    }
}       

[System.Serializable]
public class CardInformation
{
    public int index;
    public Sprite sprite;
    public string name;

    public CardInformation(int index, Sprite sprite, string name)
    {
        this.index = index;
        this.sprite = sprite;
        this.name = name;

    }
}