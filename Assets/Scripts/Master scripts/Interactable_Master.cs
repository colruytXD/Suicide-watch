using UnityEngine;
using System.Collections.Generic;

public class Interactable_Master : MonoBehaviour {

    public List<GameObject> requiredItems = new List<GameObject>();

    private Inventory_Master inventoryMaster;

    public delegate void GeneralEventHandler();

    public event GeneralEventHandler EventPlayerInteracts;

    public void CallEventPlayerInteracts()
    {
        int amountOfRightItems = 0;

        for(int i = 0; i < 2; i++)
        {
            for(int x = 0; x < requiredItems.Count; x++)
            {
                if(inventoryMaster.inventory[i] == requiredItems[x])
                {
                    amountOfRightItems++;

                    inventoryMaster.CallEventRemoveFromInventory(i, null);
                }
            }
        }

        if(amountOfRightItems == requiredItems.Count)
        {
            EventPlayerInteracts();
        }
    }

    void OnEnable()
    {
        inventoryMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory_Master>();
    }
}
