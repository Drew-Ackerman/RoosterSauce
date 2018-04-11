using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour {

    public GameObject popUpPrefab;
    public Transform parentCanvasPosition;
    public Canvas parentCanvas;


    public GameObject createdPopUp;

    public bool popUpActive = false;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreatePopUp(Word word)
    {
        if (popUpActive == false)
        {
            createdPopUp = Instantiate(popUpPrefab, parentCanvas.GetComponent<RectTransform>().transform); //fix somehow. 
            createdPopUp.GetComponent<PopUp>().popUpWord = word;
            createdPopUp.GetComponentInChildren<Text>().text = word.thaiText;
            createdPopUp.GetComponent<AudioSource>().clip = word.thaiAudio;
            popUpActive = true;
        }
    }

    public void PopUpDestroyed()
    {
        popUpActive = false;
    }
}
