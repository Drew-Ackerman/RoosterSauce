using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoscript : MonoBehaviour
{


    public SentanceList sentance;
    // Use this for initialization
    void Start()
    {
            Debug.Log(sentance.sentanceList.Count);
            Debug.Log(sentance.sentanceList[0].sentance);
    }

    // Update is called once per frame
    void Update()
    {

    }

   

}
