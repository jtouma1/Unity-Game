using UnityEngine;
using System.Collections;

public class DontFall : MonoBehaviour {

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (rb.velocity.y <= 0)
			rb.velocity = new Vector2 (rb.velocity.x, 0);
	
	}
}
