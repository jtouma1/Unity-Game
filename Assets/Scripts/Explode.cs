using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public float radius = 1f;
	public float power = 1000f;
	private CircleCollider2D cirCol;
	public float cooldown = 1f;

	// Use this for initialization
	void Start () {
		//set the radius of the explosion
		cirCol = gameObject.GetComponent<CircleCollider2D> ();
		cirCol.radius = radius;

	}
	
	// Update is called once per frame
	void Update () {
		//how long the explosion stays out
		if (cooldown > 0)
			cooldown -= Time.deltaTime;
		else if (cooldown <= 0)
			Destroy (gameObject);
	}
	void OnTriggerEnter2D (Collider2D coll){
		//if object in explosion is not player, addforce in direction of object
		if (coll.tag != "player") {
			Transform location = coll.GetComponent<Transform> ();
			Rigidbody2D rb = coll.GetComponent<Rigidbody2D> ();
			Vector2 target = new Vector2 (location.position.x, location.position.y);
			Vector2 center = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
			Vector2 direction = target - center;
			float length = Mathf.Sqrt ((direction.x * direction.x) + (direction.y * direction.y));
			direction.Normalize ();
			//if object is further than half the radius away, reduce force by 20%
			if (length >= radius / 2)
				power = .8f * power;
			rb.AddForce (direction * power, ForceMode2D.Impulse);
		}
	}
}
