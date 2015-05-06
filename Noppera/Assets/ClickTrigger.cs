using UnityEngine;
using System.Collections;

public class ClickTrigger : Trigger {

	public InventoryManager.Item requiredItem;

	void OnMouseDown(){
		if(InventoryManager._singleton.currentSelectedItem == requiredItem)
			trigger ();
	}
}
