using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListItemUI : MonoBehaviour
{
	[SerializeField] Image itemImage;
	[SerializeField] TMP_Text itemText;

	public void SetItemUI(GroceryObject groceryObject)
	{
		itemImage.sprite = groceryObject.Sprite;
		itemText.text= groceryObject.name;
	}
}
