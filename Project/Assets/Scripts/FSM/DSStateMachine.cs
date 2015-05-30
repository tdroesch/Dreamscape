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
	FSMState turnResponse;
	FSMState turnEnd;
	FSMState gameOver;

	//The Transitions
	FSMTransition toGameStart;
	FSMTransition toTurnStart;
	FSMTransition toTurnDraw;
	FSMTransition toTurnPlay;
	FSMTransition toTurnResponse;
	FSMTransition toTurnEnd;
	FSMTransition toGameOver;
//
//	//The Actions
//	FSMAction nextTurn;
//	FSMAction init;
//	FSMAction startGame;

	//The FSM Context
	FSMContext context;

	public DSStateMachine (IClient p1, IClient p2, BoardManager bm)
	{
		//Initialize the states
		gameStart = new FSMState ("Game Start", null, new DSActionGameStart (0, 5));
		turnStart = new FSMState ("Turn Start", new DSActionTurnStart ());
		turnDraw = new FSMState ("Turn Draw", new DSActionTurnDraw ());
		turnPlay = new FSMState ("Turn Play", new DSActionTurnPlay ());
		FSMAction responseToggle = new DSActionResponseToggle ();
		turnResponse = new FSMState ("Turn Response", responseToggle, responseToggle);
		turnEnd = new FSMState ("Turn End", new DSActionTurnEnd ());
		gameOver = new FSMState ("Game Over", new DSActionGameOver ());

		//Initialize the transitions
		toGameStart = new FSMTransition (gameStart, new DSActionInitPlayer ());
		toTurnStart = new FSMTransition (turnStart, new DSActionNextTurn ());
		toTurnDraw = new FSMTransition (turnDraw);
		toTurnPlay = new FSMTransition (turnPlay, new DSActionAddToStack ());
		toTurnResponse = new FSMTransition (turnResponse, new DSActionAddToStack ());
		toTurnEnd = new FSMTransition (turnEnd);
		toGameOver = new FSMTransition (gameOver);

		//Regiser state Transitions
		//Game Start
		gameStart.addTransition ("Start Game", toTurnStart);
		gameStart.addTransition ("Init Player", toGameStart);

		//Main Game Loop
		turnStart.addTransition ("Start Draw", toTurnDraw);
		turnDraw.addTransition ("Start Play", toTurnPlay);
		turnPlay.addTransition ("Turn Action", toTurnResponse);
		turnResponse.addTransition ("Turn Action", toTurnPlay);
		turnResponse.addTransition ("End Response", toTurnPlay);
		turnPlay.addTransition ("Start End", toTurnEnd);
		turnEnd.addTransition ("Next Turn", toTurnStart);

		//EndGame transitions
		turnStart.addTransition ("End Game", toGameOver);
		turnDraw.addTransition ("End Game", toGameOver);
		turnPlay.addTransition ("End Game", toGameOver);
		turnEnd.addTransition ("End Game", toGameOver);



		//Initialize state and context
		context = new FSMContext (gameStart, new DSActionInit (p1, p2, bm));
	}

	//Functions call context.dispatch(event name, data)
	public void message (string msg, object data)
	{
		//Get the current Player
		BoardManager bm = context.get ("Game Attribute Manager") as BoardManager;
		int currentPlayer = bm.CurrentPlayer;
		// Handle different message types with a switch statement
		switch (msg) {
		case "End Game":
			context.dispatch (msg, data);
			break;
		case "Init Player":
			context.dispatch (msg, data);
			if (context.get ("Player 1").GetType() == typeof(Player) && context.get ("Player 2").GetType() == typeof(Player)){
				context.dispatch("Start Game", null);
			}
			break;
		// Check if the player asking for the action can make the action.
		// Cast the data as TurnActionData to get access to the player field.
		case "Turn Action":
			TurnActionData actionData = (TurnActionData)data;
			if (((Player)context.get ("Player " + (currentPlayer + 1))).Client.Equals (actionData.player)) {
				context.dispatch (msg, actionData);
			}
			checkForEndGame ();
			break;
		// Check if the player asking for the action can make the action.
		default:
			if (((Player)context.get ("Player " + (currentPlayer + 1))).Client.Equals (data)) {
				context.dispatch (msg, data);
			}
			checkForEndGame ();
			break;
		}
	}

	/// <summary>
	/// Checks for end game.
	/// </summary>
	void checkForEndGame ()
	{
		Player player1 = (Player)context.get ("Player 1");
		Player player2 = (Player)context.get ("Player 2");
		if (player1.Will <= 0 || player2.SleepCycles <= 0) {
			context.dispatch ("End Game", player1.Client);
		}
		if (player2.Will <= 0 || player1.SleepCycles <= 0) {
			context.dispatch ("End Game", player2.Client);
		}
		context.dispatch ("Next Turn", null);
		context.dispatch ("Start Draw", null);
		context.dispatch ("Start Play", null);
	}
}
