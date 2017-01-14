using UnityEngine;
using System.Collections;

public class Inventory_RemoveFromInventory : MonoBehaviour {

    private Inventory_Master inventoryMaster;
    private Item_Master itemMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        inventoryMaster.EventRemoveFromInventory += RemoveFromInventory;
    }

	void OnDisable() 
	{
        inventoryMaster.EventRemoveFromInventory -= RemoveFromInventory;
    }

	void SetInitialReferences() 
	{
        inventoryMaster = GetComponent<Inventory_Master>();
        itemMaster = GetComponent<Item_Master>();
    }

    //Sets the index value to 0 (no item)
    public void RemoveFromInventory(int selectedIndex, GameObject item, int refNumber)
    {
            inventoryMaster.inventory[selectedIndex] = null;
    }
}
