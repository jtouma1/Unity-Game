using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	[SerializeField]
	public Transform target;

	public float zoom = 10;


	void Start () {
		

	}

	//update is called once per frame
	void Update () {

		gameObject.transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, -zoom);


	}
}
