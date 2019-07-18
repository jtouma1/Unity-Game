using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

	private Vector3 pz;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		pz = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		pz.z = 0;
		gameObject.transform.position = pz;

	}
}
