using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{

	[SerializeField] ListManager listManager;
	[SerializeField] Timer timer;
	[SerializeField] GameManager gameManager;
 
	int completedLists = 0;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (gameManager.GameOver) { return; }

		if (collision.TryGetComponent(out PlayerController player))
		{
			if (listManager.CheckListComplete())
			{
				Debug.Log("COMPLETED!");
				player.ClearHeldGroceries();
				completedLists++;
				timer.AddCompletionBonus();
				listManager.MakeHarderList();
				return;
			}

			Debug.Log("Still Missing some stuff ..");

		}
	}


}
