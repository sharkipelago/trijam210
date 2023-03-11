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
	
	public void CheckOff(bool shouldBeCheckedOff)
	{
		Color color = itemImage.color;
		color.a = shouldBeCheckedOff ? 0.5f : 1f;

		itemImage.color = color;
	}
}
