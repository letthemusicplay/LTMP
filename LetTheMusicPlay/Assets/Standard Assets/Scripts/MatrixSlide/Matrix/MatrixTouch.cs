
using UnityEngine;
using System.Collections;
/**
 * Class encapsulating the matric for touch points like the unlock screen of Android Jelly Bean / ICS
 * **/
public class MatrixTouch : MonoBehaviour,InputAttackListener{
	

	// Use this for initialization
	void Create() {
	
	}
	
	void Update(){	
		
	}
	/*
	public MatrixPoint getPointOnTouch() {
		
	}*/

	//COPIED FROM UNITY, NO SENSE, TODO
	#region PatternGetter implementation
	public System.Collections.Generic.List<UnityEngine.Vector2> getPattern ()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
	        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
	        transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
		}	
	}
	#endregion
	
	//TODO
	#region InputAttackListener implementation
	public bool IsAttackDone ()
	{
		throw new System.NotImplementedException ();
	}
	//TODO
	public System.Collections.Generic.List<Vector2> NotifyPattern ()
	{
		throw new System.NotImplementedException ();
	}
	#endregion
}
