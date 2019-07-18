using UnityEngine;
using System.Collections;

public class BlockManager : MonoBehaviour {

	private GameObject[] getCount;
	public float maxBlocks;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	//if number of blocks in scene exceed maxBlocks, destroy the oldest block
	void Update () {
		getCount = GameObject.FindGameObjectsWithTag("Block");
		if (getCount.Length > maxBlocks) {
			Destroy(getCount [0].gameObject);
		}
	}
}
