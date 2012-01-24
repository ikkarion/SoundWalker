using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public int gameScene;
	public int newGameScene;
	public int helpScene;
	public int creditsScene;
	

	// Use this for initialization
	protected virtual void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isClick())
			clickButton(getButtonName());
	}
	
	public static bool isClick(){
		return Input.GetMouseButtonDown(0);
	}
	
	public static string getButtonName(){
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if (!Physics.Raycast(ray,out  hit, Mathf.Infinity))
			return null;
		
		Debug.DrawLine(ray.origin, hit.point);
		
		if (!hit.rigidbody )
			return null;
		
		return hit.rigidbody.name ;
	}
	
	private void clickButton(string name){
		if(name == null)
			return;
		onClickButton(name);
	}
	
	protected virtual void onClickButton(string name){
		if(name == "ButtonContinue"){
			Application.LoadLevel(gameScene);
		}else if(name == "ButtonCredits"){
			Application.LoadLevel(creditsScene);
		}else if(name == "ButtonHelp"){
			Application.LoadLevel(helpScene);
		}else if(name == "ButtonNewGame"){
			Application.LoadLevel(newGameScene);
		}
	}
}
