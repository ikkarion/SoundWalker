using UnityEngine;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour {
	private static bool checkpointActive = true;
	private static Dictionary<string, int> checkpointNote;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "Player"){
			checkpointActive = true;
		}
	}
	public static bool isActive(){
		return checkpointActive;
	}
	
	public static Dictionary<string, int> getNoteCheckpoint(){
		return checkpointNote;
	}
	public static void setNote(Dictionary<string, int> note){
		checkpointNote = note;
	}
}
