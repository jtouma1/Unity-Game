using UnityEngine;
using System.Collections;

public class WallBounce : MonoBehaviour {
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.layer == 8 || coll.gameObject.layer == 10) {
			rb.velocity = new Vector2 (rb.velocity.x, -rb.velocity.y);

		} else if (coll.gameObject.layer == 11)
			rb.velocity = new Vector2 (-rb.velocity.x, rb.velocity.y);
	}
}