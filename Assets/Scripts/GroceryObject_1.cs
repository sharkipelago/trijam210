using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GroceryItem 
{
	public GroceryObject groceryData;
	public GroceryItem(GroceryObject groceryObject)
	{
		groceryData = groceryObject;
	}
}
