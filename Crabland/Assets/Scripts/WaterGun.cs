using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour {
//
//	public Transform spriteTransform;

	// Use this for initialization
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public int bulletSpeed = 10; 
	//Rigidbody2D rb;


	void Start () {
		//rb = bulletPrefab.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Input.mousePosition;
		//reduced to vector 2, vec 3 moved player unpredictably up or down
		Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));  
		Vector2 d = touchPosition - transform.position;
		float angle = Mathf.Atan2 (d.y, d.x);
		angle = Mathf.Rad2Deg * angle;
		var scale = transform.localScale;





		if (angle > 90 || angle < -90) {
			scale.x = -1f;
			angle -= 180;
		} else {
			scale.x = 1f;
		}

		transform.localScale = scale;
		//Debug.Log (angle);
		var rotation = transform.rotation;
		var angles = rotation.eulerAngles;
		angles.z = angle;
		rotation.eulerAngles = angles;
		transform.rotation = rotation;



		if(Input.GetMouseButtonDown(0)) {//Input.GetMouseButton(1)) {
			Fire();
		}

	}

	void Fire () {
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
		var rgb = bullet.GetComponent<Rigidbody2D>();
		rgb.velocity = (bullet.transform.right * bulletSpeed * transform.localScale.x);

		Destroy(bullet, 3.0f);
	}
}
