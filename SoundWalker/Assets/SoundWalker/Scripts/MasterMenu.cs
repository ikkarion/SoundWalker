using UnityEngine;
using System.Collections;

public class MasterMenu : MonoBehaviour {
	
	private static Camera mainCamera;
	public int gameScene;
	public int mainMenuScene;
	
	// Use this for initialization
	void Start () {
		//SaveState.loadAll();
		//TapjoyChecker.isEnable = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isClick())
			clickButton(getButtonName());
	}
	
	private bool isClick(){
		return Input.GetMouseButtonDown (0);
	}
	
	public static string getButtonName(){
		mainCamera = Camera.main;
		RaycastHit hit = new RaycastHit();
		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
		
		if (!Physics.Raycast(ray,out  hit, Mathf.Infinity))
			return null;
		
		Debug.DrawLine(ray.origin, hit.point);
		
		if (!hit.rigidbody )
			return null;
		
		return hit.rigidbody.name ;
	}
	
	protected virtual void clickButton(string name){
		
		print(name);
		if(name == null)
			return;
		
		if(name == "ButtonStart")
			startGame();
		else if(name == "ButtonHelp")
			helpScreen();
		else if(name == "ButtonCredits")
			creditsScreen();
		else if(name == "ButtonExit")
			OnApplicationPause();
		else if(name == "ButtonRestart")
			restartGame();
		else if(name == "ButtonMainMenu")
			toMainMenu();
		else if(name == "ButtonBack")
			toMainMenu();
	}
	void toMainMenu(){
		print("Para o menu principal");
		Application.LoadLevel(mainMenuScene);
	}
	void restartGame(){
		print("Restart Game");
		Application.LoadLevel(gameScene);
	}
	void OnApplicationPause(){		
			exit();
	}
	void exit(){
		print("ButtonExit Clik");
		
		Application.Quit();
	}
	void creditsScreen(){
		print(Time.time + "clicou credits");
		Application.LoadLevel(6);
	}
	void helpScreen(){
		print(Time.time + "clicou Help");
		Application.LoadLevel(5);
	}
	
	/*private void highScores(){
		print(Time.time + "clicou High Scores");
		Application.LoadLevel((int)Commons.Scene.SELECT_LEVEL);
		FlurryBinding.logEvent( "HighScores", false );
		if(GameCenterBinding.isGameCenterAvailable())
				GameCenterBinding.showLeaderboardWithTimeScope(GameCenterLeaderboardTimeScope.AllTime);
	}
	
	private void facebook(){
		print(Time.time + "clicou Facebook");
		Application.LoadLevel((int)Commons.Scene.SELECT_LEVEL);
		FlurryBinding.logEvent( "Facebook", false );
		SharingOpportunity o = SharingOpportunity.MAIN_MENU;
		IntegrationFacebook.SendScore((int) HUD.totalScore, o);
	}*/
	
	private void startGame(){
		print(Time.time + "clicou Start");
		Application.LoadLevel(4);
	}
}
