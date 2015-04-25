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

	public DSStateMachine (Player p1, Player p2, BoardManager bm)
	{
		//Initialize the states
		gameStart = new FSMState("Game Start", null, new DSActionGameStart(0, 5));
		turnStart = new FSMState ("Turn Start", new DSActionTurnStart());
		turnDraw = new FSMState ("Turn Draw", new DSActionTurnDraw ());
		turnPlay = new FSMState ("Turn Play", new DSActionTurnPlay ());
		FSMAction responseToggle = new DSActionResponseToggle();
		turnResponse = new FSMState ("Turn Response", responseToggle, responseToggle);
		turnEnd = new FSMState ("Turn End", new DSActionTurnEnd ());
		gameOver = new FSMState("Game Over", new DSActionGameOver());

		//Initialize the transitions
		toTurnStart = new FSMTransition(turnStart, new DSActionNextTurn());
		toTurnDraw = new FSMTransition(turnDraw);
		toTurnPlay = new FSMTransition(turnPlay, new DSActionAddToStack());
		toTurnResponse = new FSMTransition(turnResponse, new DSActionAddToStack());
		toTurnEnd = new FSMTransition(turnEnd);
		toGameOver = new FSMTransition(gameOver);

		//Regiser state Transitions
		//Game Start
		gameStart.addTransition("Start Game", toTurnStart);

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
		context = new FSMContext(gameStart, new DSActionInit(p1, p2, bm));
	}

	//Functions call context.dispatch(event name, data)
	public void message(string msg, object data){
		//Check if the game is over
		if (msg.Equals("End Game")){
			context.dispatch (msg, data);
		}
		else {
			//Check if the player sending the command can play.
			//Check if there is enough resources to make the play.
			//If the card is being played some where check if there is room.
			//Check if the target(s) is legal.
			//Get the current Player
			BoardManager bm = context.get ("Game Attribute Manager") as BoardManager;
			int currentPlayer = bm.CurrentPlayer;

			//*****TEMPORARY*************
			if (data.GetType() == typeof(TurnActionData)){
				TurnActionData actionData = (TurnActionData)data;
				if (((Player)context.get ("Player " + (currentPlayer + 1))).Client.Equals (actionData.player)) {
					context.dispatch (msg, actionData);
				}
			} else
			//*****DELETE BLOCK**********

			//Check to see it the current player is issueing the command
			if (((Player)context.get ("Player " + (currentPlayer + 1))).Client.Equals (data)) {
				context.dispatch (msg, data);
			}
			checkForEndGame ();
			
			context.dispatch ("Next Turn", null);
			context.dispatch ("Start Draw", null);
			context.dispatch ("Start Play", null);
		}
	}

	/// <summary>
	/// Checks for end game.
	/// </summary>
	void checkForEndGame ()
	{
		Player player1 = (Player)context.get("Player 1");
		Player player2 = (Player)context.get("Player 2");
		if (player1.Will <= 0 || player2.SleepCycles <= 0){
			context.dispatch("End Game", player1.Client);
		}
		if (player2.Will <= 0 || player1.SleepCycles <= 0){
			context.dispatch("End Game", player2.Client);
		}
	}
}
