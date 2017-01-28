﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleCursor : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    bool cursorHidden = true;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventTogglePause += ToggleCursor;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventTogglePause += ToggleCursor;

    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void OnGUI()
    {
        if (cursorHidden)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void ToggleCursor()
    {
        if(gameManagerMaster.isPaused)
        {
            cursorHidden = false;
        }
        else
        {
            cursorHidden = true;
        }
    }
}
