using UnityEngine;
using System.Collections;

public class Attractor : MonoBehaviour {
	
	public float radius;
	public float force;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Collider[]cols = Physics.OverlapSphere(transform.position, radius);
		foreach(Collider col in cols){
			//print(Time.time+"loop");
			if( col.gameObject.name == "Player" ) {
				Vector3 direction = transform.position - col.gameObject.transform.position;
				direction.Normalize();
				col.gameObject.rigidbody.AddForce(force*direction);
				print(Time.time+"atraindo");
				break;
			}
		}
	}
	
	
}
