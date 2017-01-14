using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAble_DamagePlayer : MonoBehaviour {

    private UseAble_Master useAbleMaster;

    [SerializeField]
    private int damage;
    private GameObject player;

	void OnEnable() 
	{
		SetInitialReferences();
        useAbleMaster.EventUseItem += DamagePlayer;
	}

	void OnDisable() 
	{
        useAbleMaster.EventUseItem -= DamagePlayer;
	}

	void SetInitialReferences() 
	{
        useAbleMaster = GetComponent<UseAble_Master>();
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void DamagePlayer()
    {
        player.GetComponent<Player_Master>().CallEventPlayerTakesDamage(damage);
    }
}
