using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{
	[SerializeField] GroceryObject[] groceryPool;
	public GroceryObject[] currentList;

	[SerializeField] GroceryListUIManager groceryUIManager;

	private void Start()
	{
		currentList = GetNewShoppingList(2);
		groceryUIManager.SetListUI(currentList);
	}

	GroceryObject[] GetNewShoppingList (int shoppingListSize)
	{
		if (6 < shoppingListSize || shoppingListSize < 1)
		{
			Debug.LogWarning("Invalid list size, please request between 1 and 7");
			return null;
		}
		
		List<GroceryObject> newList = new List<GroceryObject>();
		var groceryPoolCopy = GetGroceryPoolCopy();
		int itemsToAdd = shoppingListSize;
		
		while (itemsToAdd > 0)
		{
			int randomIndex = Random.Range(0, groceryPoolCopy.Count);
			newList.Add(groceryPoolCopy[randomIndex]);
			groceryPoolCopy.RemoveAt(randomIndex);
			itemsToAdd--;
		}

		return newList.ToArray();
	}

	List<GroceryObject> GetGroceryPoolCopy()
	{
		List<GroceryObject> copy = new List<GroceryObject>();
		foreach(GroceryObject groceryObject in groceryPool)
		{
			copy.Add(groceryObject);
		}
		return copy;
	}
}
