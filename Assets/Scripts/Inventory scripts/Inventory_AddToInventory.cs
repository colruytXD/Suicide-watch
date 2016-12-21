using UnityEngine;
using System.Collections;

public class Inventory_AddToInventory : MonoBehaviour {

    private Inventory_Master inventoryMaster;
    private Item_Master itemMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        itemMaster.EventPickUpItem += AddToInventory;
	}

	void OnDisable() 
	{
        itemMaster.EventPickUpItem += AddToInventory;
	}

	void SetInitialReferences() 
	{
        inventoryMaster = GetComponent<Inventory_Master>();
        itemMaster = GetComponent<Item_Master>();
	}

    void AddToInventory(int refNumber, GameObject item)
    {
        print("Adding item to inventory with refnumber: " + refNumber);
        inventoryMaster.inventory.Add(refNumber);
    }
}
