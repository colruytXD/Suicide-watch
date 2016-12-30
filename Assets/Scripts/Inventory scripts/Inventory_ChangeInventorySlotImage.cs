using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory_ChangeInventorySlotImage : MonoBehaviour {

    private Item_List itemList;

    private Inventory_Master inventoryMaster;
    private Item_Master itemMaster;

    void OnEnable()
    {
        SetInitialReferences();
        inventoryMaster.EventRemoveFromInventory += ChangeInventorySlotTexture;
        inventoryMaster.EventAddToInventory += ChangeInventorySlotTexture;
        ChangeInventorySlotTexture(0, 0);
    }

    void OnDisable()
    {
        inventoryMaster.EventRemoveFromInventory += ChangeInventorySlotTexture;
        inventoryMaster.EventAddToInventory -= ChangeInventorySlotTexture;

    }

    void Update()
    {
        print(inventoryMaster.isInventoryFull);
    }

    void SetInitialReferences()
    {
        inventoryMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory_Master>();
        itemMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Item_Master>();
        itemList = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Item_List>();
    }

    //Checks the inventory and updates all the inventory slots in UI
    void ChangeInventorySlotTexture(int SelectedIndex, int refNumber)
    {
        print("I must change the slot texture!");
        for (int i = 0; i < inventoryMaster.maxInventoryCount; i++)
        {
            if (inventoryMaster.inventory[i] == 0)
            {
                inventoryMaster.inventorySlots[i].sprite = null;
                inventoryMaster.inventorySlots[i].color = new Color(0, 0, 0, 0);
            }
            else
            {
                int wantedRefnumber = inventoryMaster.inventory[i];
                Sprite wantedSprite = itemList.itemImageList[wantedRefnumber - 1];
                inventoryMaster.inventorySlots[i].sprite = wantedSprite;
                inventoryMaster.inventorySlots[i].color = new Color(255, 255, 255, 100);
            }
        }
    }
}
