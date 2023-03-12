using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ListManager : MonoBehaviour
{
	public int currentListDifficulty = 2;

	public GroceryObject[] groceryPool;
	public GroceryObject[] currentList;
	public bool[] currentListCheckedOff;

	[SerializeField] GroceryListUIManager groceryUIManager;
	public GameManager gameManager;

	private void Start()
	{
		GenerateNewShoppingList(currentListDifficulty);
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
		groceryUIManager.SetListUI(currentList);

	}
	public List<GroceryObject> GetGroceryPoolCopy()
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
		if(gameManager.GameOver) { return;  }
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
		if (gameManager.GameOver) { return; }

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

	public GroceryObject GetRandomGrocery()
	{
		return currentList[UnityEngine.Random.Range(0, currentList.Length)];
	}

	// Checking List Compleete
	public bool CheckListComplete()
	{
		return currentListCheckedOff.All(e => e);
	}

	public void MakeHarderList()
	{
		if (gameManager.GameOver) { return; }

		currentListDifficulty = Math.Min(currentListDifficulty + 1, 6);
		GenerateNewShoppingList(currentListDifficulty);
	}
}
