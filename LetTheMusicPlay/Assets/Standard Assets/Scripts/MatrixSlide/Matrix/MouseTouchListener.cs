using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseTouchListener : MonoBehaviour,InputAttackListener
{
	
	public GUIMatrix matrix;
	private List<Vector2> points;
	
	private bool inAttack=false;
	private bool attackDone=false;
	
	
	// Use this for initialization
	void Start ()
	{
		points = new List<Vector2>();
	}
	
	// Update is called once per frame
	public void Update ()
	{
		if(Input.GetMouseButtonDown(0)){
			if(!inAttack){
				inAttack=true;
				attackDone=false;
				points.Clear();
			}	
			Debug.Log(Input.mousePosition);
			Vector2 indexes= matrix.getIndexes(Input.mousePosition);
			//if a rectangle detected the touch
			if(indexes.x!=-1){
				if(!points.Contains(indexes)){
					points.Add(indexes);
				}
			}
		
		}else{
			inAttack=false;
			attackDone=true;	
		}
		foreach(Vector2 vec in points)
			Debug.Log(vec);
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

