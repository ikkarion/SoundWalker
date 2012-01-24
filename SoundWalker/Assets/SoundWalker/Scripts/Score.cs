using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	private int score = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	void OnGUI(){
		
		GUIStyle style = new GUIStyle();
		style.fontSize = 40;
		style.font = (Font)Resources.Load("Fonts/TIMES",typeof(Font));
		style.fontStyle = FontStyle.Bold;
	
		GUI.TextField(new Rect(0, 0, 300, 200), Collector.getCatchNumber().ToString(), style);
	}
	// Update is called once per frame
	void Update () {
		
	
	}
}
