using System;

	/**
	 * 
	 * Will handle the actions on a succeed or fail of an attack, to separate gameplay from input routine.
	 * */
	public interface AttackSolver
	{
		void onFail();
		void onSuccess(Pattern pattern);
	
	}


