using UnityEngine;
using System.Collections;

public class GameUtil : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static Vector3 getStartPos(){
		return new Vector3(-2.799521f,-1.406677f,0);
	}
	public static Vector3 getStartLocalScale(){
		return new Vector3(12.4591f,1.0f,0);
	}
	public static GameObject findObject(string name){
		object[] objs = FindSceneObjectsOfType(typeof(GameObject));
		for(int i = 0; i < objs.Length; i++)
		{
			GameObject go = (GameObject)objs[i];
			if(go.name == name)
				return go;
		}
		return null;
	}
}
