using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour {

    public int rotationSpeed = 10;  //How quickly the compass rotates.
    public bool tracking = false;   //Are we tracking a location?
    public Transform targetLocation;//What location are we tracking?

    public int collisionRadius;     //The distance we detect locations at. Did we get close enough to the Location mark?
    public LayerMask collisionLayer;//What layers are we going to check collisions on?
    
    void Start () {

	}
	void Update () {
        if (tracking) {
            trackTarget();
        }
    }
    
    private void FixedUpdate()
    {
        RaycastHit2D hitObject = Physics2D.CircleCast(this.transform.position, collisionRadius, Vector2.up, collisionRadius, collisionLayer);
        if (hitObject)
        { 
            Collider2D collider = hitObject.collider;
            FindObjectOfType<NavigationManager>().SendMessage("locationHit", collider);
        } 
    }

    void trackTarget()
    //This is what makes the compass point towards the target it needs to get towards. 
    {
        Vector3 vectorToTarget = targetLocation.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 90;
        Quaternion rotationAngle = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * rotationSpeed);
    }
    public void setTargetLocation(Transform location)
    {
        targetLocation = location;
    }

    public void startTracking()
    {
        tracking = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void stopTracking()
    {
        tracking = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    
}

