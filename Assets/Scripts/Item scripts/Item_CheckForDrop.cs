using UnityEngine;
using System.Collections;

public class Item_CheckForDrop : MonoBehaviour {

    private Item_Master itemMaster;

	void OnEnable() 
	{
		SetInitialReferences();
	}

	void Update() 
	{
        CheckForDrop();
	}

	void SetInitialReferences() 
	{
        itemMaster = GetComponent<Item_Master>();
	}

    //Checks for input => calls Drop Item Event.
    void CheckForDrop()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            itemMaster.CallEventDropItem(0, null, 0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            itemMaster.CallEventDropItem(0, null, 1);
        }
    }
}
