using UnityEngine;
using System.Collections;
using System.IO;

public class CardStorage{
	
	public enum types{Thing,Stuff,Whatever};
	public enum subTypes{SubThing,SubStuff,SubWhatever};

	//public static 
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
	
	public CardStorage(){
	
	}
	
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
	
	//this is for writing to XML, it wasn't working instantly so i skipped to raw text
	public static void ToXML(CardStorage _Input){
		
		System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(CardStorage));
		System.IO.StreamWriter file = new System.IO.StreamWriter(@"d:\temp\SerializationOverview.xml");
		writer.Serialize(file, _Input);
		file.Close();
	}
	
	//writes a card to text file. 
	public static void ToFile(CardStorage _Input){
		TextWriter file = new StreamWriter(@"d:\temp\testfile.txt");
		                            
		file.WriteLine(_Input.id.ToString());
		file.WriteLine(_Input.name);
		
		string filename = _Input.name+"_IMG.png";
		file.WriteLine(filename);
		SaveTextureToFile(_Input.image,filename);
		
		file.WriteLine(_Input.type);
		file.WriteLine(_Input.subtype);
		file.WriteLine(_Input.cost);
		file.WriteLine(_Input.nightMareValue);
		file.WriteLine(_Input.dreamValue);
		file.WriteLine(_Input.ability);
		
		file.Close();
		
		
	}
	
	//saves image to file
	public static void SaveTextureToFile(Texture2D texture, string fileName){
		byte[] bytes=texture.EncodeToPNG();
		FileStream file = File.Open(@"d:\temp\"+fileName,FileMode.OpenOrCreate);;
		System.IO.BinaryWriter binary= new System.IO.BinaryWriter(file);
		binary.Write(bytes);
		binary.Close();
		
	}
}
