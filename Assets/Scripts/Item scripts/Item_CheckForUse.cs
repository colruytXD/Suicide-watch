using UnityEngine;
using System.Collections;

public class Item_CheckForUse : MonoBehaviour {

    Inventory_Master inventoryMaster;
    Item_List itemList;

    RaycastHit hit;
    [SerializeField]
    LayerMask interactableLayer;
    [SerializeField]
    int range;

	void OnEnable() 
	{
		SetInitialReferences();
	}

	void OnDisable() 
	{

	}

	void Update() 
	{
        CheckForUse();
	}

	void SetInitialReferences() 
	{
        inventoryMaster = transform.root.GetComponent<Inventory_Master>();
        itemList = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Item_List>();
	}

    void CheckForUse()
    {
        //Checks if the currently selected slot isn't empty
        if (inventoryMaster.inventory[inventoryMaster.selectedInventorySlot] == 0) return;

        //Checks for input
        //if the currently selected slot is interactable it checks for an interactable world object --> if it found an interactable go --> call interact event on the go
        //else calls use item event
        if(Input.GetButtonDown("Interact"))
        {
            print("Trying to interact or use item");
            if(itemList.itemGOList[inventoryMaster.inventory[inventoryMaster.selectedInventorySlot] - 1].GetComponent<Item_Master>().isInteractable)
            {
                print("Item is interactable. checking raycast");
                if (Physics.Raycast(transform.position, transform.forward, out hit, range, interactableLayer))
                {
                    print("Found interactable with name: " + hit.transform.name);
                    hit.transform.GetComponent<Interactable_Master>().CallEventPlayerInteracts();
                }
            }
            else
            {
                print("Item isn't interactable. Using item");
                Item_Master itemMasterOfGO;
                itemMasterOfGO =  itemList.itemGOList[inventoryMaster.inventory[inventoryMaster.selectedInventorySlot] - 1].GetComponent<Item_Master>();
            }
        }
    }
}
