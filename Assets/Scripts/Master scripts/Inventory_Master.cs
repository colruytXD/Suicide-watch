using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory_Master : MonoBehaviour
{
    [SerializeField]
    public Image[] inventorySlots;
    [SerializeField]
    public Image[] inventoryPanels;

    [Space(10)]

    public int selectedInventorySlot = 0;
    public int maxInventoryCount = 2;
    public bool isInventoryFull = false;

    [Space(10)]

    //List that contains all the items refNumbers currently in the inventory
    public List<int> inventory = new List<int>();

    public delegate void GeneralEventHandler(int selectedIndex, int refNumber);

    public event GeneralEventHandler EventRemoveFromInventory;
    public event GeneralEventHandler EventAddToInventory;

    public void CallEventRemoveFromInventory(int selectedIndex)
    {
        isInventoryFull = false;
        EventRemoveFromInventory(selectedIndex, 0);
        print("Removing " + selectedIndex + " index from inventory");
    }

    public void CallEventAddToInventory(int selectedIndex, int refNumber)
    {
        if (inventory[0] != 0 && inventory[1] != 0)
        {
            isInventoryFull = true;
            return;
        }

        EventAddToInventory(selectedIndex, refNumber); 
    }
}
