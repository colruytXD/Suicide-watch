using UnityEngine;
using System.Collections;

public class Item_Destroy : MonoBehaviour {

    private Item_Master itemMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        itemMaster.EventItemDeath += DestroyItem;
	}

	void OnDisable() 
	{
        itemMaster.EventItemDeath -= DestroyItem;
	}

	void SetInitialReferences() 
	{
        itemMaster = GetComponent<Item_Master>();
	}

    void DestroyItem()
    {
        Destroy(gameObject);
    }
}
