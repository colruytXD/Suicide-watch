using UnityEngine;
using System.Collections;

public class Player_CheckForDeath : MonoBehaviour {

    private Player_Master playerMaster;
    private GameManager_Master gameManagerMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        playerMaster.EventPlayerTakesDamage += CheckForDeath;
	}

	void OnDisable() 
	{
        playerMaster.EventPlayerTakesDamage -= CheckForDeath;
	}

	void SetInitialReferences() 
	{
        playerMaster = GetComponent<Player_Master>();
        gameManagerMaster = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager_Master>();
	}

    void CheckForDeath(int nn)
    {
        if(playerMaster.Health <= 0)
        {
            gameManagerMaster.CallEventGameOver();
        }
    }
}
