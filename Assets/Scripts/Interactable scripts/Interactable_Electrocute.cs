﻿using UnityEngine;
using System.Collections;

public class Interactable_Electrocute : MonoBehaviour {

    private Player_Master playerMaster;
    private Interactable_Master interactableMaster;

    [SerializeField]
    private int damage;

	void OnEnable() 
	{
		SetInitialReferences();
        interactableMaster.EventPlayerInteracts += Electrocute;
	}

	void OnDisable() 
	{
        interactableMaster.EventPlayerInteracts -= Electrocute;
	}

	void SetInitialReferences() 
	{
        interactableMaster = GetComponent<Interactable_Master>();
        playerMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Master>();
	}

    //Damages player
    void Electrocute()
    {
        playerMaster.CallEventPlayerTakesDamage(damage);
    }
}
