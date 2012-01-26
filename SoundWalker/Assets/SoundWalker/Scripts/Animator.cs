using UnityEngine;
using System.Collections;

public class Animator : MonoBehaviour{
	public float animateTime;
	public float frameSize;
	public int totalFrames;
	public bool isVerticalAnimation;
	
	private float initTime;
	private float lastTime;
		
	private int currentFrame;	
	private float frame;
	
	private bool animated = false;
	
	// Use this for initialization
	void Start () {		
		initTime = 0;
		lastTime = Time.time;
				
		currentFrame = 0;
		frame = 0;
		
	}
	public void animate(GameObject gameObject,float frameSize, int totalFrames, bool isVerticalAnimation){
		if(isVerticalAnimation)
			verticalFrameAnimation( gameObject,frameSize,  totalFrames);
		else
			orizontalFrameAnimation( gameObject, frameSize,  totalFrames);
	}
	// Update is called once per frame
	void Update () {
		if(isVerticalAnimation)
			verticalFrameAnimation(this.gameObject,frameSize,totalFrames);
		else
			orizontalFrameAnimation(this.gameObject,frameSize,totalFrames);
		
	}
	private void verticalFrameAnimation(GameObject gameObject,float frameSize, int totalFrames){
		initTime = Time.time*1000;
		if(initTime - lastTime >= animateTime){
			lastTime = Time.time*1000;
			if(currentFrame >= totalFrames){
				currentFrame = 0;
			}
			frame = frameSize * currentFrame;
			currentFrame++;
			
			gameObject.renderer.material.mainTextureOffset = new Vector2(0,frame);
		}
	}
	private void orizontalFrameAnimation(GameObject gameObject,float frameSize, int totalFrames){
		
		initTime = Time.time*1000;
		if(initTime - lastTime >= animateTime){
			lastTime = Time.time*1000;
			if(currentFrame >= totalFrames){
				currentFrame = 0;
			}
			frame = frameSize * currentFrame;
			currentFrame++;
			
			gameObject.renderer.material.mainTextureOffset = new Vector2(frame,0);
		}
	}
}
