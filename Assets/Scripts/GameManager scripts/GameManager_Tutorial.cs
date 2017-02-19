using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Tutorial : MonoBehaviour {

    private Inventory_Master inventoryMaster;
    private GameManager_Master gameManagerMaster;
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
    [Space(10)]
    [SerializeField]
    private string interactableText = "Press [E] when looking at an interactable";

    public int count;
    private bool continueTut = true;

    void OnEnable() 
	{
		SetInitialReferences();
        inventoryMaster.EventAddToInventory += CallTutActiveInvSlot;
        gameManagerMaster.EventFinishedLevel += discontinueTut;
	}

	void OnDisable() 
	{
        inventoryMaster.EventAddToInventory -= CallTutActiveInvSlot;
        gameManagerMaster.EventFinishedLevel -= discontinueTut;
    }

    void Start()
    {
        if(count == -1)
        Invoke("CallTutInteractible", 1);
    }

	void SetInitialReferences() 
	{
        inventoryMaster = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory_Master>();
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void CallTutActiveInvSlot(int refNumber, GameObject item, int inventoryIndex)
    {
        if(count == 0)
        {
            StartCoroutine(TutActiveInvSlot());
            count++;
        }        
    }

    void CallTutInteractible()
    {
        StartCoroutine(TutInteractable());
    }

    void discontinueTut()
    {
        continueTut = false;
    }

    IEnumerator TutActiveInvSlot()
    {
        txtTut.gameObject.SetActive(true);
        txtTut.text = activeInventorySlotText;
        yield return new WaitForSeconds(amtOfSeconds);
        txtTut.gameObject.SetActive(false);
        if(continueTut)
        StartCoroutine(TutDropItem());
    }

    IEnumerator TutDropItem()
    {
        txtTut.gameObject.SetActive(true);
        txtTut.text = dropItemText;
        yield return new WaitForSeconds(amtOfSeconds);
        txtTut.gameObject.SetActive(false);
        if(continueTut)
        StartCoroutine(TutUseItem());
    }

    IEnumerator TutUseItem()
    {
        txtTut.gameObject.SetActive(true);
        txtTut.text = useItemText;
        yield return new WaitForSeconds(amtOfSeconds);
        txtTut.gameObject.SetActive(false);
    }

    IEnumerator TutInteractable()
    {
        txtTut.gameObject.SetActive(true);
        txtTut.text = interactableText;
        yield return new WaitForSeconds(amtOfSeconds);
        txtTut.gameObject.SetActive(false);
    }
}
