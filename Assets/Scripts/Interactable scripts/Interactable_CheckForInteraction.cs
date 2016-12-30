using UnityEngine;
using System.Collections;

public class Interactable_CheckForInteraction : MonoBehaviour {

    RaycastHit hit;

    [SerializeField]
    private LayerMask interactableLayer;
    [SerializeField]
    private int range;

	void Update() 
	{
        CheckForInteraction();
	}

    void CheckForInteraction()
    {
        if(Input.GetButtonDown("Interact"))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, range, interactableLayer))
            {
                hit.transform.GetComponent<Interactable_Master>().CallEventPlayerInteracts();
            }
        }
    }
}
