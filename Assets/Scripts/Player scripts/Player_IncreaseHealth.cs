using UnityEngine;
using System.Collections;

public class Player_IncreaseHealth : MonoBehaviour {

    private Player_Master playerMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        playerMaster.EventPlayerHeals += IncreaseHealth;
	}

	void OnDisable() 
	{
        playerMaster.EventPlayerHeals -= IncreaseHealth;
    }

	void SetInitialReferences() 
	{
        playerMaster = GetComponent<Player_Master>();
	}

    void IncreaseHealth(int amount)
    {
        playerMaster.Health += amount;

        if(playerMaster.Health > 100)
        {
            playerMaster.Health = 100;
        }
    }
}
