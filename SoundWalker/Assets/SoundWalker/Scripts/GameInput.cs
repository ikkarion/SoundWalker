using UnityEngine;
using System.Collections;

public class GameInput : MonoBehaviour{
	
	public static string str1;
	public static string str2;
	
	
	public static Vector3 getMovement(){
		Vector3 m = Vector3.zero;
		
		if(Input.GetKey(KeyCode.RightArrow) || TouchInput.isObjectPressed("SetaDireita")){
			m.x = 1;
			str1 = "apertou  direita";
		}
		else if(Input.GetKey(KeyCode.LeftArrow) || TouchInput.isObjectPressed("SetaEsquerda") ){
			m.x = -1;
			str1 = "apertou  esquerda";
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			m.y = -1;			
		}
		if(TouchInput.isObjectPressed("start")){
			str1 = "";
			str2 = "";
		}
		return m;
	}
	public static Vector3 getMobileMovement(){
		Vector3 m = Vector3.zero;
		if(Menu.isClick()){
			if(Menu.getButtonName() == "SetaDireita"){
				m.x = 1;
			}
			else if(Menu.getButtonName() == "SetaEsquerda"){
				m.x = -1;
			}
		}
		return m;
	}
	public static bool isJumpPressed(){
		
		return Input.GetKeyDown(KeyCode.Space) || TouchInput.isObjectClicked("BtnPulo");
			
	}
	
	public static bool isJumpRelease(){
		
		return Input.GetKeyUp(KeyCode.Space) || !TouchInput.isObjectClicked("BtnPulo");
	}
	
	public static bool isMoveKeyPressed(){
		Vector3 v = getMovement();
		return v.x != 0;
	}
}