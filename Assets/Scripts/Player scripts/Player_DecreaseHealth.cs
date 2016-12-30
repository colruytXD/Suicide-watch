using UnityEngine;
using System.Collections;

public class Player_DecreaseHealth : MonoBehaviour {

    private Player_Master playerMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        playerMaster.EventPlayerTakesDamage += DecreasePlayerHealth;
	}

	void OnDisable() 
	{
        playerMaster.EventPlayerTakesDamage -= DecreasePlayerHealth;
    }

	void SetInitialReferences() 
	{
        playerMaster = GetComponent<Player_Master>();
	}

    void DecreasePlayerHealth(int amount)
    {
        playerMaster.Health -= amount;

        if(playerMaster.Health < 0)
        {
            playerMaster.Health = 0;
        }
    }
}
