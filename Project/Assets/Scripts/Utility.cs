using UnityEngine;
using System.Collections;

public static class Utility {

	public static int[] StringToIntArray(string _input){
		string[] d = _input.Split(',');
		
		int[] result = new int[d.Length];
		for(int i=0;i<d.Length;i++){
			result[i] = int.Parse(d[i]);
		}
		
		return result;
		
	}
	
	public static string IntArrayToString(int[] _input){
		string result = string.Empty;
		
		for(int i=0;i<_input.Length;i++){
			result += i.ToString();
			if(i != _input.Length-1){
				result += ",";
			}
		}
		
		return result;
	}
}
