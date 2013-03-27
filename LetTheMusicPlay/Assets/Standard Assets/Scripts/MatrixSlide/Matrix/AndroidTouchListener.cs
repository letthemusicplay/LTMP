
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Class encapsulating the matric for touch points like the unlock screen of Android Jelly Bean / ICS
 * **/
public class AndroidTouchListener : MonoBehaviour,InputAttackListener{
	
	public GUIMatrix matrix;
	private List<Vector2> points;
	
	private bool inAttack=false;
	private bool attackDone=false;
	
	
	// Use this for initialization
	void Start() {
		points = new List<Vector2>();
	}
	
	public void Update(){	
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Debug.Log("touch!");
			
			if(!inAttack){
				inAttack=true;
				attackDone=false;
				points.Clear();
			}
		
			Vector2 indexes= matrix.getIndexes(Input.GetTouch(0).position);
			//if a rectangle detected the touch
			if(indexes.x!=-1){
				if(!points.Contains(indexes)){
					points.Add(indexes);
				}
			}
			
		}else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
			inAttack=false;
			attackDone=true;
		}
	}
	
	public bool IsAttackDone ()
	{
		return attackDone;
	}
	
	//TODO
	public List<Vector2> NotifyPattern ()
	{
		return points;
	}
	
}
