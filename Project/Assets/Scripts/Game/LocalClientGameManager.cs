using UnityEngine;
using System.Collections;

namespace Dreamscape
{
	//[System.Serializable]
	public class LocalClientGameManager : BaseClientGameManager, IClient {
		//***********************************************
		//This is almost entirely for testing purposes.
		ServerGameManager gm;
	
		// Use this for initialization
		void Start ()
		{
			gm = GetComponent<ServerGameManager> ();
		}
		
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetKeyDown (KeyCode.Q)) {
				gm.InitClient(this);
			} else if (Input.GetKeyDown (KeyCode.W)) {
				gm.PlayCard (0, null, 0, this);
			} else if (Input.GetKeyDown (KeyCode.E)) {
				gm.EndPhase (this);
			} else if (Input.GetKeyDown (KeyCode.R)) {
				gm.Resign (this);
			}
		}
		//***********************************************


		//**********************************
		// Messages to the ServerGameManager
		// These messages will be sent directly to the ServerGameManager
		
		/// <summary>
		/// Initialize a client in the state machine.
		/// </summary>
		/// <param name="_player">The player being initialized.</param>
		public override void InitClient (/*There will be paramaters in here*/)
		{
			gm.InitClient(this);
		}

		/// <summary>
		/// Plays the card.
		/// </summary>
		/// <param name="_cardID">ID of the card being played.</param>
		/// <param name="_targets">The targets of the card.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		public override void PlayCard (int _cardID, int[] _targets, int _destination)
		{
			gm.PlayCard(_cardID, _targets, _destination, this);
		}
		
		/// <summary>
		/// Uses the card ability.
		/// </summary>
		/// <param name="_cardID">ID of the card being used.</param>
		/// <param name="_abilityID">ID of the ability being used.</param>
		/// <param name="_targets">The targets of the ability.</param>
		public override void UseCardAbility (int _cardID, int _abilityID, int[] _targets)
		{
			gm.UseCardAbility (_cardID, _abilityID, _targets, this);
		}
		
		/// <summary>
		/// Rearange cards possitions on the board
		/// </summary>
		/// <param name="_cardID">ID of the card being moved.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		public override void MoveCardToField (int _cardID, int _destination)
		{
			gm.MoveCardToField (_cardID, _destination, this);
		}
		
		/// <summary>
		/// Ends the phase.
		/// </summary>
		public override void EndPhase ()
		{
			gm.EndPhase(this);
		}
		
		/// <summary>
		/// Resign the specified _player.
		/// </summary>
		/// <param name="_player">Player who requested the command.</param>
		public override void Resign ()
		{
			gm.Resign(this);
		}
		//**********************************


		//**********************************
		// Messages from the ServerGameManager
		// These messages will be execute the BaseClientGameManager Functions
		
		/// <summary>
		/// Moves the card.
		/// </summary>
		/// <param name="_cardID">ID of the card being moved.</param>
		/// <param name="_source">ID of the container it is moved from.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		public void MoveCard (int _cardID, int _source, int _destination){}
		
		/// <summary>
		/// Changes the card attribute.
		/// </summary>
		/// <param name="_cardID">ID of the card being changed.</param>
		/// <param name="_attribute">Name of the attribute being changed.</param>
		/// <param name="_value">Value of the change.</param>
		public void ChangeCardAttribute (int _cardID, CardAttribute _attribute, int _value){}
		
		/// <summary>
		/// Changes one of the player's attributes.
		/// </summary>
		/// <param name="_playerID">ID of the player.</param>
		/// <param name="_attribute">Name of the attribute being changed.</param>
		/// <param name="_value">Value change to the player's will.</param>
		public void ChangePlayerAttribute (int _playerID, PlayerAttribute _attribute, int _value){}
		
		/// <summary>
		/// Ends the game with a winner.
		/// </summary>
		/// <param name="_playerID">ID of the player that wins.</param>
		public void EndGame(int _playerID){}
		//**********************************
	}
}