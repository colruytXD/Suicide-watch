using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAble_Master : MonoBehaviour {

    //This is a very shitty way of doing this!!!

    public delegate void GeneralEventHandler();

    public GeneralEventHandler EventUseBleach;
    public GeneralEventHandler EventUseGun;
    public GeneralEventHandler EventUseWine;
    public GeneralEventHandler EventUseDrugs;
    //..

    public void CheckWhatEvent(int refNumber)
    {
        switch(refNumber)
        {
            case 1:
                CallEventUseBleach();
                break;
            case 4:
                CallEventUseGun();
                break;
            case 5:
                CallEventUseWine();
                break;
            case 7:
                CallEventUseDrugs();
                break;
        }
    }

    void CallEventUseBleach()
    {
        print("using bleach");
        EventUseBleach();
    }

    void CallEventUseGun()
    {
        EventUseGun();
    }

    void CallEventUseWine()
    {
        EventUseWine();
    }

    void CallEventUseDrugs()
    {
        EventUseDrugs();
    }
}
