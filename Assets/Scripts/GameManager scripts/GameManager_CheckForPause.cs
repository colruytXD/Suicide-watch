using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_CheckForPause : MonoBehaviour {

    private GameManager_Master gameManagerMaster;

	void OnEnable() 
	{
		SetInitialReferences();
		
	}

	void OnDisable() 
	{
		
	}

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void Update()
    {
        CheckForPauseReq();
    }

    void CheckForPauseReq()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameManagerMaster.CallEventTogglePause();
        }
    }
}
