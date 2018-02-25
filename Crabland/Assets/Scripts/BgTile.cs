using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgTile : MonoBehaviour {

	public void changeToTile(BgTile newTile){
		gameObject.GetComponent<SpriteRenderer>().sprite = newTile.GetComponent<SpriteRenderer>().sprite;
	}
}
