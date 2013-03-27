
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Class encapsulating the matric for touch points like the unlock screen of Android Jelly Bean / ICS
 * **/
public class AndroidTouchListener : MonoBehaviour,InputAttackListener{
	
	public GUIMatrix matrix;
	private List<Vector2> points;
	
	private bool isAttack=false;
	
	
	// Use this for initialization
	void Create() {
		points = new List<Vector2>();
	}
	
	public void Update(){	
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			if(!isAttack){
				Vector2 indexes= matrix.getIndexes(Input.GetTouch(0).position);
				//if a rectangle detected the touch
				if(indexes.x!=-1){
					if(!points.Contains(indexes)){
						points.Add(indexes);
					}
				}
			}
		}else if(Input.GetTouch(0).phase == TouchPhase.Ended){
			isAttack=true;
		}
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
		isAttack=false;
		List<Vector2>output=new List<Vector2>(points);
		points.Clear();
		return output;
	}
	
}
