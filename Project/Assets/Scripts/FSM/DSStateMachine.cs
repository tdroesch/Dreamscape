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
	FSMAction init;

	//The FSM Context
	FSMContext context;

	DSStateMachine (object data)
	{
		//Initialize the states
		gameStart = new FSMState("Game Start", new DSActionStartTurn(), new DSActionEndTurn());
		lightSleep = new FSMState("Light Sleep", new DSActionStartTurn(), new DSActionEndTurn());
		deepSleep = new FSMState("Deep Sleep", new DSActionStartTurn(), new DSActionEndTurn());
		remSleep = new FSMState("REM Sleep", new DSActionStartTurn(), new DSActionEndTurn());
		gameOver = new FSMState("Game Over", new DSActionGameOver());

		nextTurn = new DSActionNextTurn();

		toLightSleep = new FSMTransition(lightSleep, nextTurn);
		toDeepSleep = new FSMTransition(deepSleep, nextTurn);
		toRemSleep = new FSMTransition(remSleep, nextTurn);
		toGameOver = new FSMTransition(gameOver);

		//Regiser state Transitions
		//Game Start
		gameStart.addTransition("Start Game", toLightSleep);

		//Light Sleep
		lightSleep.addTransition("Next Turn", toLightSleep);
		lightSleep.addTransition("Next Phase", toDeepSleep);
		lightSleep.addTransition("Game Over", toGameOver);

		//Deep Sleep
		deepSleep.addTransition("Next Turn", toDeepSleep);
		deepSleep.addTransition("Next Phase", toRemSleep);
		deepSleep.addTransition("Game Over", toGameOver);

		//REM Sleep
		remSleep.addTransition("Next Turn", toRemSleep);
		remSleep.addTransition("Next Phase", toLightSleep);
		remSleep.addTransition("Game Over", toGameOver);

		//Initialize state and context
		init = new DSActionInit(data);
		context = new FSMContext(gameStart, init);
	}

	//Functions call context.dispatch(event name, data)
}
