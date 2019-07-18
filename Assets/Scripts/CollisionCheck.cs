using UnityEngine;
using System.Collections;

public class CollisionCheck : MonoBehaviour {

	public GameObject blockPrefab;
	private BoxCollider2D blockBC;
	private BoxCollider2D colBC;

	// Use this for initialization
	void Start () {
		colBC = gameObject.GetComponent<BoxCollider2D> ();
		blockBC = blockPrefab.GetComponent<BoxCollider2D> ();
		colBC.size = blockBC.size * 25;
	
	}
	
	// Update is called once per frame
	void Update () {
		//if there is no trigger, make a block
		Instantiate (blockPrefab, gameObject.transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
	void OnTriggerEnter2D (Collider2D coll){
		//if making a block at a box, freeze the boxes velocity and instantiate a block under it
		if (coll.tag == "Box") {
			coll.attachedRigidbody.velocity = new Vector2 (0, 0);
			Vector3 position = coll.transform.position;
			BoxCollider2D bc = coll.GetComponent<BoxCollider2D> ();
			position = new Vector3 (position.x, position.y - bc.bounds.extents.y, position.z);
			Instantiate (blockPrefab, position, Quaternion.identity);
			Destroy (gameObject);
		//if making a block at anything other than a previously placed block, dont make a block
		} else if (coll.tag != "Block")
			Destroy (gameObject);
		//otherwise, make a block
		else {
			Instantiate (blockPrefab, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

}
