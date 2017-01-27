using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story_StartLines : MonoBehaviour {

    private Story_Master storyMaster;
    private Text storyTextGO;

	void OnEnable() 
	{
		SetInitialReferences();
        StartLineCoroutine();
	}

	void OnDisable() 
	{
        StopCoroutine(StartLines());
	}

	void SetInitialReferences() 
	{
        storyMaster = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Story_Master>();
        storyTextGO = gameObject.GetComponent<Text>();
	}

    void StartLineCoroutine()
    {
        if(storyMaster.currentLine < storyMaster.lines.Length)
        StartCoroutine(StartLines());
    }

    IEnumerator StartLines()
    {
        storyTextGO.text = storyMaster.lines[storyMaster.currentLine];
        yield return new WaitForSeconds(storyMaster.pauseTimes[storyMaster.currentLine]);
        storyMaster.currentLine++;
        StartLineCoroutine();

    }
}
