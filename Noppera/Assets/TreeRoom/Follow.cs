using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().AddForce((target.transform.position - transform.position).normalized);
	}
}
