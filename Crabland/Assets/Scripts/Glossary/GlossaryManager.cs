using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryManager : MonoBehaviour {
	public CollectableLocationList collectables;
	private float vertOffset, horzOffset = 1.2f;
	private int initX = -7;
	private int initY = 2;
	// Use this for initialization
	void Start () {
		for(int j = 0; j < collectables.collectableLocationList.Count; ++j) {
			for(int i = 0; i < collectables.collectableLocationList[j].PossibleSprites.Count; ++i) {
				GameObject sp = new GameObject();
				sp.AddComponent<SpriteRenderer>().sprite = collectables.collectableLocationList[j].PossibleSprites[i];
				sp.transform.SetPositionAndRotation(new Vector3(initX + (horzOffset * i), initY, 0), Quaternion.identity);
			}
			initY -= 2;
		}
	}

}
