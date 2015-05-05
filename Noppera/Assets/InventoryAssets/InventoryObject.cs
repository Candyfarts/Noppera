using UnityEngine;
using System.Collections;

public abstract class InventoryObject : MonoBehaviour {

	public InventoryManager.Item AcceptedType = InventoryManager.Item.Null;
	public GameObject itemToUse;
	
	public void clicked(){
		if(InventoryManager.singleton.getCurrentItem().Equals(AcceptedType)){
			activationEvent();
			removeItemFromInventory();
		} else {
			InventoryManager.singleton.cancelItem();
		}
	}
	
	void OnMouseOver(){
		InventoryManager.singleton.storyObjectTargeted = true;
		if(Input.GetKey(KeyCode.Mouse0)){
			clicked();
		}
	}
	
	void OnMouseExit(){
		InventoryManager.singleton.storyObjectTargeted = false;
	}
	
	public void removeItemFromInventory(){
		itemToUse.SetActive(false);
	}
	
	public abstract void activationEvent();
}