using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopUp : MonoBehaviour,
    IPointerClickHandler, IPointerDownHandler, IPointerUpHandler{

    public int popUpSpeechThresh;
    public int popUpDuration;
    public bool isPointerDown = false;
    public float latestClickTime;
    public float timer;
    public Word popUpWord;

    private void OnEnable()
    {

    }
    // Use this for initialization
    void Start () {
        timer = Time.time;
        latestClickTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (isPointerDown)
        { 
            if(latestClickTime - timer > popUpSpeechThresh)
            {
                Invoke("playThaiSound", 0);
            }

        }
        if (latestClickTime - timer > popUpDuration)
        {
            Destroy(this.gameObject);
        }
        timer -= Time.deltaTime;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        latestClickTime = Time.time;
        timer = Time.time;

        Debug.Log("Beign Held Down");
        isPointerDown = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        timer = Time.time;
        isPointerDown = true;
        Debug.Log("Being Clicked");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("On Pointer Up");
        isPointerDown = false;

    }

    public void playThaiSound()
    {
        //spawn the thai sound this.GetComponentInChildren<Text>().text = popUpWord.englishText;
        GetComponent<AudioSource>().Play();
        Debug.Log("On long press");
        isPointerDown = false;
        timer = Time.time;
    }


    public void OnDestroy()
    {
        if (FindObjectOfType<PopUpManager>() != null)
        {
            FindObjectOfType<PopUpManager>().SendMessage("PopUpDestroyed");
        }
    }
}
