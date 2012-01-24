using UnityEngine;
using System.Collections;

public class Phase : MonoBehaviour {
	public GameObject animatedNotes;
	
	private string name;
	private Animator animator;
	private bool selected = false;
	public static string str1;
	// Use this for initialization
	void Start () {
		animator = new Animator();
		name = this.gameObject.name;
	}
	void OnGUI(){
		
		GUIStyle style = new GUIStyle();
		style.fontSize = 40;
		style.font = (Font)Resources.Load("Fonts/TIMES",typeof(Font));
		style.fontStyle = FontStyle.Bold;
	
		GUI.TextField(new Rect(0, 0, 300, 200), str1 + " ", style);
		
	}
	// Update is called once per frame
	void Update () {
		if(TouchInput.isObjectClicked(this.name))
		{
			print("clicou");
			print(selected);
			if(selected){
				print("foi para o seletor de niveis");				
			}else{				
				Destroy(GameUtil.findObject("AnimatedNotes(Clone)"));
				Vector3 position = this.transform.position;
				position.y += 1;
				drawAnimatedNotes(position);
				selected = true;				
			}
		}else{
			if(TouchInput.isClicked())
				selected = false;
		}
	}
	private void drawAnimatedNotes(Vector3 position){
		Instantiate(animatedNotes,position,animatedNotes.transform.rotation);
	}
}
