using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleLevelSelector : MonoBehaviour {

    private GameManager_Master gameManagerMaster;

    private bool isMainMenuActive = true;

    [SerializeField]
    private GameObject levelSelectorPanel, mainMenuPanel;

    void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.EventToggleLevelSelector += ToggleLevelSelector;
    }

    void OnDisable()
    {
        gameManagerMaster.EventToggleLevelSelector -= ToggleLevelSelector;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void ToggleLevelSelector()
    {

        if(isMainMenuActive) //activate levelSelector
        { 
            levelSelectorPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }
        else //activate mainMenu
        {
            mainMenuPanel.SetActive(true);
            levelSelectorPanel.SetActive(false);
        }

        isMainMenuActive = !isMainMenuActive;
    }
}
