using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	public bool controlsEnabled = true;
	private float maxSpeedX = 4.5f;
	
	private PlayerState state;	
	
	// Use this for initialization
	void Start () {
		state = GetComponent<PlayerState>();
	}
	
	// Update is called once per frame
	void Update () {
		if(controlsEnabled){
			control();
		}
	}
	private void control(){
		
			state.move(limitInput(GameInput.getMovement()));
		
		if(GameInput.isJumpPressed()){
			if(state.canFly())
				state.setFly(true);
			else
				state.jump();
		}
		
		if(GameInput.isJumpRelease())
			state.setFly(false);		
	}
	
	private Vector3 limitInput(Vector3 v){
		if(v.x > 0 && rigidbody.velocity.x >= maxSpeedX)
			v.x = 0;
		if(v.x < 0 && rigidbody.velocity.x <= -maxSpeedX)
			v.x = 0;
		return v;
	}
}