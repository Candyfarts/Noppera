using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Vector3 back = new Vector2(0, -1);
	public Vector3 entrance = new Vector2(0,0);

	public Door exit;

	bool disabled = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!disabled && exit != null && other.tag == "Player")
		{
			disabled = true;
			Player.instance.warpTo(exit.transform.position + exit.back);
			exit.disabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (exit != null && other.tag == "Player")
		{
			disabled = false;
		}
	}
}
