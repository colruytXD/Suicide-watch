using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleCursor : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    bool cursorHidden = true;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventTogglePause += ToggleCursor;
        gameManagerMaster.EventFinishedLevel += ToggleCursor;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventTogglePause -= ToggleCursor;
        gameManagerMaster.EventFinishedLevel -= ToggleCursor;
    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void OnGUI()
    {
        print(cursorHidden);
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
        cursorHidden = !cursorHidden;
    }
}
