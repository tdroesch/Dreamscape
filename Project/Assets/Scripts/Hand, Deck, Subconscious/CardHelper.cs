using System;
using System.Collections.Generic;

namespace Dreamscape
{
	public enum Position
	{
		top = 0,
		middle = 1,
		bottom = 2
	};
	
	public enum SortBy
	{
		alphabetically = 0,
		type = 1
	};
	
	public enum Target
	{
		deck = 0,
		hand = 1,
		field = 2,
		subconscious = 3
	};

	public static class DreamscapeExtensions{

		public static bool RemoveCard(this List<Card> _container, string _name, out Card _card){
			for (int i=0; i<_container.Count; i++){
				if (_container[i].Name.Equals(_name)){
					_card = _container[i];
					_container.RemoveAt(i);
					return true;
				}
			}
			_card = null;
			return false;
		}
	}
}

