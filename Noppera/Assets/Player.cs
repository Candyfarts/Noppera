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

	public float stuck;

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

		if (stuck <= 0)
		{
			GetComponent<Rigidbody2D>().MovePosition(this.GetComponent<Rigidbody2D>().position + new Vector2(h, v) * moveSpeed);
			bool lastorientation = right;
			right = right ? (h >= 0) : (h > 0);//||(lastorientation);
			back = back ? (v >= 0) : (v > 0);
			if (lastorientation != right)
			{
				this.transform.localScale = new Vector3((right) ? -scale : scale, transform.localScale.y, transform.localScale.z);
			}
		}

		idle = (Mathf.Abs(h) < .1f) && (Mathf.Abs(v) < .1f);
		
		if (!idle && stuck > 0)
		{
			StartCoroutine(wakeup());
		}
		anim.SetBool("idle", idle);
		anim.SetBool("back", back);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			TextManager.singleton.write("I am speaking now. la la la la la.");
		}
		if (useTrigger != null)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				useTrigger.trigger();
			}
		}
	}

	public void warpTo(Vector2 v)
	{
		this.transform.position = v;
	}
	public IEnumerator wakeup()
	{
		while (stuck > 0)
		{
			stuck -= Time.fixedDeltaTime;
			yield return null;
		}
	}
}
