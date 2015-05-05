using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Player : MonoBehaviour {

	private float scale;

	public float moveSpeed;

	public Animator anim;
	
	float h;
	float v;

	bool right;
	bool back;
	bool idle;

	private bool waking;

	public float asleep = 1.2f;
	public bool stuck;

	public static Player instance;

	public Trigger useTrigger;

	// Use this for initialization
	void Start () {
		instance = this;
		scale = this.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		if (asleep <= 0 && !stuck){
			GetComponent<Rigidbody2D>().MovePosition(this.GetComponent<Rigidbody2D>().position + new Vector2(h, v) * moveSpeed);
			bool lastorientation = right;
			right = right ? (h >= 0) : (h > 0);//||(lastorientation);
			back = back ? (v >= 0) : (v > 0);
			if (lastorientation != right)
			{
				this.transform.localScale = new Vector3((right) ? -scale : scale, transform.localScale.y, transform.localScale.z);
			}
		}

		if (stuck && !waking)
			idle = true;
		else if(!waking)
			idle = (Mathf.Abs(h) < .1f) && (Mathf.Abs(v) < .1f);
		
		if (!idle && asleep > 0 && !waking){
			waking = true;
			StartCoroutine(wakeup());
			idle = false;
		}
		anim.SetBool("idle", idle);
		anim.SetBool("back", back);
		anim.SetBool ("asleep", asleep > 0);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (useTrigger != null){
				useTrigger.trigger();
			}
		}
	}

	public void sleep(){
		asleep = 1.5f;
		stuck = true;
	}

	public void warpTo(Vector2 v)
	{
		this.transform.position = v;
	}
	public IEnumerator wakeup()
	{
		while (asleep > 0){
			asleep -= Time.fixedDeltaTime;
			yield return null;
		}
		waking = false;
	}
}
