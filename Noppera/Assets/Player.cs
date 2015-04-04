using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Player : MonoBehaviour {
	
	public float moveSpeed;

	public Animator anim;
	
	float h;
	float v;

	bool right;
	bool back;
	bool idle;

	public static Player instance;
	
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		
		GetComponent<Rigidbody2D>().MovePosition(this.GetComponent<Rigidbody2D>().position + new Vector2(h,v)*moveSpeed);
		bool lastorientation = right;
		right = right?(h >= 0):(h > 0);//||(lastorientation);
		idle = (Mathf.Abs(h) < .1f) && (Mathf.Abs(v) < .1f);
		back = back?(v >= 0):(v > 0);
		if(lastorientation != right){
			this.transform.localScale = new Vector3((right)?-.5f:.5f,transform.localScale.y,transform.localScale.z);
		}
		anim.SetBool("idle", idle);
		anim.SetBool("back", back);
	}

	public void warpTo(Vector2 v)
	{
		this.transform.position = v;
	}
}
