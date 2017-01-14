using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAble_Master : MonoBehaviour {

	public delegate void GeneralEventHandler();

	public event GeneralEventHandler EventUseItem;

	public void CallEventUseItem() 
	{
        EventUseItem();
	}
}
