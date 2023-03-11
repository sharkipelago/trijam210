using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroceryListUIManager : MonoBehaviour
{
    [SerializeField] ListItemUI[] listItems;

	public void SetListUI(GroceryObject[] newGroceryList)
	{
		ClearListUI();	
		for(int i = 0; i < newGroceryList.Length; i++)
		{
			listItems[i].SetItemUI(newGroceryList[i]);
			listItems[i].gameObject.SetActive(true);
		}
	}

	void ClearListUI()
	{
		foreach(ListItemUI listItemUI in listItems)
		{
			listItemUI.gameObject.SetActive(false);
		}
	}
}
