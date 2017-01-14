using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAble_PlayUseItemSound : MonoBehaviour {

    private UseAble_Master useAbleMaster;
    [SerializeField]
    private AudioSource playerSoundSource;
    [SerializeField]
    private AudioClip itemSound;

	void OnEnable() 
	{
		SetInitialReferences();
        useAbleMaster.EventUseItem += PlaySound;
	}

	void OnDisable() 
	{
        useAbleMaster.EventUseItem -= PlaySound;
    }

	void SetInitialReferences() 
	{
        useAbleMaster = GetComponent<UseAble_Master>();
        playerSoundSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
	}

    void PlaySound()
    {
        playerSoundSource.clip = itemSound;
        playerSoundSource.Play();
    }
}
