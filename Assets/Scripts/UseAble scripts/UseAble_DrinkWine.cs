using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAble_DrinkWine : MonoBehaviour {

    public UseAble_Master useableMaster;
    private Player_Master playerMaster;

    [SerializeField]
    private int damage = 100;

    int bottleCount; //Amount of bottles drinked
    int maxBottleCount;

	void OnEnable() 
	{
		SetInitialReferences();
        useableMaster.EventUseWine += DrinkWine;
	}

	void OnDisable() 
	{
        useableMaster.EventUseWine -= DrinkWine;
	}

	void SetInitialReferences() 
	{
        useableMaster = GetComponent<UseAble_Master>();
        playerMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Master>();
	}

    void DrinkWine()
    {
        bottleCount++;

        if(bottleCount > maxBottleCount)
        {
            playerMaster.CallEventPlayerTakesDamage(damage);
        }
    }
}
