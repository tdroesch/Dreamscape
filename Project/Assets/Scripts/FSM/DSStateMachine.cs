using UnityEngine;
using System.Collections;
using FSM;

class DSStateMachine {

	//The States
	FSMState gameStart;
	FSMState lightSleep;
	FSMState deepSleep;
	FSMState remSleep;
	FSMState gameOver;

	//The Transitions
	FSMTransition toLightSleep;
	FSMTransition toDeepSleep;
	FSMTransition toRemSleep;
	FSMTransition toGameOver;

	//The Actions
	FSMAction nextTurn;
	FSMAction startTurn;
	FSMAction endTurn;
	FSMAction endGame;
	/// <summary>
	/// The initializing action
	/// </summary>
	FSMAction init;
		
	/// <summary>
	/// The context of the statemachine.
	/// This stores values like who's turn it is.
	/// </summary>
	FSMContext context;

	DSStateMachine (object data)
	{

	}
}
