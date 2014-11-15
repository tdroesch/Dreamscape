using System;
using FSM;

class DSActionNextTurn : FSMAction {

	public void execute (FSMContext context, object data)
	{
		GameManager gm = context.get("Game Manager") as GameManager;
		if (gm != null) {
			gm.nextPlayer ();
			gm.PhaseTurns--;
		}
	}

	public DSActionNextTurn ()
	{

	}
}

