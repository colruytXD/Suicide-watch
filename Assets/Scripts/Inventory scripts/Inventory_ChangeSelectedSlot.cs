using UnityEngine;
using System.Collections;

public class Inventory_ChangeSelectedSlot : MonoBehaviour {

    private Inventory_Master inventoryMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        ChangeSelectedInventorySlot();
	}

	void OnDisable() 
	{

	}

	void Update() 
	{
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventoryMaster.selectedInventorySlot = 0;
            ChangeSelectedInventorySlot();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventoryMaster.selectedInventorySlot = 1;
            ChangeSelectedInventorySlot();
        }
	}

	void SetInitialReferences() 
	{
        inventoryMaster = GetComponent<Inventory_Master>();
	}

    void ChangeSelectedInventorySlot()
    {
        if(inventoryMaster.selectedInventorySlot == 0)
        {
            //reset old inventory slot
            inventoryMaster.inventoryPanels[1].color = new Color(255,255,255, .1f);

            //color new inventory slot
            inventoryMaster.inventoryPanels[0].color = new Color(200, 200, 200, .2f);
        }
        else if(inventoryMaster.selectedInventorySlot == 1)
        {
            //reset old inventory slot
            inventoryMaster.inventoryPanels[0].color = new Color(255, 255, 255, .1f);

            //color new inventory slot
            inventoryMaster.inventoryPanels[1].color = new Color(200, 200, 200, .2f);
        }
    }
}
