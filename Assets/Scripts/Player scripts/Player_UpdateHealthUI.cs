using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_UpdateHealthUI : MonoBehaviour {

    private Player_Master playerMaster;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Text healthText;

	void OnEnable() 
	{
		SetInitialReferences();
        playerMaster.EventPlayerHeals += UpdateHealthUI;
        playerMaster.EventPlayerTakesDamage += UpdateHealthUI;
        UpdateHealthUI(0);
	}

	void OnDisable() 
	{
        playerMaster.EventPlayerHeals += UpdateHealthUI;
        playerMaster.EventPlayerTakesDamage += UpdateHealthUI;
    }

	void SetInitialReferences() 
	{
        playerMaster = GetComponent<Player_Master>();
        
	}

    void UpdateHealthUI(int nn)
    {
        healthBar.fillAmount = (float)playerMaster.Health / 100;
        healthText.text = playerMaster.Health.ToString();
    }
}
