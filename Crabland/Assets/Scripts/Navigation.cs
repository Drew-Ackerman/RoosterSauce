using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour {

    public int rotationSpeed = 10;
    public bool tracking = false;
    public Transform targetLocation;

    public int collisionRadius;
    public LayerMask layerMask;
    
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (tracking) {
            trackTarget();
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D hitObject = Physics2D.CircleCast(this.transform.position, collisionRadius, Vector2.up, collisionRadius, layerMask);
        if (hitObject)
        {
            stopTracking();
            Collider2D collider = hitObject.collider;
            FindObjectOfType<NavigationManager>().SendMessage("locationHit", collider);
        } 
    }

    private void OnDrawGizmos()
    {

    }

    void trackTarget()
    {
        Vector3 vectorToTarget = targetLocation.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 90;
        Quaternion rotationAngle = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * rotationSpeed);
    }
    public void startTracking()
    {
        tracking = true;
         
    }

    public void stopTracking()
    {
        tracking = false;
    }
    
}

