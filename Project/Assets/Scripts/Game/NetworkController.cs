using UnityEngine;
using System.Collections;

namespace Dreamscape
{
	//[System.Serializable]
	public class NetworkController : MonoBehaviour, IController {
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
		}
		//***********************************************
		
		public void PlayCard (Card card)
		{
			gm.stateMessage ("Start Play", this);
		}
		
		public void UseCardAbility (Ability ability)
		{
		}

		
		public void MoveCardToField (Card _card, Field _field){}
		
		public void EndTurn ()
		{
			gm.stateMessage ("Start End", this);
		}
	}
}