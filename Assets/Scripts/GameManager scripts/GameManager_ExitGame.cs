using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ExitGame : MonoBehaviour {

    private GameManager_Master gameManagerMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventExitGame += ExitGame;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventExitGame -= ExitGame;
	}

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void ExitGame()
    {
        Application.Quit();
    }
}
