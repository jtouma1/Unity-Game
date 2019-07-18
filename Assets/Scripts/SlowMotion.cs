using UnityEngine;
using System.Collections;

public class SlowMotion : MonoBehaviour {



	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//if holding shift, set time and physics calculations to 50%, otherwise set to normal
		if (Input.GetKey (KeyCode.LeftShift)) {
			Time.timeScale = 0.5f;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
		} else {
			Time.timeScale = 1;
			Time.fixedDeltaTime = 0.02f;
		}


	}
}
