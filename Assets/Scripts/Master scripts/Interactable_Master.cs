using UnityEngine;
using System.Collections.Generic;

public class Interactable_Master : MonoBehaviour {

    public List<int> requiredItemsRefNumbers = new List<int>();

    private Inventory_Master inventoryMaster;

    public delegate void GeneralEventHandler();

    public event GeneralEventHandler EventPlayerInteracts;

    public void CallEventPlayerInteracts()
    {
        print("Player tried interacting. checking inventory");
        int amountOfRightItems = 0;

        for(int i = 0; i < 2; i++)
        {
            for(int x = 0; x < requiredItemsRefNumbers.Count; x++)
            {
                print("doing inventory slot " + i);
                if(inventoryMaster.inventory[i] == requiredItemsRefNumbers[x])
                {
                    amountOfRightItems++;

                    inventoryMaster.CallEventRemoveFromInventory(i);
                }
            }
        }

        if(amountOfRightItems == requiredItemsRefNumbers.Count)
        {
            EventPlayerInteracts();
        }
    }

    void OnEnable()
    {
        inventoryMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory_Master>();
    }
}
