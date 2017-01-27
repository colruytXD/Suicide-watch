using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story_ToggleUI : MonoBehaviour {

    GameManager_Master gameManagerMaster;
    bool isEnabled;

	void OnEnable() 
	{
		SetInitialReferences();
		
	}

	void OnDisable() 
	{
		
	}

	void SetInitialReferences() 
	{
        gameManagerMaster = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager_Master>();
	}

    void ToggleUI()
    {
        if(isEnabled)
        {
            gameObject.GetComponent<Text>().color = new Color(0, 0, 0, 0);
        }
        else
        {
            gameObject.GetComponent<Text>().color = new Color(0, 0, 0, 0);
        }

        isEnabled = !isEnabled;
    }
}
