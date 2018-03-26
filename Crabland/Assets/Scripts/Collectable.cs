using UnityEngine;
using System.Collections;

[System.Serializable]
public class Collectable{
    public GameObject itemName;
    public bool isCollected = false;
    public Sprite itemSprite = null;
    public Rigidbody2D collectableRigidBody = null;
    public Collider2D collectableCollider = null;
}
