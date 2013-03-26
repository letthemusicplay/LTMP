using System;
using UnityEngine;

	public class GUIMatrix : MonoBehaviour
	{
		public int size=3;
		/// <summary>
		/// The size of rects in percent of screen dimensions.
		/// </summary>
		public float rectPercent;
		/// <summary>
		/// The position of the center of the matric, in screen percent
		/// </summary>
		public Vector2 posPercent;
		private Rect[,] rects;
	
		public void Create(){
			rects=new Rect[size,size];
			for(int i=0;i<size;i++){
				for(int j=0;j<size;j++){
					rects[i,j]=new Rect();
				
				}
			}
		}
	
		
	
	}


