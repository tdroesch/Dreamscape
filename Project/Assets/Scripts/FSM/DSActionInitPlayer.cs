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
			Player player = new Player(playerData.charID, playerData.initWill, playerData.initImagination, new Hand(), new Deck(playerData.deckList),
			                           new Field(), new Subconscious(), playerData.client);
			// Replace the client stored in the context with the player that contains that client.
			if (context.get("Player 1").Equals(playerData.client)){
				context.put("Player 1", player);
				log ("Player 1", player, context);
			} else if (context.get("Player 2").Equals(playerData.client)){
				context.put("Player 2", player);
				log ("Player 2", player, context);
			}
			MessageClientsCreatePlayer(context, player);
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

	void MessageClientsCreatePlayer(FSMContext context, Player newPlayer){
		object player1Raw = context.get("Player 1");
		object player2Raw = context.get("Player 2");
		IClient player1 = player1Raw.GetType() == typeof(Player) ? ((Player)player1Raw).Client : (IClient)player1Raw;
		IClient player2 = player2Raw.GetType() == typeof(Player) ? ((Player)player2Raw).Client : (IClient)player2Raw;

		if (newPlayer.Client.Equals(player1)){
			player1.CreatePlayer(newPlayer.CharID, newPlayer.GUID, 0);
			player2.CreatePlayer(newPlayer.CharID, newPlayer.GUID, 1);
		}
		else if (newPlayer.Client.Equals(player2)){
			player1.CreatePlayer(newPlayer.CharID, newPlayer.GUID, 1);
			player2.CreatePlayer(newPlayer.CharID, newPlayer.GUID, 0);
		}
		player1.ChangePlayerAttribute(newPlayer.GUID, PlayerAttribute.Will, newPlayer.Will);
		player1.ChangePlayerAttribute(newPlayer.GUID, PlayerAttribute.Imagination, newPlayer.Imagination);
		player1.ChangePlayerAttribute(newPlayer.GUID, PlayerAttribute.Cycle, newPlayer.SleepCycles);
		player1.ChangePlayerAttribute(newPlayer.GUID, PlayerAttribute.Stage, newPlayer.SleepStage);
		player1.ChangePlayerAttribute(newPlayer.GUID, PlayerAttribute.Actions, newPlayer.SleepActions);
		player2.ChangePlayerAttribute(newPlayer.GUID, PlayerAttribute.Will, newPlayer.Will);
		player2.ChangePlayerAttribute(newPlayer.GUID, PlayerAttribute.Imagination, newPlayer.Imagination);
		player2.ChangePlayerAttribute(newPlayer.GUID, PlayerAttribute.Cycle, newPlayer.SleepCycles);
		player2.ChangePlayerAttribute(newPlayer.GUID, PlayerAttribute.Stage, newPlayer.SleepStage);
		player2.ChangePlayerAttribute(newPlayer.GUID, PlayerAttribute.Actions, newPlayer.SleepActions);
	}
}

