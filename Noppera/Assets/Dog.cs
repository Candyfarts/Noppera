using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dog : MonoBehaviour {

	private float scale;

	public List<Vector3> waypoints;

	public float moveDistance = 5;
	public float moveTime = 3;
	public float moveTimer = 0;

	public float moveSpeed;

	public Animator anim;
	
	float h;
	float v;

	bool right;
	bool back;
	bool idle;

	// Use this for initialization
	void Start () {
		scale = this.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.position;
		moveTimer = (Player.instance.transform.position - pos).magnitude < moveDistance?moveTime:moveTimer-Time.deltaTime;
		if (moveTimer > 0) 
		{
			if (waypoints.Count == 0)
			{
				kill();
				return;
			}
			Vector3 diff = (waypoints[0] - pos);
			
			Vector3 movediff = diff.normalized * Time.deltaTime * moveSpeed;
			h = movediff.x;
			v = movediff.y;

			GetComponent<Rigidbody2D>().MovePosition(this.GetComponent<Rigidbody2D>().position + new Vector2(h, v) * moveSpeed);
			bool lastorientation = right;
			right = right ? (h >= 0) : (h > 0);//||(lastorientation);
			back = back ? (v >= 0) : (v > 0);
			if (lastorientation != right)
			{
				this.transform.localScale = new Vector3((right) ? -scale : scale, transform.localScale.y, transform.localScale.z);
			}
			if (diff.magnitude < .1f)
				waypoints.RemoveAt(0);
		}

		anim.SetBool("idle", idle);
		anim.SetBool("back", back);

	}

	public void kill()
	{
		Destroy(this.gameObject);
	}
}
