using UnityEngine;
using System.Collections;

public class Item_DrinkBleach : MonoBehaviour {

    private Item_Master itemMaster;
    private Player_Master playerMaster;

    [SerializeField]
    private int damage;

	void OnEnable() 
	{
		SetInitialReferences();
        print("Enabled!!!");
        itemMaster.EventUseItem += DrinkBleach;
	}

	void OnDisable() 
	{
        print("     ");
        itemMaster.EventUseItem -= DrinkBleach;
    }

	void SetInitialReferences() 
	{
        itemMaster = GetComponent<Item_Master>();
        playerMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Master>();
	}

    public void DrinkBleach()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Master>().CallEventPlayerTakesDamage(damage);
    }

}
