using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager_Master : MonoBehaviour {

    public bool isPaused;
    public bool isGameUIOn;
    public bool isLevelFinished;

    public delegate void GeneralEventHandler();

    public event GeneralEventHandler EventGameOver;
    public event GeneralEventHandler EventExitGame;
    public event GeneralEventHandler EventGoToMainMenu;
    public event GeneralEventHandler EventToggleLevelSelector;
    public event GeneralEventHandler EventTogglePause;
    public event GeneralEventHandler EventFinishedLevel;

    public delegate void SceneHandler(int sceneNr);

    public event SceneHandler EventLoadScene;

    public void CallEventGameOver()
    {
        EventGameOver();
    }

    public void CallEventExitGame()
    {
        EventExitGame();
    }

    public void CallEventGoToMainMenu()
    {
        EventGoToMainMenu();
    }

    public void CallEventLoadScene(int sceneNr)
    {
        EventLoadScene(sceneNr);
    }

    public void CallEventFinishedLevel()
    {
        EventFinishedLevel();
        isLevelFinished = true;
    }

    public void CallEventToggleLevelSelector()
    {
        EventToggleLevelSelector();
    }

    public void CallEventTogglePause()
    {
        if(!isLevelFinished)
        EventTogglePause();
    }

}
