using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Player : MonoBehaviour {
	
	public float moveSpeed;
	
	float h;
	float v;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		
		rigidbody2D.MovePosition(this.rigidbody2D.position + new Vector2(h,v)*moveSpeed);
	}
}
