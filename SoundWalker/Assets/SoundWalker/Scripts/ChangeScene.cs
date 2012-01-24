using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	
	public int scene;
	
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(TouchInput.isObjectClicked(this.gameObject.name))
			Application.LoadLevel(scene);
	}
}
