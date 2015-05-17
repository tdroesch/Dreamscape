using UnityEngine;
using System.Collections;

public class NetworkTemporaryTestingAndDataTransferVerification_BETA2015516 : MonoBehaviour {
	
	public int[] testInt;
	
	void OnGUI(){
	
		if(Network.peerType != NetworkPeerType.Disconnected){
		
			if(GUI.Button(new Rect(Screen.width-(300f),Screen.height-(100f),300f,100f),"Test Send")){
				//if(Network.peerType == NetworkPeerType.Server){
					networkView.RPC("testSend",RPCMode.Others,Utility.IntArrayToString(testInt));
				//}
			}
			
		}
		
	}
	
	[RPC]
	void testSend(string _input){
		testInt = Utility.StringToIntArray(_input);
	}
	
}
