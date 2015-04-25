using UnityEngine;
using System.Collections;

public class AnimationStartEvent : Event {

	// Use this for initialization
	void Start () {
		this.GetComponent<Animator>().speed = 0;
	}

	public override void activate()
	{
		Debug.Log("Active");
		state = !state;
		this.GetComponent<Animator>().speed = 1;
	}
}
