using UnityEngine;
using System.Collections;
/**
 * Will try to resolve any attack that was made and see if one is valid or not.
 * 
 * 
 * */
public class AttackHandler : MonoBehaviour
{
	private AttackContainer attacks;	
	private InputAttackListener inputListener;
	private AttackSolver solver;
	
	// Use this for initialization
	void Start ()
	{
	//TODO instanciate every objects, see how this could go.
	}
	
	// Update is called once per frame
	void Update ()
	{
		inputListener.Update();
		if(inputListener.IsAttackDone()){
			Pattern temp=attacks.resolve(inputListener);
			if(temp==null)
				solver.onFail();
			else
				solver.onSuccess(temp);
		}
	}
}

