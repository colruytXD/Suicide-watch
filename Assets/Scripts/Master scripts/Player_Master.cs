using UnityEngine;
using System.Collections;

public class Player_Master : MonoBehaviour {

    public bool isActive = true;

    public int Health;

    public delegate void HealthEventHandler(int amount);

    public event HealthEventHandler EventPlayerTakesDamage;
    public event HealthEventHandler EventPlayerHeals;

    public delegate void GeneralEventHandler();

    public event GeneralEventHandler EventPlayerDies;
    public event GeneralEventHandler EventTogglePlayermov;

    public void CallEventPlayerTakesDamage(int amount)
    {
        EventPlayerTakesDamage(amount);
    }

    public void CallEventPlayerHeals(int amount)
    {
        EventPlayerHeals(amount);
    }

    public void CallEventPlayerDies()
    {
        EventPlayerDies();
    }

    public void CallEventTogglePlayerMov()
    {
        EventTogglePlayermov();

        isActive = !isActive;
    }
}
