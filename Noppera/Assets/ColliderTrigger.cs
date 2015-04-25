using UnityEngine;
using System.Collections;

public class ColliderTrigger : Trigger {

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Player.instance.useTrigger = this;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Player.instance.useTrigger = null;
		}
	}
}
