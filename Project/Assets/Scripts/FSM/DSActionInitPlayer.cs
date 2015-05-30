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
				log ("Player 1", player, context);
			} else if (context.get("Player 2").Equals(playerData.client)){
				context.put("Player 2", player);
				log ("Player 2", player, context);
			}
		}
	}
	void log(string _name, Player _player, FSMContext context){
		if (_name.Equals ("Player 1")) {
			IClient client1 = _player.Client;
			IClient client2 = (IClient)context.get ("Player 2");
			client1.TestWarning (_name + " Initialized");
			client2.TestWarning (_name + " Initialized");
			client1.TestLog (_name + " Stats - Will: " + _player.Will +
				", Imagination: " + _player.Imagination);
			client2.TestLog (_name + " Stats - Will: " + _player.Will +
				", Imagination: " + _player.Imagination);
			client1.TestLog ("Press Q to Add Another Player");
			client2.TestLog ("Press Q to Add Another Player");
		} else if (_name.Equals ("Player 2")) {
			IClient client1 = ((Player)context.get ("Player 1")).Client;
			IClient client2 = _player.Client;
			client1.TestWarning (_name + " Initialized");
			client2.TestWarning (_name + " Initialized");
			client1.TestLog (_name + " Stats - Will: " + _player.Will +
			                 ", Imagination: " + _player.Imagination);
			client2.TestLog (_name + " Stats - Will: " + _player.Will +
			                 ", Imagination: " + _player.Imagination);
		}
	}
}

