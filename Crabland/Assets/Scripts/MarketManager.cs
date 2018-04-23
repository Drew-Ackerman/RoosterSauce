using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MarketManager : MonoBehaviour {

	[SerializeField]
	private GameObject[] targetPrefabs;
	private GameObject[] targets;

	[SerializeField]
	private Text[] text;
	[SerializeField]
	private Text[] winText;
	[SerializeField]
	private GameObject[] winImage;
	[SerializeField]
	private GameObject correctTarget;
	[SerializeField]
	private GameObject correctTarget1;
	[SerializeField]
	private GameObject correctTarget2;
	[SerializeField]
	private GameObject correctTarget3;
	[SerializeField]
	private GameObject correctTarget4;
	[SerializeField]
	public Transform[] spawnLocations;
	[SerializeField]
	public ArrayList spawnLocationsList = new ArrayList();

	public int currentRound = 0;

	public Text scoreText;
	public int score;



	//Transform randomLocation = spawnLocations [Random.Range (0, spawnLocations.Length)];

	void Start (){
		score = 0;
		targets = new GameObject[targetPrefabs.Length];
		spawnTarget ();


		text [0].GetComponent<Text> ().enabled = true;

		for (int i = 1; i < 6; i++) {
			text [i].GetComponent<Text> ().enabled = false;
		}
		for (int i = 0; i < 5; i++) {
			winText [i].GetComponent<Text> ().enabled = false;
		}
		  
	}

	void Update () {
		scoreText.text = "Score: " + score.ToString ();

	}

	void spawnTarget() {
		spawnLocations.Shuffle ();

//		for (int i = 0; i < 8; i++) {
//			spawnLocationsList.Add (spawnLocations [i]);
//		}

//		for (int i = 0; i <= spawnLocationsList.Count; i++) {
//			var randomLocation = (Transform)spawnLocationsList[Random.Range (0, spawnLocationsList.Count)];
//			targets[i] = Instantiate (targetPrefabs [Random.Range (0, targetPrefabs.Length)], randomLocation);
//
//			spawnLocationsList.Remove (randomLocation);
//		}
		for (int i = 0; i < spawnLocations.Length - 1; i++) {
			targets [i] = Instantiate (targetPrefabs [i], spawnLocations [i]);
		}

//		Instantiate (correctTarget, (Transform)spawnLocationsList[Random.Range (0, spawnLocationsList.Count)]);
//		Instantiate (correctTarget, spawnLocations[spawnLocations.Length - 1]);
//		correctTarget.GetComponent<CorrectTarget> ().marketManager = this;

		if (currentRound == 0) {
			correctTarget.GetComponent<CorrectTarget> ().marketManager = this;
			Instantiate (correctTarget, spawnLocations[spawnLocations.Length - 1]);
		} 
		else if (currentRound == 1) {
			correctTarget1.GetComponent<CorrectTarget1> ().marketManager = this;
			Instantiate (correctTarget1, spawnLocations[spawnLocations.Length - 1]);
		} 
		else if (currentRound == 2) {
			correctTarget2.GetComponent<CorrectTarget2> ().marketManager = this;
			Instantiate (correctTarget2, spawnLocations[spawnLocations.Length - 1]);
		} 
		else if (currentRound == 3) {
			correctTarget3.GetComponent<CorrectTarget3> ().marketManager = this;
			Instantiate (correctTarget3, spawnLocations[spawnLocations.Length - 1]);
		} 
		else if (currentRound == 4) {
			correctTarget4.GetComponent<CorrectTarget4> ().marketManager = this;
			Instantiate (correctTarget4, spawnLocations[spawnLocations.Length - 1]);
		} 
		else{Debug.Log ("gameover");}




	}

	public void shotCorrectTarget()
	{
		score += 5;
		foreach (var target in targets) {
			Destroy(target);
		}
		currentRound += 1;

		text[currentRound - 1].enabled = false;
		winText[currentRound - 1].enabled = true;
		winImage[currentRound-1].SetActive(true);

		StartCoroutine ("RespawnPickup"); 
//		text [currentRound].enabled = true; 
//
//		if (timeLeft <= 0) {
//			if (currentRound < 5) {
//				spawnTarget ();
//			} else {
//				SceneManager.LoadScene ("Forest");
//			}
//		}
	}

	IEnumerator RespawnPickup() {
		yield return new WaitForSeconds (5);
		winText [currentRound - 1].enabled = false;
		winImage[currentRound-1].SetActive(false);

		text [currentRound].enabled = true; 

			if (currentRound < 5) {
				spawnTarget ();
			} else {
				
				SceneManager.LoadScene ("Forest");
			}
	}

	public void PickupLooted () {
		StartCoroutine ("RespawnPickup");
	}

}
	//public Transform [] spawnPoints;
//	// Use this for initialization
//	public GameObject correctAnswer;
//	public int score;
//
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//		
//	}
//
//		
//
//	}
//}

//the player is asked to shoot correct object ie: "shoot the red apple"
//once correct object is shot, it disappears and a new challenge comes to view
//this happens 5 times
//perfect score is 25 pts
//gets 5 points for correct answer, -2 for incorrect
//spawn correct object and 4 random incorrect ones. (will needs to be implemented in different script. 

static class RandomExtensions
{
	public static void Shuffle<T> (this T[] array)
	{
		int n = array.Length;
		while (n > 1) 
		{
			int k = Random.Range (0, n--);
			T temp = array[n];
			array[n] = array[k];
			array[k] = temp;
		}
	}
}