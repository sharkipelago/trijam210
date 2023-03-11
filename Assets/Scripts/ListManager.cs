using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ListManager : MonoBehaviour
{
	[SerializeField] GroceryObject[] groceryPool;
	public GroceryObject[] currentList;
	public bool[] currentListCheckedOff;

	[SerializeField] GroceryListUIManager groceryUIManager;

	private void Start()
	{
		GenerateNewShoppingList(2);
		groceryUIManager.SetListUI(currentList);
	}

	// Making New List
	void GenerateNewShoppingList(int shoppingListSize)
	{
		if (6 < shoppingListSize || shoppingListSize < 1)
		{
			Debug.LogWarning("Invalid list size, please request between 1 and 7");
			return;
		}

		List<GroceryObject> newList = new List<GroceryObject>();
		var groceryPoolCopy = GetGroceryPoolCopy();
		int itemsToAdd = shoppingListSize;

		while (itemsToAdd > 0)
		{
			int randomIndex = UnityEngine.Random.Range(0, groceryPoolCopy.Count);
			newList.Add(groceryPoolCopy[randomIndex]);
			groceryPoolCopy.RemoveAt(randomIndex);
			itemsToAdd--;
		}

		currentListCheckedOff = new bool[shoppingListSize];
		currentList =  newList.ToArray();
	}
	List<GroceryObject> GetGroceryPoolCopy()
	{
		List<GroceryObject> copy = new List<GroceryObject>();
		foreach (GroceryObject groceryObject in groceryPool)
		{
			copy.Add(groceryObject);
		}
		return copy;
	}

	// Managing List
	public void TryCheckOffListItem(GroceryObject targetGrocery)
	{
		for (int i = 0; i < currentList.Length; i++)
		{
			if (targetGrocery.Equals(currentList[i]))
			{
				currentListCheckedOff[i] = true;
			}
		}
		groceryUIManager.UpdateCheckedOff(currentListCheckedOff);

	}

	public void UncheckListItem(GroceryObject targetGrocery)
	{
		for (int i = 0; i < currentList.Length; i++)
		{
			if (targetGrocery.Equals(currentList[i]))
			{
				currentListCheckedOff[i] = false;
			}
		}
		groceryUIManager.UpdateCheckedOff(currentListCheckedOff);

	}

	public bool ListHasItem(GroceryObject targetGrocery)
	{
		int groceryIndex = Array.IndexOf(currentList, targetGrocery);
		if(groceryIndex < 0) { return false; }
		return currentListCheckedOff[groceryIndex];
	}

	// Checking List Compleete
	public bool CheckListComplete()
	{
		return currentListCheckedOff.All(e => e);
	}
}
