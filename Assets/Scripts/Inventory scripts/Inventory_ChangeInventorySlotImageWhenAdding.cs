using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory_ChangeInventorySlotImageWhenAdding : MonoBehaviour {

    [SerializeField]
    private Sprite[] itemTextures;
    [SerializeField]
    private Image[] inventorySlots;

    private Inventory_Master inventoryMaster;
    private Item_Master itemMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        itemMaster.EventPickUpItem += ChangeInventorySlotTexture;
	}

	void OnDisable() 
	{
        itemMaster.EventPickUpItem -= ChangeInventorySlotTexture;
	}

	void SetInitialReferences() 
	{
        inventoryMaster = GetComponent<Inventory_Master>();
        itemMaster = GetComponent<Item_Master>();
	}

    void ChangeInventorySlotTexture(int refNumber, GameObject item)
    {
        Sprite shouldBeDisplayed;

        shouldBeDisplayed = itemTextures[refNumber - 1];

        inventorySlots[inventoryMaster.inventory.Count].GetComponent<Image>().sprite = shouldBeDisplayed;
    }
}
