using UnityEngine;
using System.Collections;
using FSM;
using Dreamscape;

class DSActionInitPlayer : FSMAction {
	public void execute (FSMContext context, object data)
	{
		// If data is of type PlayerData
		if (data.GetType () == typeof(PlayerData)) {
			// Cast data as type PlayerData
			PlayerData playerData = (PlayerData)data;
			//  Create new player
			Player player = new Player(playerData.initWill, playerData.initImagination, new Hand(), new Deck(playerData.deckList),
			                           new Field(), new Subconscious(), playerData.client);
			// Replace the client stored in the context with the player that contains that client.
			if (context.get("Player 1").Equals(playerData.client)){
				context.put("Player 1", player);
				log ("Player 1", player);
			} else if (context.get("Player 2").Equals(playerData.client)){
				context.put("Player 2", player);
				log ("Player 2", player);
			}
		}
	}
	void log(string _name, Player _player){
		Debug.LogWarning (_name + " Initialized");
		Debug.Log (_name + " Stats - Will: " + _player.Will +
		           ", Imagination: " + _player.Imagination);
		if (_name.Equals("Player 1")) {
			Debug.Log ("Press Q to Add Another Player");
		}
	}
}

