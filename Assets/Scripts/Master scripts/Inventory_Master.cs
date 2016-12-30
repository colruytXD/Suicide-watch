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

    [Space(10)]

    //List that contains all the items refNumbers currently in the inventory
    public List<int> inventory = new List<int>();
}
