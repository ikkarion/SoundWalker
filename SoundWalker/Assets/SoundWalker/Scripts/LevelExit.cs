using UnityEngine;
using System.Collections;

public class LevelExit: MonoBehaviour {
	public int nextLevelScene;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.name == "Player")
			Application.LoadLevel(nextLevelScene);
	}
}
