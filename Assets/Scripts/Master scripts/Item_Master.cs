using UnityEngine;
using System.Collections;

public class Item_Master : MonoBehaviour {

    private Inventory_Master inventoryMaster;

    public int refNumber;

    public delegate void PlayerItemInteractionHandler(int refNumber, GameObject item);

    public event PlayerItemInteractionHandler EventPickUpItem;
    public event PlayerItemInteractionHandler EventDropItem;
    public event PlayerItemInteractionHandler EventUseItemAction;

    public delegate void GeneralEventHandler();

    public event GeneralEventHandler EventItemDeath;
    public event GeneralEventHandler EventUseItem;

    public void CallEventPickupItem(int refNumber, GameObject item)
    {
        print("Eventing pickup event");
        if(inventoryMaster.inventory.Count < inventoryMaster.maxInventoryCount)
        {
            EventPickUpItem(refNumber, item);
            item.GetComponent<Item_Master>().CallEventItemDeath();
        }
        else
        {
            Debug.Log("Already have the max inventory count");
        }
        
    }

    public void CallEventDropItem(int refNumber, GameObject item)
    {
        EventDropItem(refNumber, item);
    }

    public void CallEventUseItem(int refNumber, GameObject item)
    {
        EventUseItemAction(refNumber, item);
    }

    public void CallEventItemDeath()
    {
        EventItemDeath();
    }

    public void CallEventUseItem()
    {
        EventUseItem();
    }

    void OnEnable()
    {
        if(GetComponent<Inventory_Master>() != null)
        {
            inventoryMaster = GetComponent<Inventory_Master>();
        }
        else
        {
            if(GetComponent<Item_Master>().refNumber == -1)
            {
                Debug.Log("You must add a inventory master script to the player.");
            }
        }
    }

}
