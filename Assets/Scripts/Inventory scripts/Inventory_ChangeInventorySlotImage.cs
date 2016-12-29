﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory_ChangeInventorySlotImage : MonoBehaviour {

    private Item_List itemList;

    [SerializeField]
    private Image[] inventorySlots;

    private Inventory_Master inventoryMaster;
    private Item_Master itemMaster;

    void OnEnable()
    {
        SetInitialReferences();
        itemMaster.EventPickUpItem += ChangeInventorySlotTexture;
        itemMaster.EventDropItem += ChangeInventorySlotTexture;
        ChangeInventorySlotTexture(0, null, 0);
    }

    void OnDisable()
    {
        itemMaster.EventPickUpItem -= ChangeInventorySlotTexture;
        itemMaster.EventDropItem += ChangeInventorySlotTexture;
    }

    void SetInitialReferences()
    {
        inventoryMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory_Master>();
        itemMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Item_Master>();
        itemList = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Item_List>();
    }

    //Checks the inventory and updates all the inventory slots in UI
    void ChangeInventorySlotTexture(int refNumber, GameObject item, int inventoryIndex)
    {
        for (int i = 0; i < inventoryMaster.maxInventoryCount; i++)
        {
            if (inventoryMaster.inventory[i] == 0)
            {
                inventorySlots[i].sprite = null;
                inventorySlots[i].color = new Color(0, 0, 0, 0);
            }
            else
            {
                int wantedRefnumber = inventoryMaster.inventory[i];
                Sprite wantedSprite = itemList.itemImageList[wantedRefnumber - 1];
                inventorySlots[i].sprite = wantedSprite;
                inventorySlots[i].color = new Color(255, 255, 255, 100);
            }
        }
    }
}
