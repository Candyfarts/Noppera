using UnityEngine;
using System.Collections;

public class TreeAwake : InventoryObject {

	public GameObject tree;
	public GameObject eyeball;
	public GameObject chest;
	public GameObject deactivateChest;
	
	public override void activationEvent ()
	{
		// do the tree stuff
		tree.SetActive(true);
		eyeball.SetActive(true);
		chest.SetActive(true);
		deactivateChest.SetActive(false);
		
		
	}
}
