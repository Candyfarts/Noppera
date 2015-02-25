using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Player : MonoBehaviour {
	
	public float moveSpeed;
	
	float h;
	float v;

	bool right;

	public static Player instance;
	
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		
		rigidbody2D.MovePosition(this.rigidbody2D.position + new Vector2(h,v)*moveSpeed);
		bool lastorientation = right;
		right = (h > 0);//||(lastorientation);

		if(lastorientation != right){
			this.transform.localScale = new Vector3((right)?-.5f:.5f,transform.localScale.y,transform.localScale.z);
		}
	}

	public void warpTo(Vector2 v)
	{
		this.transform.position = v;
	}
}
