using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{

	[SerializeField] ListManager listManager;

	int completedLists = 0;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out PlayerController player))
		{
			if (listManager.CheckListComplete())
			{
				Debug.Log("COMPLETED!");
				player.ClearHeldGroceries();
				completedLists++;
				// TODO: Increase Timer
				return;
			}

			Debug.Log("Still Missing some stuff ..");

		}
	}


}
