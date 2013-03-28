using System;
using UnityEngine;

public class GUIMatrix : MonoBehaviour
{
		
	public static readonly bool DEBUG = true;
	public int size = 3;
	/// <summary>
	/// The size of rects in percent of screen dimensions.
	/// </summary>
	public float rectPercent;
	public Texture pointTexture;
	private Rect[,] rects;
	
	void Start ()
	{
		rects = new Rect[size, size];
		for (int i=0; i<size; i++) {
			for (int j=0; j<size; j++) {	
				Vector2 pixelPos = new Vector2 (transform.position.x * Screen.width, transform.position.y * Screen.height);
				Vector2 rectDimension = new Vector2 ((transform.localScale.x * Screen.width) / size, (transform.localScale.y * Screen.height) / size);				
				rects [i, j] = NewRect (pixelPos.x + rectDimension.x * (i - size / 2), pixelPos.y - rectDimension.y * (j - size / 2), rectDimension.x * rectPercent, rectDimension.y * rectPercent);	
			}
		}
	}
	
	void Update ()
	{			
	}
	
	void OnGUI ()
	{
		for (int i=0; i<size; i++) {
			for (int j=0; j<size; j++) {	
				GUI.DrawTexture (rects [i, j], pointTexture);
			}	
		}
	}
	
	public Vector2 getIndexes (Vector2 touch)
	{			
		for (int i=0; i<size; i++) {
			for (int j=0; j<size; j++) {
				if (rects [i, j].Contains (touch))
					return new Vector2 (i, j);
			}
		}
		return new Vector2 (-1, -1);
	}
	
	public Rect NewRect (float centerX, float centerY, float width, float height)
	{
		return new Rect (centerX - width / 2, centerY - height / 2, width, height);
	}
	
}

