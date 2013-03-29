using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseTouchListener : MonoBehaviour,InputAttackListener
{
	
	public GUIMatrix matrix;
	private List<Vector2> points;
	private Vector2 lastFirst=new Vector2(-1,-1);
	private Vector2 lastTwo=new Vector2(-1,-1);
	
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
				if(indexes!=lastFirst && indexes!= lastTwo){
					points.Add(indexes);
					//verify that we didn't just create the same segment again
					lastTwo=lastFirst;
					lastFirst=indexes;
				}else{
					//maybe make attack fail ddirectly here?
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

