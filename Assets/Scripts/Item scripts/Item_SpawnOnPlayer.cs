using UnityEngine;
using System.Collections;

public class Item_SpawnOnPlayer : MonoBehaviour {

    private Transform player;
    private Item_Master itemMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        itemMaster.EventDropItem += SpawnGO;
	}

	void OnDisable() 
	{
        itemMaster.EventDropItem -= SpawnGO;
	}

	void SetInitialReferences() 
	{
        itemMaster = GetComponent<Item_Master>();
        player = gameObject.transform.GetChild(0);
	}

    void SpawnGO(int refNumber, GameObject item, int nn)
    {
        Instantiate(item, player.position + player.forward, Quaternion.identity);
    }
}
