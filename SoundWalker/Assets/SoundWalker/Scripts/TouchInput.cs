using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour {

	private static List<string> objectNames;
	
	private static float lastUpdate;
	private static float deltaTime = 0.010f; // update name frequency
	private static List<string> objectNamesBegan;

	
	void Awake(){
		lastUpdate = 0;
	}
	// Use this for initialization
	void Start () {
		Input.multiTouchEnabled = true; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static bool isClicked(){
		if(objectNamesBegan == null) return false;
		return objectNamesBegan.Count > 0;
	}
	public static bool isObjectPressed(string name){
		tryUpdateNames();
		return haveName(name);
	}
	public static bool isObjectClicked(string name){
		tryUpdateNames();
		return haveNameBegan(name);
	}
	private static bool haveNameBegan(string name){
		if(objectNamesBegan == null) return false;
		foreach(string word in objectNamesBegan)
			if(name == word)
				return true;		
		
		return false;
	}
	private static bool haveName(string name){
		if(objectNames == null) return false;
		foreach(string word in objectNames)
			if(name == word)
				return true;
		return false;
	}
	
	private static void tryUpdateNames(){
		if( Time.time - lastUpdate > deltaTime){
			setObjectNames();
			lastUpdate = Time.time;
		}
	}
	
	/*private static void setObjectNames(){
		objectNames = new List<string>();
		foreach(Touch t in Input.touches){
			string name = getButtonName(t.position);
			if(name != null)
				objectNames.Add(name);
		}
	}*/
	private static void setObjectNames(){
		objectNames = new List<string>();
		objectNamesBegan = new List<string>();
		for (int i = 0; i < Input.touchCount; i++){			
			Touch t = Input.GetTouch(i);
			string name = getButtonName(t.position);
			if(name != null)
				objectNames.Add(name);
			if (Input.GetTouch( i ) .phase == TouchPhase.Began)
				objectNamesBegan.Add(name);
		}
		if(Input.GetMouseButton( 0 )){
			string name2 = getButtonName( Input.mousePosition );
			if(name2 != null)
				objectNames.Add(name2);
		}
		if(Input.GetMouseButtonDown( 0 ) ){
			string name3 = getButtonName( Input.mousePosition );
			if(name3 != null)
				objectNamesBegan.Add(name3);
		}

	}

	private static string getButtonName(Vector3 position){
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay(position);
		
		if (!Physics.Raycast(ray,out  hit, Mathf.Infinity))
			return null;
		
		Debug.DrawLine(ray.origin, hit.point);
		
		if (!hit.rigidbody )
			return null;
		
		return hit.rigidbody.name ;
	}
	

	
}
