
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Class encapsulating the matric for touch points like the unlock screen of Android Jelly Bean / ICS
 * **/
public class AndroidTouchListener : MonoBehaviour,InputAttackListener{
	
	public GUIMatrix matrix;
	private List<Vector2> points;
	private Vector2 lastFirst=new Vector2(-1,-1);
	private Vector2 lastTwo=new Vector2(-1,-1);
	
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
				if(indexes!=lastFirst && indexes!= lastTwo){
					points.Add(indexes);
						//verify that we didn't just create the same segment again
					lastTwo=lastFirst;
					lastFirst=indexes;
				}else{
					//maybe make attack fail ddirectly here?
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
