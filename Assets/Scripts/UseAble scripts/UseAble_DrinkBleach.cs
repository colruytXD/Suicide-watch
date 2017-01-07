using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAble_DrinkBleach : MonoBehaviour {

    private UseAble_Master useAbleMaster;
    private Player_Master playerMaster;

    [SerializeField]
    private int damage;

    void OnEnable()
    {
        SetInitialReferences();
        useAbleMaster.EventUseBleach += DrinkBleach;
    }

    void OnDisable()
    {
        useAbleMaster.EventUseBleach += DrinkBleach;
    }

    void SetInitialReferences()
    {
        useAbleMaster = GetComponent<UseAble_Master>();
        playerMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Master>();
    }

    public void DrinkBleach()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Master>().CallEventPlayerTakesDamage(damage);
    }
}
