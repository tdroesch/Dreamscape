using System;
using FSM;

class DSActionNextTurn : FSMAction {

	public void execute (FSMContext context, object data)
	{
		GameAttrManager gam = context.get("Game Attribute Manager") as GameAttrManager;
		if (gam != null) {
			gam.nextPlayer ();
			gam.PhaseTurns--;
		}
	}

	public DSActionNextTurn ()
	{

	}
}

