using UnityEngine;
using System.Collections;
using System;

public class Items : IComparable<Items> {
	ItemsDataBaseScript myScript;

	public int itemType;
	public Texture2D icon;
	public string itemName;
	public int materialType;

	public Items(int _itemType, Texture2D _icon, string _itemName, int _materialType) {
		itemType = _itemType;
		icon = _icon;
		itemName = _itemName;
		materialType = _materialType;
	}
	public int CompareTo(Items other)
	{
		if(other == null)
		{
			return 1;
		}
		
		//Return the difference in power.
		return 0;
	}
}