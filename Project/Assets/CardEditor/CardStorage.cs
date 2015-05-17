using UnityEngine;
using System.Collections;

public class CardStorage{
	
	public enum types{Thing,Stuff,Whatever};
	public enum subTypes{SubThing,SubStuff,SubWhatever};
	
	int id;
	string name;
	Texture2D image;
	types type;
	subTypes subtype;
	
	//stats
	int cost;
	int nightMareValue;
	int dreamValue;
	
	string ability;
	
	public CardStorage(int _id, string _name, Texture2D _image, types _type, subTypes _subtype, int _cost, int _nightMareValue, int _dreamValue, string _ability){
		id = _id;
		name = _name;
		image = _image;
		type = _type;
		subtype = _subtype;
		cost = _cost;
		nightMareValue = _nightMareValue;
		dreamValue = _dreamValue;
		ability = _ability;
	}
	public CardStorage(){
		id = 0;
		name = "Name";
		image = new Texture2D(10,10);
		type = types.Thing;
		subtype = subTypes.SubThing;
		cost = 100;
		nightMareValue = 200;
		dreamValue = 300;
		ability = "None";
	}
	
}
