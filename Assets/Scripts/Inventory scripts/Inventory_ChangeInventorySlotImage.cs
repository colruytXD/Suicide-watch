using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory_ChangeInventorySlotImage : MonoBehaviour {

    private Inventory_Master inventoryMaster;

    void OnEnable()
    {
        SetInitialReferences();
        inventoryMaster.EventRemoveFromInventory += ChangeInventorySlotTexture;
        inventoryMaster.EventAddToInventory += ChangeInventorySlotTexture;
        ChangeInventorySlotTexture(0, null, 0);
    }

    void OnDisable()
    {
        inventoryMaster.EventRemoveFromInventory += ChangeInventorySlotTexture;
        inventoryMaster.EventAddToInventory -= ChangeInventorySlotTexture;

    }

    void SetInitialReferences()
    {
        inventoryMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory_Master>();
    }

    //Checks the inventory and updates all the inventory slots in UI
    void ChangeInventorySlotTexture(int SelectedIndex, GameObject item, int refNumber)
    {
        for (int i = 0; i < inventoryMaster.maxInventoryCount; i++)
        {
            if (inventoryMaster.inventory[i] == null)
            {
                inventoryMaster.inventorySlots[i].sprite = null;
                inventoryMaster.inventorySlots[i].color = new Color(0, 0, 0, 0);
            }
            else
            {
                Sprite wantedSprite = inventoryMaster.inventory[i].GetComponent<Item_Master>().itemIcon;
                inventoryMaster.inventorySlots[i].sprite = wantedSprite;
                inventoryMaster.inventorySlots[i].color = new Color(255, 255, 255, 100);
            }
        }
    }
}
