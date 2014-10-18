using UnityEngine;
using System.Collections;
using FSM;
/// <summary>
/// Initialize the Dreamscape Finite State Machine.
/// </summary>
class DSActionInit : FSMAction {
	object data;
	public void execute (FSMContext context, object data){

	}

	DSActionInit(object data){
		this.data = data;
	}
}
