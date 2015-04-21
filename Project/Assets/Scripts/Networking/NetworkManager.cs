using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	public string connectionIP = "127.0.0.1";
	public int connectionPort = 25001;
	
	void OnGUI(){
			
		switch(Network.peerType){
		
			case NetworkPeerType.Disconnected:
				GUI.Label(new Rect(10, 10, 300, 20), "Status: Disconnected");
				if (GUI.Button(new Rect(10, 30, 120, 20), "Client Connect")){
					Network.Connect(connectionIP, connectionPort);
					
				}
				if (GUI.Button(new Rect(10, 50, 120, 20), "Initialize Server")){
					Network.InitializeServer(32, connectionPort, false);
				}
			break;
			
			case NetworkPeerType.Client:
				GUI.Label(new Rect(10, 10, 300, 20), "Status: Connected as Client");
				if (GUI.Button(new Rect(10, 30, 120, 20), "Disconnect")){
					
					Network.Disconnect(200);
				}
			break;
			
			case NetworkPeerType.Server:
				if(Network.connections.Length == 0){
					GUI.Label(new Rect(10, 10, 300, 20), "Status: Started Server");
				}
				else{
					GUI.Label(new Rect(10, 10, 300, 20), "Status: Client Connected");
				}
				
				if (GUI.Button(new Rect(10, 30, 120, 20), "Disconnect")){
					Network.Disconnect(200);
				}
			break;
		}
		
		
	}
	
}
