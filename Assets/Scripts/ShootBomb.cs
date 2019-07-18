using UnityEngine;
using System.Collections;

public class ShootBomb : MonoBehaviour {

	public GameObject bombPrefab;
	public GameObject expPrefab;
	public GameObject colPrefab;
	private bool bombOut = false;
	private GameObject bomb;
	private Rigidbody2D rb;
	public float bombSpeed;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	//if left click and there is no bomb out, shoot bomb towards mouse at speed bombSpeed
	void Update () {
		if (Input.GetMouseButtonDown (0) && bombOut == false) {
			Vector2 target = Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
			Vector2 myPos = new Vector2 (transform.position.x, transform.position.y);
			Vector2 direction = target - myPos;
			direction.Normalize ();
			bomb = (GameObject)Instantiate (bombPrefab, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
			bombOut = true;
			rb = bomb.GetComponent<Rigidbody2D> ();
			rb.velocity = (direction * bombSpeed);


			//if left click while bomb is out, call Explode at the bombs location
		} else if (Input.GetMouseButtonDown (0) && bombOut == true) {
			Transform location = bomb.transform;
			Destroy (bomb);
			Explode (location);
			bombOut = false;
			//if right click while bomb is out, call Place at the bombs location
		} else if (Input.GetMouseButtonDown (1) && bombOut == true) {
			Transform location = bomb.transform;
			Destroy (bomb);
			Place (location);
			bombOut = false;

		}
	}
	//instantiates the explosion prefab which handles the explosion
	void Explode(Transform location){
		
		Instantiate (expPrefab, location.position, Quaternion.identity);
	}
	//instantiates the collisionCheck prefab to check if can place block
	void Place(Transform location){
		Instantiate (colPrefab, location.position, Quaternion.identity);
	}
}
