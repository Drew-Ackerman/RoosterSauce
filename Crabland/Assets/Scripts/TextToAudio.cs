﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextToAudio : MonoBehaviour {
	//public AudioSource tts;

	public void Read() {
		Debug.Log("reading");
		TTSManager.Speak("I can hear the towels from your closet waiting for reconfort.", true);
	}
}
