using UnityEngine;
using System.Collections;
using FSM;
using Dreamscape;

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

	public DSStateMachine (Player p1, Player p2, BoardManager bm)
	{
		//Initialize the states
		gameStart = new FSMState("Game Start", null, new DSActionGameStart(0, 5));
		turnStart = new FSMState ("Turn Start", new DSActionTurnStart());
		turnDraw = new FSMState ("Turn Draw", new DSActionTurnDraw ());
		turnPlay = new FSMState ("Turn Play", new DSActionTurnPlay ());
		turnEnd = new FSMState ("Turn End", new DSActionTurnEnd ());
		gameOver = new FSMState("Game Over", new DSActionGameOver());

		//Initialize the transitions
		toTurnStart = new FSMTransition(turnStart, new DSActionNextTurn());
		toTurnDraw = new FSMTransition(turnDraw);
		toTurnPlay = new FSMTransition(turnPlay);
		toTurnEnd = new FSMTransition(turnEnd);
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
		init = new DSActionInit(p1, p2, bm);
		context = new FSMContext(gameStart, init);
	}

	//Functions call context.dispatch(event name, data)
	public void message(string msg, object data){
		
		//Get the current Player
		BoardManager bm = context.get ("Game Attribute Manager") as BoardManager;
		int currentPlayer = bm.CurrentPlayer;
		//Check to see it the current player is issueing the command
		if (((Player)context.get ("Player " + (currentPlayer+1))).Controller.Equals (data)) {
			context.dispatch (msg, data);
		}
	}
}
