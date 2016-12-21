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
        itemMaster = GetComponent<Item_Master>();
    }

	void Update() 
	{
        CheckForItem();
	}

    void CheckForItem()
    {
        if(Input.GetButtonDown("Pickup item"))
        {
            if(Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, itemLayer))
            {
                if(hit.transform.GetComponent<Item_Master>() != null)
                {
                    Item_Master thisItem = hit.transform.GetComponent<Item_Master>();                    
                    itemMaster.CallEventPickupItem(thisItem.refNumber, hit.transform.gameObject);

                    print("Calling pickup item event. Picking up item with refnumber: " + thisItem.refNumber);
                }
            }
        }
    }
}
