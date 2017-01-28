using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player_ToggleMovement : MonoBehaviour {

    private GameObject player;
    private Player_Master playerMaster;
    private GameManager_Master gameManagerMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        playerMaster.EventTogglePlayermov += ToggleMovement;
        gameManagerMaster.EventFinishedLevel += ToggleMovement;
		
	}

	void OnDisable() 
	{
        playerMaster.EventTogglePlayermov -= ToggleMovement;
        gameManagerMaster.EventFinishedLevel -= ToggleMovement;
    }

	void SetInitialReferences() 
	{
        player = gameObject;
        playerMaster = player.GetComponent<Player_Master>();
        gameManagerMaster = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager_Master>();
	}

    void ToggleMovement()
    {
        if(playerMaster.isActive)
        {
            player.GetComponent<FirstPersonController>().enabled = false;
        }
        else
        {
            player.GetComponent<FirstPersonController>().enabled = true;
        }
    }
}
