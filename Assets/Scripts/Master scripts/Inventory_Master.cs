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
    public List<GameObject> inventory = new List<GameObject>();

    public delegate void GeneralEventHandler(int selectedIndex, GameObject item,  int refNumber);

    public event GeneralEventHandler EventRemoveFromInventory;
    public event GeneralEventHandler EventAddToInventory;

    public void CallEventRemoveFromInventory(int selectedIndex, GameObject item)
    {
        isInventoryFull = false;
        GameObject removedItem = inventory[selectedIndex];
        EventRemoveFromInventory(selectedIndex, removedItem, 0);
        print("Removing " + selectedIndex + " index from inventory");
    }

    public void CallEventAddToInventory(int selectedIndex, GameObject item, int refNumber)
    {

        EventAddToInventory(selectedIndex, item,  refNumber);
        if (inventory[0] != null && inventory[1] != null)
        {
            isInventoryFull = true;
        }
    }
}
