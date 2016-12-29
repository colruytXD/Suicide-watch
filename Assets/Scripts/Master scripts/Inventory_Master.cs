using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory_Master : MonoBehaviour
{
    public int maxInventoryCount = 2;

    //List that contains all the items refNumbers currently in the inventory
    public List<int> inventory = new List<int>();
}
