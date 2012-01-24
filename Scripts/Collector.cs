using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour {
	
	private static int catchNumber = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "NotaBebe(Clone)"){
			Destroy(other.gameObject);
			catchNumber++;
		}
	}
	public static int getCatchNumber(){
		return catchNumber;
	}
}
