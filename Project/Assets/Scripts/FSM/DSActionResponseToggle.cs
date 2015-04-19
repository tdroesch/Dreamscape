using UnityEngine;
using System.Collections;
using FSM;
using Dreamscape;

class DSActionResponseToggle : FSMAction {
	public void execute (FSMContext context, object data)
	{
		BoardManager bm = context.get ("Game Attribute Manager") as BoardManager;
		bm.WaitingForResponse = !bm.WaitingForResponse;
		if (bm.WaitingForResponse){
			((TurnActionData)data).responseTimeCallback(15.0f);
		}
	}
}

