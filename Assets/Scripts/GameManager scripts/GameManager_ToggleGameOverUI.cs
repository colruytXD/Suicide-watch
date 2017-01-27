using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager_ToggleGameOverUI : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    [SerializeField]
    private GameObject gameOverPanel;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventFinishedLevel += ShowGameOverUI;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventFinishedLevel -= ShowGameOverUI;
    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void ShowGameOverUI()
    {
        gameOverPanel.transform.root.gameObject.SetActive(true);
        gameOverPanel.SetActive(true);
    }

    void HideGameOverUI()
    {
        gameOverPanel.SetActive(false);
    }
}
