using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour {

    public GameObject collector;    //The object that will pickup collectables
    public LayerMask collisionLayer;//The collision layer to raycast onto to find collectables.
    public int pickupRadius;        //The pickup radius of the raycast. 

    public List<GameObject> selectedCollectables;      //A list of the collectables that the collectable Manager creates. 
    public GameObject collectablePrefab;               //The prefab used to create collectable GameObjects. 
    public CollectableLocationList collectableLocations;

    // Use this for initialization
    void Start() {
        collectableLocations = Instantiate<CollectableLocationList>(collectableLocations);
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate()
    {
        RaycastHit2D hitObject = Physics2D.CircleCast(collector.transform.position, pickupRadius, Vector2.up, Mathf.Infinity, collisionLayer);

        if (hitObject)
        {
            Debug.Log(hitObject.ToString());
            Destroy(hitObject.collider.GetComponent<GameObject>());
        }
    }

    public void GenerateItemsAtLocation(string locationName)
    {
        CollectableLocation selectedCollectableLocation = PickCollectableLocation(locationName);

        if(selectedCollectableLocation == null)
        {
            return;
        }

        for(int i = 0; i < 3; i++)
        {
            Sprite selectedSprite = PickRandomSprite(selectedCollectableLocation.PossibleSprites);
            Vector3 selectedWorldLocation = PickRandomLocation(selectedCollectableLocation.PossibleLocations);

            CreateCollectable(selectedSprite, selectedWorldLocation);
            SendCollectableInfoToCardUI(new CardInformation(i, selectedSprite, selectedSprite.name));
        }

    }


    CollectableLocation PickRandomCollectableLocation()
    {
        int selectedIndex = (int)(Mathf.Floor(Random.Range(0, collectableLocations.collectableLocationList.Count)));
        CollectableLocation selectedLocation = collectableLocations.collectableLocationList[selectedIndex];

        return selectedLocation;
    }

    CollectableLocation PickCollectableLocation(string locationName)
    {
        for(int i = 0; i < collectableLocations.collectableLocationList.Count; i++)
        {
            if(collectableLocations.collectableLocationList[i].LocationName == locationName)
            {
                return collectableLocations.collectableLocationList[i];
            }
        }
        return null;
    }

    Sprite PickRandomSprite(List<Sprite> possibleSprites)
    {
        int selectedIndex = (int)(Mathf.Floor(Random.Range(0, possibleSprites.Count)));
        Sprite selectedSprite = possibleSprites[selectedIndex];
        possibleSprites.RemoveAt(selectedIndex);

        return selectedSprite;

    }

    Vector3 PickRandomLocation(List<Vector3> locations)
    {
        int selectedIndex = (int)(Mathf.Floor(Random.Range(0, locations.Count)));
        Vector3 selectedLocation = locations[selectedIndex];
        return selectedLocation;
    }

    //Create Collectable Gameobject. 
    void CreateCollectable(Sprite selectedSprite, Vector3 selectedWorldLocation)
    {
        GameObject collectable = Instantiate<GameObject>(collectablePrefab);    //Instantiate the GameObject
        collectable.transform.parent = gameObject.transform;                    //Give it a transform
        collectable.GetComponent<SpriteRenderer>().sprite = selectedSprite;     //Make the sprite the selectedSprite
        collectable.GetComponent<Transform>().Translate(selectedWorldLocation);      //Assign it a location in the gameworld
        collectable.name = collectable.GetComponent<SpriteRenderer>().sprite.name; //Give the objects name the sprites name
        return;
    }

    void SendCollectableInfoToCardUI(CardInformation cardInformation)
    {
        FindObjectOfType<CardUIManager>().SendMessage("UpdateCard", cardInformation);
    }

}

