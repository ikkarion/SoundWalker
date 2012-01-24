using UnityEngine;
using System.Collections.Generic;

public class SideScrollCam : MonoBehaviour {
	public GameObject player;
	
	private Vector2 maxScroll = new Vector2(1,2);
	private Vector2 minScroll = new Vector2(1,2);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.y - this.transform.position.y > maxScroll.y){
			scrollUP();
		}else if(this.transform.position.y - player.transform.position.y > minScroll.y){
			scrollDOWN();
		}
		if(player.transform.position.x - this.transform.position.x > maxScroll.x){
			scrollRIGHT();
		}else if(this.transform.position.x - player.transform.position.x > minScroll.x){
			scrollLEFT();
		}
	}
	private void scroll(GameObject go){
		
	}
	private void scrollUP(){
		Vector3 pos = this.transform.position;
		pos.y = player.transform.position.y - maxScroll.y;
		this.transform.position = pos;
	}
	
	
	private void scrollDOWN(){
		Vector3 pos = this.transform.position;
		pos.y = player.transform.position.y + minScroll.y;
		this.transform.position = pos;
	}
	
	private void scrollRIGHT(){
		Vector3 pos = this.transform.position;
		pos.x = player.transform.position.x - maxScroll.x;
		this.transform.position = pos;
	}
	
	
	private void scrollLEFT(){
		Vector3 pos = this.transform.position;
		pos.x = player.transform.position.x + minScroll.x;
		this.transform.position = pos;
	}
}
