using UnityEngine;
using System.Collections;
using FSM;
using Dreamscape;

class DSActionAddToStack : FSMAction {
	public void execute (FSMContext context, object data)
	{
		if (data != null) {
			BoardManager bm = context.get ("Game Attribute Manager") as BoardManager;
			bm.PushStack ((TurnActionData)data);
		}
	}
}

