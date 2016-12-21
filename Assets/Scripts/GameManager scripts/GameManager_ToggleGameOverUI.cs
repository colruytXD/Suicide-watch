using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager_ToggleGameOverUI : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    [SerializeField]
    private GameObject gameOverUI;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventGameOver += ShowGameOverUI;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventGameOver -= ShowGameOverUI;
    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    void HideGameOverUI()
    {
        gameOverUI.SetActive(false);
    }
}
