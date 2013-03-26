
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Class encapsulating the matric for touch points like the unlock screen of Android Jelly Bean / ICS
 * **/
public class AndroidTouchListener : MonoBehaviour,InputAttackListener{
	
	private List<Vector2> points;
	private bool isAttack=false;
	// Use this for initialization
	void Create() {
	
	}
	
	public void Update(){	
		
	}
	/*
	public MatrixPoint getPointOnTouch() {
		
	}*/

	
	public List<Vector2> getPattern ()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
	        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
	     //   transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
		}	
		return null;
	}

	public bool IsAttackDone ()
	{
		return isAttack;
	}
	
	//TODO
	public List<Vector2> NotifyPattern ()
	{
		throw new System.NotImplementedException ();
	}
	
}
