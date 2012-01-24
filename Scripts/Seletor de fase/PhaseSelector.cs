using UnityEngine;
using System.Collections.Generic;

public class PhaseSelector : MonoBehaviour {
	public GameObject descriptionBox;
	public GameObject animateNotes;	
	public List<string> phaseNames; // continente sempre será a posição 0
	
	private List<Dictionary<string,bool>> selector;
	private Animator animator;
	private bool draw = false;
	private int i;
	// Use this for initialization
	void Start () {
		animator = new Animator();
		selector = ParseToSelector(phaseNames);
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		bool selected = selector[i][phaseNames[i]];
		if(Menu.getButtonName() == phaseNames[i] && Input.GetMouseButton(0)){			
			if(selected == true){
				
		    }else{
				deselectAll(selector);
				selected = true;
				selector[i][phaseNames[i]] = selected;
				draw = false;
				Destroy(GameUtil.findObject("AnimatedNotes(Clone)"));
				if(!draw){
					Vector3 phaseSelectedPos = GameUtil.findObject(phaseNames[i]).transform.position;
					drawAnimatedNotes(phaseSelectedPos);
					draw = true;
				}
			}
		}
		GameObject go = GameUtil.findObject("AnimatedNotes(Clone)");
		if(go != null)
			animator.animate(GameUtil.findObject("AnimatedNotes(Clone)"),0.2f,5,true);
		
		if(i >= phaseNames.Count - 1)
			i = 0;
		else i++;
	}
	private void deselectAll(List<Dictionary<string,bool>> selector){
		
		foreach(Dictionary<string, bool> dictionary in selector){
			foreach(KeyValuePair<string, bool> pair in dictionary)
				if(pair.Value == true){
					string key = pair.Key;
					selector[i][key] = false;
					print(key);
					print(selector[i][key]);
				}
		}
	}
	private List<Dictionary<string, bool>> ParseToSelector(List<string> names){
		List<Dictionary<string,bool>> selector = new List<Dictionary<string, bool>>();
		for(int i = 0; i < names.Count; i++){
			selector.Add(new Dictionary<string,bool>(){{names[i],false}});
		}
		return selector;
	}	
	private void drawAnimatedNotes(Vector3 position){
		Instantiate(animateNotes,position, animateNotes.transform.rotation);
	}
}