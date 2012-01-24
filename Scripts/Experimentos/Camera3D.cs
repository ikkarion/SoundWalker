using UnityEngine;
using System.Collections;

public class Camera3D : MonoBehaviour {
	
	private float frequence = 0.05f;
	private float deltaX = 0.01f;
	private float time;
	private float signal;
	public Transform target;
	
	// Use this for initialization
	void Start () {
		time = Time.time;
		signal = 1;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(Time.time > time + frequence){
			Vector3 pos = transform.position;
			signal = - signal;
			pos.x += signal*deltaX;
			time = Time.time;
			transform.position = pos;
			print(Time.time + "mudou"+transform.position.x);
		}
		if(target !=null)
			transform.LookAt(target);
	}
}
