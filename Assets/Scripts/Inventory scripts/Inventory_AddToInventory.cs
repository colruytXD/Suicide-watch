﻿using UnityEngine;
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

    //Changes an index of the inventory to the item's refNumber
    void AddToInventory(int refNumber, GameObject item, int inventoryIndex)
    {
        if(inventoryMaster.inventory[0] == 0)
        {
            inventoryMaster.inventory[0] = refNumber;
        }
        else
        {
            inventoryMaster.inventory[1] = refNumber;
        }
        
    }
}
