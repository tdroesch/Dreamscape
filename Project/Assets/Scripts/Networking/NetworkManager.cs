using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	//Server's adress
	public string connectionIP = "127.0.0.1";
	//Server's port. Probably don't need to bother changing this ever unless we got some sick LAN parties going
	public int connectionPort = 25001;
	

	void OnGUI(){
			
		//Three states that the network can be in
		switch(Network.peerType){
			
			//Not connected to anything
			case NetworkPeerType.Disconnected:
				GUI.Label(new Rect(10, 10, 300, 20), "Status: Disconnected");
				//button to connect to the specified IP adress
				if (GUI.Button(new Rect(10, 30, 120, 20), "Client Connect")){
					Network.Connect(connectionIP, connectionPort);
					
				}
				//Button to start a server
				if (GUI.Button(new Rect(10, 50, 120, 20), "Initialize Server")){
					Network.InitializeServer(32, connectionPort, false);
				}
			break;
			
			//Client succesfully connected to server
			case NetworkPeerType.Client:
				GUI.Label(new Rect(10, 10, 300, 20), "Status: Connected as Client");
				
				//Button to disconnect from server
				if (GUI.Button(new Rect(10, 30, 120, 20), "Disconnect")){
					
					Network.Disconnect(200);
				}
			break;
			
			//Started a server
			case NetworkPeerType.Server:
				
				if(Network.connections.Length == 0){
					//Still waiting for a client to connect
					GUI.Label(new Rect(10, 10, 300, 20), "Status: Started Server");
				}
				else{
					//Client Connected
					GUI.Label(new Rect(10, 10, 300, 20), "Status: Client Connected");
				}
				
				//Close server
				if (GUI.Button(new Rect(10, 30, 120, 20), "Disconnect")){
					Network.Disconnect(200);
				}
			break;
		}
		
		
	}
	
}
