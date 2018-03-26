using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour {

    public GameObject collector;    //The object that will pickup collectables
    public LayerMask collisionLayer;//The collision layer to raycast onto to find collectables.
    public int pickupRadius;        //The pickup radius of the raycast. 

    public List<CollectableLocation> possibleLocations;//A list of CollectableLocations 
    public List<GameObject> selectedCollectables;      //A list of the collectables that the collectable Manager creates. 

    public GameObject collectablePrefab;               //The prefab used to create collectable GameObjects. 

    // Use this for initialization
    void Start() {
        GenerateItems();
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate()
    {
        RaycastHit2D hitObject = Physics2D.CircleCast(this.transform.position, pickupRadius, Vector2.up, pickupRadius, collisionLayer);
        if (hitObject)
        {
            Collider2D collider = hitObject.collider;

        }
    }
     
    // Generates the collectables for each location. 
    public void GenerateItems()
    {
        foreach(CollectableLocation location in possibleLocations)
        {
            foreach(Vector3 possibleLocation in location.PossibleLocations)
            {
                if (possibleLocation != Vector3.zero)
                {
                    int selectedIndex = (int)(Mathf.Floor(Random.Range(0, location.PossibleSprites.Count)));
                    Sprite selectedSprite = location.PossibleSprites[selectedIndex];
                    location.PossibleSprites.RemoveAt(selectedIndex);

                    GameObject collectable = Instantiate<GameObject>(collectablePrefab);
                    collectable.transform.parent = gameObject.transform;
                    collectable.GetComponent<SpriteRenderer>().sprite = selectedSprite;
                    collectable.GetComponent<Transform>().Translate(possibleLocation);
                    collectable.name = collectable.GetComponent<SpriteRenderer>().sprite.name;


                    selectedCollectables.Add(collectable);

                   
                }
            }
        }
    }

    public void GenerateItem()
    {
     
    }

}
