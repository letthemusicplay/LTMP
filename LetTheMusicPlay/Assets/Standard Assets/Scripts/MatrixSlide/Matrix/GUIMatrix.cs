using System;
using UnityEngine;

	public class GUIMatrix : MonoBehaviour
	{
		public int size=3;
		/// <summary>
		/// The size of rects in percent of screen dimensions.
		/// </summary>
		public float rectPercent;
		private Rect[,] rects;
	
		public void Create(){
			rects=new Rect[size,size];
			
			for(int i=0;i<size;i++){
				for(int j=0;j<size;j++){
					Vector2 pixelPos=new Vector2(transform.position.x*Screen.width,transform.position.y*Screen.height);
					Vector2 rectDimension=new Vector2((transform.localScale.x*Screen.width)/size,(transform.localScale.y*Screen.height)/size);				
					rects[i,j]=NewRect(pixelPos.x-rectDimension.x*(i-size/2),pixelPos.y-rectDimension.y*(j-size/2));	
				}
					
			}
		}
	
		public Rect NewRect(float centerX, float centerY, float width,float height){
			return new Rect(centerX-width/2,centerY-height/2,width,height);
		}
	
	}


