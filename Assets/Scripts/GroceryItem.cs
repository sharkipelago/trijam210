using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GroceryItem 
{
	public string Name;
	public Sprite Sprite;

	public GroceryItem(string name, Sprite sprite)
	{
		Name = name;
		Sprite = sprite;
	}
}
