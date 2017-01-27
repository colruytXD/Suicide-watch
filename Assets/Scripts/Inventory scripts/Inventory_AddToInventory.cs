using UnityEngine;
using System.Collections;

public class Inventory_AddToInventory : MonoBehaviour {

    private Inventory_Master inventoryMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        inventoryMaster.EventAddToInventory += AddToInventory;
	}

	void OnDisable() 
	{
        inventoryMaster.EventAddToInventory += AddToInventory;
	}

	void SetInitialReferences() 
	{
        inventoryMaster = GetComponent<Inventory_Master>();
	}

    //Changes an index of the inventory to the item's refNumber
    void AddToInventory(int selectedIndex, GameObject item,  int refNumber)
    {
        if(inventoryMaster.inventory[0] == null)
        {
            inventoryMaster.inventory[0] = item;
        }
        else if(inventoryMaster.inventory[1] == null)
        {
            inventoryMaster.inventory[1] = item;
        }        
    }
}
