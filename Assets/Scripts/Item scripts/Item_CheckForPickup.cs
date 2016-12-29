using UnityEngine;
using System.Collections;

public class Item_CheckForPickup : MonoBehaviour {

    private RaycastHit hit;
    [SerializeField]
    private LayerMask itemLayer;
    [SerializeField]
    private float pickupRange;

    private Item_Master itemMaster;

    void Start()
    {
        SetInitialReferences();
    }

    void SetInitialReferences()
    {
        itemMaster = transform.root.GetComponent<Item_Master>();
    }

	void Update() 
	{
        CheckForItem();
	}

    //Checks when player wants to pick up item
    //Checks raycast for item
    //Calls pickup item event
    void CheckForItem()
    {
        if(Input.GetButtonDown("Pickup item"))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.red, 5f);
            if(Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, itemLayer))
            {
                Debug.Log("Picked up: " + hit.transform.name);
                if(hit.transform.root.GetComponent<Item_Master>() != null)
                {
                    Item_Master thisItem = hit.transform.GetComponent<Item_Master>();                    
                    itemMaster.CallEventPickupItem(thisItem.refNumber, hit.transform.gameObject, 0);
                }
            }
        }
    }
}
