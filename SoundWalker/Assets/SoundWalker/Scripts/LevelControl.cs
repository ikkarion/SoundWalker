using UnityEngine;
using System.Collections.Generic;
using System.IO;
public class LevelControl : LevelDesign {
	public GameObject checkpoint;
	public GameObject plataform;
	public GameObject kidNote;
	public GameObject finishPlataform;
	public GameObject player;
	
	public float maxWidth;
	public float minWidth;
	
	public float deltaX;
	public float deltaY;
	
	public float deltaScaleX;
	
	public int level;
	
	private List<GameObject> plataforms;	
	private List<Dictionary<string, int>> phase;
	private int noteNumber;
	
	// Use this for initialization
	void Start () {
		plataforms = new List<GameObject>();
		phase = loadLevel(level);		
		noteNumber = 0;
		
		adjustFinishPlataform();
	}
	// Update is called once per frame
	void Update () {
			fromStart();
	}
	
	private void fromStart(){
		float initTime = (Time.timeSinceLevelLoad*1000)/getMusicTick();
		if(audio.isPlaying){
			
			
			if(initTime >= phase[noteNumber]["time"]){
					if(phase[noteNumber]["show"] == 1){						
						drawPlataform(phase[noteNumber]["note"],noteNumber);
					}else{
						destroyPlataform(phase[noteNumber]["note"]);
					}
				if(noteNumber != phase.Count-1)
					noteNumber++;
			}
			if(isPlayerFalling())
				RestartLevel();
		}
	}
	private void destroyPlataform(int note){
		foreach(GameObject go in plataforms){
			if(go.name == note.ToString()){
				plataforms.Remove(go);
				Destroy(go,7.0f);
				return;
			}
		}
	}
	private int getNotePosX(int noteNumber){
		return (int)(((deltaX*noteNumber) + GameUtil.getStartLocalScale().x) - (maxWidth*2));
	}
	private int getNotePosY(int note){
		return (int)((deltaY*(note - getFirstNote())) + GameUtil.getStartPos().y);
	}
	private Vector3 getPlataformScale(int noteNumber){		
		float dimX = ((float)(getMaxDuration()/getMusicTick()) -  ((float)phase[noteNumber]["duration"]/getMusicTick())) * deltaScaleX;
		
		if(dimX < 1.1f)
			dimX = minWidth;
		else
			if(dimX > 1.1f)
				dimX = maxWidth;
		
		return new Vector3(dimX,0.3f,1);
	}
	private void drawPlataform(int note, int noteNumber){		
		int posx = getNotePosX(noteNumber);
		int posy =  getNotePosY(note);
		
		GameObject go = (GameObject)Instantiate(plataform,new Vector3(posx,posy,0), plataform.transform.rotation);		
		go.name = note.ToString();
		go.transform.localScale = getPlataformScale(noteNumber);
		plataforms.Add(go);
		drawKidNote(new Vector3(posx,posy,0));
	}
	private void drawKidNote(Vector3 position){
		position.y += 0.5f;
		Instantiate(kidNote,position,kidNote.transform.rotation);
	}
	private void adjustFinishPlataform(){
		float posX = ((deltaX*phase.Count) + finishPlataform.transform.localScale.x) + minWidth;
		float posy = getNotePosY(getLastNote()) + 2;
		
		finishPlataform.transform.position = new Vector3(posX,posy,0);
	}
	private void RestartLevel(){
		audio.Stop();
		destroyAllPlataforms();
		Application.LoadLevel(Application.loadedLevel);
	}
	private void destroyAllPlataforms(){
		foreach(GameObject go in plataforms)
			Destroy(go);
	}
	private bool isPlayerFalling(){
		return PlayerPhysics.getPosition().y < -60;
	}
}