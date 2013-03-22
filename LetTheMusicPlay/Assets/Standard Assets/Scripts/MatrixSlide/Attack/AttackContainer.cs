
using System;
using UnityEngine;
using System.Collections.Generic;

public class AttackContainer{

	public List<Pattern> attacks;
	
	/**
	 * Will return the corresponding attack is exist, or null if no attack were found.
	 * 
	 * */
	public Pattern resolve(InputAttackListener pattern) {
		foreach(Pattern attack in attacks){
			if(attack.isValid(pattern.NotifyPattern()))
				return attack;
		}
		return null;
	}

}

