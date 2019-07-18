using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//if anything collides with block, freeze its velocity
	void OnCollisionEnter2D(Collision2D coll){
		coll.rigidbody.velocity = new Vector2 (0, 0);
	}
}
