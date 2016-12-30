using UnityEngine;
using System.Collections;

public class Inventory_RemoveFromInventory : MonoBehaviour {

    private Inventory_Master inventoryMaster;
    private Item_Master itemMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        itemMaster.EventDropItem += RemoveFromInventory;
        itemMaster.EventUseItemAction += RemoveFromInventory;
	}

	void OnDisable() 
	{
        itemMaster.EventDropItem -= RemoveFromInventory;
        itemMaster.EventUseItemAction -= RemoveFromInventory;
	}

	void SetInitialReferences() 
	{
        inventoryMaster = GetComponent<Inventory_Master>();
        itemMaster = GetComponent<Item_Master>();
    }

    //Sets the index value to 0 (no item)
    void RemoveFromInventory(int refNumber, GameObject item, int selectedIndex)
    {
            inventoryMaster.inventory[selectedIndex] = 0;
    }
}
