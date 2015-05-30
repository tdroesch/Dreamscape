using UnityEngine;
using System.Collections;
using FSM;

namespace Dreamscape
{
	/// <summary>
	/// <para>Board manager.</para>
	/// <para>Stores information that will be shared between both players
	/// and current and next player data.</para>
	/// <para></para>
	/// <para>Properties: CurrentPlayer, NextPlayer</para>
	/// <para>Accessors: int PlayerHealth(int), int PlayerResource(int), int PlayerDeckSize(int)
	/// 	int PlayerHandSize(int), Field PlayerField(int), Subconscious PlayerDiscard(int)</para>
	/// </summary>
	class BoardManager {
		//Player Turn data
		int currentPlayer;
		int nextPlayer;
		bool waitingForResponse;
	
		/// <summary>
		/// Gets the current player.
		/// </summary>
		/// <value>The current player.</value>
		public int CurrentPlayer {
			get{ return currentPlayer;}
		}
	
		/// <summary>
		/// Gets or sets the next player.
		/// </summary>
		/// <value>The next player.</value>
		public int NextPlayer {
			get{ return nextPlayer;}
			set{ nextPlayer = value;}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Dreamscape.BoardManager"/> waiting for response.
		/// </summary>
		/// <value><c>true</c> if waiting for response; otherwise, <c>false</c>.</value>
		public bool WaitingForResponse {
			get{ return waitingForResponse;}
			set{ waitingForResponse = value;}
		}
	
	
		//Board Data
		Player player1;
		Player player2;
		Stack actionStack;
	
		/// <summary>
		/// Gets the Players current health.
		/// </summary>
		/// <returns>The health.</returns>
		/// <param name="player">Player 1 or 2.</param>
		public int GetPlayerHealth (int player)
		{
			if (player == 1) {
				return player1.Will;
			} else if (player == 2) {
				return player2.Will;
			} else {
				return int.MinValue;
			}
		}
	
		/// <summary>
		/// Gets the Players current resources.
		/// </summary>
		/// <returns>The resource.</returns>
		/// <param name="player">Player 1 or 2.</param>
		public int GetPlayerResource (int player)
		{
			if (player == 1) {
				return player1.Imagination;
			} else if (player == 2) {
				return player2.Imagination;
			} else {
				return int.MinValue;
			}
		}
	
		/// <summary>
		/// Gets the size of the player deck.
		/// </summary>
		/// <returns>The player deck size.</returns>
		/// <param name="player">Player 1 or 2.</param>
		public int GetPlayerDeckSize (int player)
		{
			if (player == 1) {
				return player1.DeckSize;
			} else if (player == 2) {
				return player2.DeckSize;
			} else {
				return int.MinValue;
			}
		}
	
		/// <summary>
		/// Gets the size of the player hand.
		/// </summary>
		/// <returns>The player hand size.</returns>
		/// <param name="player">Player 1 or 2.</param>
		public int GetPlayerHandSize (int player)
		{
			if (player == 1) {
				return player1.HandSize;
			} else if (player == 2) {
				return player2.HandSize;
			} else {
				return int.MinValue;
			}
		}
	
		/// <summary>
		/// Gets the player field.
		/// </summary>
		/// <returns>The player field.</returns>
		/// <param name="player">Player 1 or 2.</param>
		public Field GetPlayerField (int player)
		{
			if (player == 1) {
				return player1.GetField;
			} else if (player == 2) {
				return player2.GetField;
			} else {
				return null;
			}
		}
	
		/// <summary>
		/// Gets the player discard.
		/// </summary>
		/// <returns>The player discard.</returns>
		/// <param name="player">Player 1 or 2.</param>
		public Subconscious GetPlayerDiscard (int player)
		{
			if (player == 1) {
				return player1.Discard;
			} else if (player == 2) {
				return player2.Discard;
			} else {
				return null;
			}
		}
	
		/// <summary>
		/// Initalize the BoardManager values.
		/// </summary>
		/// <param name="firstPlayer">The Player who plays first.</param>
		public void init (int firstPlayer, Player player1, Player player2)
		{
			nextPlayer = firstPlayer;
			currentPlayer = firstPlayer;
			waitingForResponse = false;
			this.player1 = player1;
			this.player2 = player2;
			actionStack = new Stack();
		}
	
		/// <summary>
		/// Alternates player turns.
		/// Adds one to the currentPlayer then sets the currentPlayer to the remaider of currentPlayer/2
		/// </summary>
		public void GoNextPlayer ()
		{
			currentPlayer = nextPlayer;
			nextPlayer = (currentPlayer + 1) % 2;
		}

		/// <summary>
		/// Pushs the stack.
		/// </summary>
		/// <param name="_turnActionData">Action data added to the stack.</param>
		public void PushStack(TurnActionData _turnActionData){
			actionStack.Push(_turnActionData);
		}

		/// <summary>
		/// Pops the stack.
		/// </summary>
		/// <returns>Action data from the top of the stack.</returns>
		public TurnActionData PopStack(){
			return (TurnActionData)actionStack.Pop();
		}

		/// <summary>
		/// Check for actions on the stack.
		/// </summary>
		/// <returns><c>true</c>, if stack has actions, <c>false</c> otherwise.</returns>
		public bool ActionsOnStack(){
			return actionStack.Count > 0;
		}
	}
}