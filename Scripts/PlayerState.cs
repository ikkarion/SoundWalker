using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {
	
	
	private bool fly = true;
	private int maxJumps = 2;
	private float extraJumpReduction = 0.85f;
	private float acceleration = 1f;
	private float jumpAcceleration = 12.5f;
	private Vector3 flyMaxSpeed = new Vector3(1.7f, 0.2f);
	private float spriteScale = 0.0156f;
	
	private bool _onGround;
	private int countJump;
	private bool _onFly;
	
	[System.Serializable]
    public class Poses{
		public Texture normal;
		public Texture doubleJump;
		public Texture fly;
		public Texture dead;
	}
	
	public Poses poses;

	// Use this for initialization
	void Start () {
		_onGround = true;
		_onFly = false;
		countJump = 0; 
		setPose(poses.normal);
		
	}
	
	// Update is called once per frame
	void Update () {	
		if(_onFly)
			flying();
		else setFlip();
	}
	
	void OnCollisionEnter (Collision hit)
	{
		if(hit.gameObject.tag == "Floor")
	    {
	    	setOnGround(true);
	    }
	}
	
	void OnCollisionExit (Collision hit)
	{
		if(hit.gameObject.tag == "Floor")
	    {
	    	setOnGround(false);
	    }
	}
	
	private void setOnGround(bool b){
		if(b && !_onGround){
			countJump = 0;
			setPose(poses.normal);
		}
		_onGround = b;
	}
	
	public bool isOnGround(){
		return _onGround;
	}
		
	
	public void move(Vector3 inputMovement){
		Vector3 force = inputMovement.normalized*acceleration;		
		rigidbody.AddForce(force*Time.deltaTime*1000f, ForceMode.Acceleration);
	}
	
	public void jump(){
		if(countJump >= maxJumps)
			return;
		Vector3 v = rigidbody.velocity;
		v.y = 0;
		rigidbody.velocity = v;
		Vector3 f = Vector3.up*jumpAcceleration*Mathf.Pow(extraJumpReduction,countJump);
		rigidbody.AddForce(f, ForceMode.Impulse);
		countJump++;
		if(countJump > 1)
			setPose(poses.doubleJump);
	}
	
	private void setFlip(){
		Vector3 m = GameInput.getMovement();
		Vector3 s = transform.localScale;
		if(m.x == - s.x/Mathf.Abs(s.x)){
			s.x = m.x;
			transform.localScale = s;
		}
	}
	
	public bool canFly(){
		return fly && countJump >= maxJumps;
	}
	
	public void setFly(bool b){
		if(_onFly != b){
			if(b)
				setPose(poses.fly);
			else setPose(poses.normal);
		}
		_onFly = b;
	}
	
	private void flying(){
		Vector3 v = rigidbody.velocity;
		bool flag = false;
		if(v.y < -flyMaxSpeed.y){
			v.y = -flyMaxSpeed.y;
			flag = true;
		}
		if(v.x < -flyMaxSpeed.x){
			v.x = -flyMaxSpeed.x;
			flag = true;
		}else if(v.x > flyMaxSpeed.x){
			v.x = flyMaxSpeed.x;
			flag = true;
		}
		if(flag)
			rigidbody.velocity = v;
	}
	
	private void setPose(Texture t){
		renderer.material.mainTexture = t;
		Vector3 s = transform.lossyScale;
		Vector3 p = transform.position;
		s.z = t.width*spriteScale;
		s.y = t.height*spriteScale;
		p.y -= (transform.lossyScale.y - s.y)/2;
		transform.localScale = s;
		transform.position = p;
		//print(Time.time+"w="+t.width+"h="+t.height);
	}
}
