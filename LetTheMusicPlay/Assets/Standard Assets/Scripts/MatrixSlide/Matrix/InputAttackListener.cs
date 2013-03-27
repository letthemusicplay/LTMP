using System;
using UnityEngine;
using System.Collections.Generic;

	public interface InputAttackListener
	{
		
		/**
		 * will return true if attack if finished (for instance android touch is not down anymore.
		 * */
		bool IsAttackDone();
	
		/**
		 * will return a list of 2D points from which the attack went .
		 * These points must use matrix coordinates, not screen coordinates, nor space coordinates.
		 * 
		 * For instance, a point must be defined like this:
		 * <code>
		 * 		//this will be the first point on the second line
		 * 		Vector2 point =new Vector2(1,2);
		 * </code>
		 * */
		List<Vector2> NotifyPattern();
	}


