using UnityEngine;
using System.Collections;
using FSM;

class DSStateMachine {

	//The States
	FSMState gameStart;
	FSMState turnStart;
	FSMState turnDraw;
	FSMState turnPlay;
	FSMState turnEnd;
	FSMState gameOver;

	//The Transitions
	FSMTransition toTurnStart;
	FSMTransition toTurnDraw;
	FSMTransition toTurnPlay;
	FSMTransition toTurnEnd;
	FSMTransition toGameOver;

	//The Actions
	FSMAction nextTurn;
	FSMAction init;
	FSMAction startGame;

	//The FSM Context
	FSMContext context;

	public DSStateMachine (Player p1, Player p2, GameAttrManager gam)
	{
		//Initialize the states
		gameStart = new FSMState("Game Start", new DSActionGameStart(0, 5));
		turnStart = new FSMState ("Turn Start", new DSActionTurnStart());
		turnDraw = new FSMState ("Turn Draw", new DSActionTurnDraw ());
		turnPlay = new FSMState ("Turn Play", new DSActionTurnPlay ());
		turnEnd = new FSMState ("Turn End", new DSActionTurnEnd ());
		gameOver = new FSMState("Game Over", new DSActionGameOver());

		//Initialize the transitions
		toTurnStart = new FSMTransition(turnStart);
		toTurnDraw = new FSMTransition(turnDraw);
		toTurnPlay = new FSMTransition(turnPlay);
		toTurnEnd = new FSMTransition(turnEnd, new DSActionNextTurn());
		toGameOver = new FSMTransition(gameOver);

		//Regiser state Transitions
		//Game Start
		gameStart.addTransition("Start Game", toTurnStart);

		//Main Game Loop
		turnStart.addTransition ("Start Draw", toTurnDraw);
		turnDraw.addTransition ("Start Play", toTurnPlay);
		turnPlay.addTransition ("Start End", toTurnEnd);
		turnEnd.addTransition ("Next Turn", toTurnStart);

		//EndGame transitions
		turnStart.addTransition ("End Game", toGameOver);
		turnDraw.addTransition ("End Game", toGameOver);
		turnPlay.addTransition ("End Game", toGameOver);
		turnEnd.addTransition ("End Game", toGameOver);



		//Initialize state and context
		init = new DSActionInit(p1, p2, gam);
		context = new FSMContext(gameStart, init);
	}

	//Functions call context.dispatch(event name, data)
}
