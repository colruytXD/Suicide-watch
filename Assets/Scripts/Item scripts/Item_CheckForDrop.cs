using UnityEngine;
using System.Collections;

public class Item_CheckForDrop : MonoBehaviour {

    private Item_Master itemMaster;
    private Inventory_Master inventoryMaster;

	void OnEnable() 
	{
		SetInitialReferences();
	}

	void Update() 
	{
        CheckForDrop();
	}

	void SetInitialReferences() 
	{
        itemMaster = GetComponent<Item_Master>();
        inventoryMaster = GetComponent<Inventory_Master>();
	}

    //Checks for input => calls Drop Item Event.
    void CheckForDrop()
    {
        if(Input.GetButtonDown("Drop item"))
        {
            itemMaster.CallEventDropItem(0, null, 0);
            inventoryMaster.CallEventRemoveFromInventory(inventoryMaster.selectedInventorySlot);
        }
    }
}
