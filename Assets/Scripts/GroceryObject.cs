using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Grocery	", menuName = "ScriptableObjects/GroceryObject", order = 1)]
public class GroceryObject : ScriptableObject
{
	public string Name;
	public Sprite Sprite;
}

