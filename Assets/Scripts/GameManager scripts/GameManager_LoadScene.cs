using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_LoadScene : MonoBehaviour {

    private GameManager_Master gameManagerMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventGoToMainMenu += LoadMainMenuScene;
        gameManagerMaster.EventLoadScene += LoadScene;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventGoToMainMenu -= LoadMainMenuScene;
        gameManagerMaster.EventLoadScene -= LoadScene;
    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void LoadScene(int sceneNr)
    {
        SceneManager.LoadSceneAsync(sceneNr);
    }

    void LoadMainMenuScene()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
