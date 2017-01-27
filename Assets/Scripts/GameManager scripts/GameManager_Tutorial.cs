using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Tutorial : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    private Inventory_Master inventoryMaster;
    [SerializeField]
    private float amtOfSeconds;
    [SerializeField]
    private Text txtTut;

    [SerializeField]
    private string activeInventorySlotText = "Press [1] or  [2] to change active inventory slots";
    [SerializeField]
    private string dropItemText = "Press [R] to drop item in active slot";
    [SerializeField]
    private string useItemText = "Press [E] to use item in active slot";

    public int count;

	void OnEnable() 
	{
		SetInitialReferences();
        inventoryMaster.EventAddToInventory += CallTutActiveInvSlot;
	}

	void OnDisable() 
	{
        inventoryMaster.EventAddToInventory -= CallTutActiveInvSlot;
    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager_Master>();
        inventoryMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory_Master>();
	}

    void CallTutActiveInvSlot(int refNumber, GameObject item, int inventoryIndex)
    {
        if(count == 0)
        {
            StartCoroutine(TutActiveInvSlot());
            count++;
        }        
    }

    IEnumerator TutActiveInvSlot()
    {
        txtTut.gameObject.SetActive(true);
        txtTut.text = activeInventorySlotText;
        yield return new WaitForSeconds(amtOfSeconds);
        txtTut.gameObject.SetActive(false);
        StartCoroutine(TutDropItem());
    }

    IEnumerator TutDropItem()
    {
        txtTut.gameObject.SetActive(true);
        txtTut.text = dropItemText;
        yield return new WaitForSeconds(amtOfSeconds);
        txtTut.gameObject.SetActive(false);
        StartCoroutine(TutUseItem());
    }

    IEnumerator TutUseItem()
    {
        txtTut.gameObject.SetActive(true);
        txtTut.text = useItemText;
        yield return new WaitForSeconds(amtOfSeconds);
        txtTut.gameObject.SetActive(false);
    }
}
