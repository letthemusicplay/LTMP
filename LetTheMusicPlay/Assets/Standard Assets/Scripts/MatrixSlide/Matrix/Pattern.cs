using UnityEngine;
using System.Collections.Generic;

public class Pattern : MonoBehaviour{
	public List<Vector2> points;
	//TODO limit the possibily for configuration of vectors based on a matrix
	
	public Pattern (List<Vector2> points)
	{
		this.points = points;
	}

	
	public bool isValid(List<Vector2> toCheck){
		if(toCheck.Count!=points.Count)
			return false;
		else{
			for(int i=0;i<toCheck.Count;i++){
				if(points[i]!=toCheck[i])
					return false;
			}		
		}
		return true;
	}
	
}
