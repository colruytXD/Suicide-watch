using UnityEngine;
using System.Collections;

public class Item_PlayPickupSound : MonoBehaviour {

    private Item_Master itemMaster;

    [SerializeField]
    private AudioClip pickupSound;
    [SerializeField]
    private AudioSource pickupSoundSource;

	void OnEnable() 
	{
		SetInitialReferences();
        itemMaster.EventPickUpItem += PlayPickupSound;
	}

	void OnDisable() 
	{
        itemMaster.EventPickUpItem -= PlayPickupSound;
    }

	void SetInitialReferences() 
	{
        itemMaster = GetComponent<Item_Master>();
	}

    void PlayPickupSound(int nn, GameObject nn1)
    {
        pickupSoundSource.clip = pickupSound;
        pickupSoundSource.Play();
    }
}
