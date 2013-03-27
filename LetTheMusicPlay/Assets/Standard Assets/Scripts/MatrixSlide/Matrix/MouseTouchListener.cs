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
	public void OnGUI ()
	{
		if(Event.current.type==EventType.MouseDrag){
			if(!inAttack){
				inAttack=true;
				attackDone=false;
				points.Clear();
			}	
			Vector2 indexes= matrix.getIndexes(Event.current.mousePosition);
			//if a rectangle detected the touch
			if(indexes.x!=-1){
				if(!points.Contains(indexes)){
					points.Add(indexes);
				}
			}
		
		}else if(Event.current.type==EventType.MouseUp){
			inAttack=false;
			attackDone=true;	
		}
		foreach(Vector2 vec in points){
			Debug.Log(vec);
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

