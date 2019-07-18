using UnityEngine;
using System.Collections;

public class SimplePlayerMovement : MonoBehaviour {

	public float terminalVelocity = 20f;
	private BoxCollider2D bc;
	public float speed = 0f;
	private float movex = 0f;
	private Rigidbody2D rb;
	public float jumpSpeed = 10f;
	private bool isGrounded = false;
	private float jumps = 0;
	public float jumpsMax = 2;

	private Vector2 translation;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		bc = GetComponent<BoxCollider2D> ();

	}
	//IsGrounded casts 3 raycasts down at the left, middle, and right of the player to see if grounded
	void IsGrounded(){
		//raycast down at center of player
		Vector2 origin = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y - bc.bounds.extents.y - 0.2f);
		RaycastHit2D hit = (Physics2D.Raycast(origin, Vector2.down, 0.1f));
		//use to draw a line, turn on gizmos in game view
		//Debug.DrawRay (origin, Vector2.down, Color.red, 2);
		if (hit) {
			//use to display what was hit
			//Debug.Log ("Ray hit: " + hit.transform.name);
			isGrounded = true;
			jumps = 0;
		} else {
			isGrounded = false;
		}
		//raycast down at left of player
		if (!hit){
			origin = new Vector2 (gameObject.transform.position.x - bc.bounds.extents.x, gameObject.transform.position.y - bc.bounds.extents.y - 0.2f);

			hit = (Physics2D.Raycast (origin, Vector2.down, 0.1f));
			if (hit) {
				isGrounded = true;
				jumps = 0;
			} else {
				isGrounded = false;
			}
		}
		//raycast down at right of player
		if (!hit){
		origin = new Vector2 (gameObject.transform.position.x+bc.bounds.extents.x, gameObject.transform.position.y - bc.bounds.extents.y - 0.2f);
		hit = (Physics2D.Raycast (origin, Vector2.down, 0.1f));
			if (hit) {
				isGrounded = true;
				jumps = 0;
			} else {
				isGrounded = false;
			}
	}
	}

	// Update is called once per frame
	void FixedUpdate () {
		//player holds left or right, move left or right at speed
		movex = Input.GetAxisRaw ("Horizontal");
		//rb.velocity = new Vector2 (movex * speed, rb.velocity.y);
		translation = new Vector2(rb.transform.position.x + (movex * Time.deltaTime * speed), rb.transform.position.y);
		rb.transform.position = translation;
		//rb.transform.Translate();
		//if Space is pressed, call IsGrounded to update isGrounded
		if (Input.GetKeyDown (KeyCode.Space)) {
			IsGrounded ();
			//if true, jump, increment # of jumps
			if (isGrounded == true) {
				rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
				isGrounded = false;
				jumps += 1;
				//if false but jumps is at 0 (meaning player has fallen off a ledge) increment jump by 1 then jump
			} else if (isGrounded == false && jumps == 0) {
				jumps = 1;
				rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
				jumps += 1;
			}
			//otherwise if player has jumps left, jump
			else if (jumps < jumpsMax) {
				rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
				jumps += 1;
			}
		}

		//attack
		if (Input.GetKeyDown (KeyCode.F)) {
			//play the animation, from animation call attack function from attack script

		}

		//set a terminal velocity
		if (rb.velocity.y < -terminalVelocity)
			rb.velocity = new Vector2 (rb.velocity.x, -terminalVelocity);
		else
			rb.velocity = rb.velocity;
			
		}
		
	
	//if player hits anything, update isGrounded by calling IsGrounded
	void OnCollisionEnter2D (Collision2D coll){
		IsGrounded ();

		}
	}


//rb.AddForce ((Vector2.up * jumpSpeed), ForceMode2D.Force);

//rb.velocity = new Vector2 (rb.velocity.x, Vector2.up*jumpSpeed);

//rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);