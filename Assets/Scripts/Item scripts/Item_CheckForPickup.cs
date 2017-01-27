using UnityEngine;
using System.Collections;

public class Item_CheckForPickup : MonoBehaviour {

    private RaycastHit hit;
    [SerializeField]
    private LayerMask itemLayer;
    [SerializeField]
    private float pickupRange;
    [SerializeField]
    private GUIStyle style;

    private Item_Master itemMaster;
    private GameManager_Master gameManagerMaster;

    private bool display;

    void Start()
    {
        SetInitialReferences();
        style.normal.textColor = Color.black;
    }

    void SetInitialReferences()
    {
        itemMaster = transform.root.GetComponent<Item_Master>();
        gameManagerMaster = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager_Master>();
    }

	void Update() 
	{
        CheckForItem();
	}

    //Checks when player wants to pick up item
    //Checks raycast for item
    //Calls pickup item event
    void CheckForItem()
    {
        if(Input.GetButtonDown("Pickup item"))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.red, 5f);
            if(Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, itemLayer))
            {                
                Debug.Log("Picked up: " + hit.transform.name);
                if(hit.transform.GetComponent<Item_Master>() != null)
                {
                    Item_Master thisItem = hit.transform.GetComponent<Item_Master>();                    
                    itemMaster.CallEventPickupItem(thisItem.refNumber, hit.transform.gameObject, 0);
                }
                else
                {
                    print("null");
                }
            }
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, itemLayer))
        {
            
            display = true;
        }
        else
        {
            display = false;
        }
    }

    void OnGUI()
    {
        if(display && !gameManagerMaster.isPaused)
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 + 25, Screen.width, 256), "Press [f] to pick up " + hit.transform.name, style);
    }
}
