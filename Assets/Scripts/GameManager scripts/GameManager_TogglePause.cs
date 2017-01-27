﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager_TogglePause : MonoBehaviour {

    bool cursorHidden = true;

    GameManager_Master gameManagerMaster;
    Player_Master playerMaster;

    [SerializeField]
    private GameObject pausePanel;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventTogglePause += TogglePause;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventTogglePause += TogglePause;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
        playerMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Master>();
    }

    void OnGUI()
    {
        if(cursorHidden)
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

    void TogglePause()
    {

        gameManagerMaster.isPaused = !gameManagerMaster.isPaused;

        if (gameManagerMaster.isPaused) //pauses game
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            playerMaster.CallEventTogglePlayerMov();

            cursorHidden = false;
        }
        else //unpauses game
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            playerMaster.CallEventTogglePlayerMov();

            cursorHidden = true;

        }

        
    }
}
