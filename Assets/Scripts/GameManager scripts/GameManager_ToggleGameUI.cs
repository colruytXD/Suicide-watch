using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleGameUI : MonoBehaviour {

    private GameManager_Master gameManager_Master;
    [SerializeField]
    private GameObject[] HUD;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManager_Master.EventTogglePause += ToggleCanvas;
        gameManager_Master.EventFinishedLevel += ToggleCanvas;
	}

	void OnDisable() 
	{
        gameManager_Master.EventTogglePause -= ToggleCanvas;
        gameManager_Master.EventFinishedLevel -= ToggleCanvas;
    }

	void SetInitialReferences() 
	{
        gameManager_Master = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager_Master>();
	}

    void ToggleCanvas()
    {
        if(gameManager_Master.isGameUIOn)
        {
            for(int i = 0; i < HUD.Length; i++)
            {
                HUD[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < HUD.Length; i++)
            {
                HUD[i].SetActive(true);
            }
        }


        gameManager_Master.isGameUIOn = !gameManager_Master.isGameUIOn;

    }
}
