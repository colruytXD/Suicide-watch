using UnityEngine;
using System.Collections;

public class Item_Master : MonoBehaviour {

    private Inventory_Master inventoryMaster;
    public Item_List itemList;

    public int refNumber;

    public delegate void PlayerItemInteractionHandler(int refNumber, GameObject item, int inventoryIndex);

    public event PlayerItemInteractionHandler EventPickUpItem;
    public event PlayerItemInteractionHandler EventDropItem;
    public event PlayerItemInteractionHandler EventUseItemAction;

    public delegate void GeneralEventHandler();

    public event GeneralEventHandler EventItemDeath;
    public event GeneralEventHandler EventUseItem;

    public void CallEventPickupItem(int refNumber, GameObject item, int inventoryIndex)
    {
            EventPickUpItem(refNumber, item, inventoryIndex);
            item.GetComponent<Item_Master>().CallEventItemDeath();
    }

    public void CallEventDropItem(int refNumber, GameObject item, int inventoryIndex)
    {
        if(inventoryMaster.inventory[inventoryIndex] != 0)
        {
            int _refNumber = inventoryMaster.inventory[inventoryIndex];
            EventDropItem(_refNumber, item, inventoryIndex);
        }
        else
        {
            Debug.Log("Can't drop item from chosen inventory slot: Empty");
        }
    }

    public void CallEventUseItem(int refNumber, GameObject item, int inventoryIndex)
    {
        EventUseItemAction(refNumber, item, inventoryIndex);
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
