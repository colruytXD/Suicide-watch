using UnityEngine;
using System.Collections.Generic;

public class Item_Master : MonoBehaviour {

    private Inventory_Master inventoryMaster;
    public Item_List itemList;

    public bool isInteractable;

    public int refNumber;

    [Space]
    public List<Component> useEffects = new List<Component>();

    public delegate void PlayerItemInteractionHandler(int refNumber, GameObject item, int selectedIndex);

    public event PlayerItemInteractionHandler EventPickUpItem;
    public event PlayerItemInteractionHandler EventDropItem;
    public event PlayerItemInteractionHandler EventUseItemAction;

    public delegate void GeneralEventHandler();

    public event GeneralEventHandler EventItemDeath;
    public event GeneralEventHandler EventUseItem;

    //If the inventory isn't full
    //add item to inventory through event on Inventory_Master
    //destroy the item in the world
    public void CallEventPickupItem(int refNumber, GameObject item, int selectedIndex)
    {
        if (!inventoryMaster.isInventoryFull)
        {
            selectedIndex = inventoryMaster.selectedInventorySlot;
            inventoryMaster.CallEventAddToInventory(0, refNumber);
            item.GetComponent<Item_Master>().CallEventItemDeath();
        }                                            
    }
    
    //if selected slot isn't empty
    //Call dropItem event
    //Call remove from inventory event
    public void CallEventDropItem(int refNumber, GameObject item, int selectedIndex)
    {
        selectedIndex = inventoryMaster.selectedInventorySlot;
        if(inventoryMaster.inventory[inventoryMaster.selectedInventorySlot] != 0)
        {
            int _refNumber = inventoryMaster.inventory[selectedIndex];
            EventDropItem(_refNumber, item, selectedIndex);
            inventoryMaster.CallEventRemoveFromInventory(selectedIndex);
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
        print(transform.name);
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
