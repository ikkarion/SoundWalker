using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {
	
	private float maxSpeedY = 400f;
	private float gravity = -21f;
	private float airReistence = 0.7f ;
	
	private PlayerState state;
	private static Vector3 position;
	// Use this for initialization
	void Start () {
		rigidbody.useGravity = false;
		state = GetComponent<PlayerState>();
	}
	
	// Update is called once per frame
	void Update () {
		position = transform.position;
		applyGravity();
		speedLimit();
		if(onHorizontalMove()){
			if(state.isOnGround()){
				if(!GameInput.isMoveKeyPressed())
					autoBreake();
			}
		}
		if(!state.isOnGround())
			setAirResistence(true);
		else setAirResistence(false);
	}
	
	
	private void applyGravity(){
		rigidbody.AddForce(Vector3.up*gravity, ForceMode.Acceleration);
	}
	
	private void speedLimit(){
		Vector3 v = rigidbody.velocity;
		if(v.y < -maxSpeedY){
			v.y = -maxSpeedY;
			rigidbody.velocity = v;
		}
	}
	
	private bool onHorizontalMove(){
		return Mathf.Abs(rigidbody.velocity.x) > 0.06f;
	}
	
	
	private void autoBreake(){
		float x = rigidbody.velocity.x;
		x = -x/Mathf.Abs(x);
		Vector3 m = new Vector3(x,0,0);
		state.move(m);
	}
	
	private void setAirResistence(bool b){
		if(b)
			rigidbody.drag = airReistence;
		else rigidbody.drag = 0;
	}
	
	public static Vector3 getPosition(){
		return position;
	}
}