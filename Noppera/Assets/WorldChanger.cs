using UnityEngine;
using System.Collections;

public class WorldChanger : MonoBehaviour {

	public Camera realCamera;
	public Camera imaginaryCamera;

	bool realworld;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			realworld = !realworld;
			if (realworld)
			{
				realCamera.rect = new Rect(0, 0, 1, 1);
				imaginaryCamera.rect = new Rect(0, 0, 0, 0);
			}
			else
			{
				realCamera.rect = new Rect(0, 0, 0, 0);
				imaginaryCamera.rect = new Rect(0, 0, 1, 1);
			}
		}
	}
}
