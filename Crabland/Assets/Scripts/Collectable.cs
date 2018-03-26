using UnityEngine;
using System.Collections;

/// <summary>
/// A collectable represents an object that the player will pickup. 
///
/// </summary>
[System.Serializable]
public class Collectable{
    public GameObject itemName;
    public bool isCollected = false;
    public Sprite itemSprite = null;
    public Rigidbody2D collectableRigidBody = null;
    public Collider2D collectableCollider = null;
}
