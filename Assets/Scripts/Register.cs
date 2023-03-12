using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{

	[SerializeField] ListManager listManager;
	[SerializeField] Timer timer;
	[SerializeField] GameManager gameManager;
	[SerializeField] DistractingShopperManager shopperManager;
	[SerializeField] DistractingShopper[] shoppers;
	[SerializeField] ProduceRandomizer produceRandomizer;

	public AudioSource audioSource;

	int completedLists = 0;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (gameManager.GameOver) { return; }

		if (collision.TryGetComponent(out PlayerController player))
		{
			if (listManager.CheckListComplete())
			{
				Debug.Log("COMPLETED!");
				audioSource.Play();
				completedLists++;
				gameManager.clearedRounds = completedLists; 
				timer.AddCompletionBonus();
				listManager.MakeHarderList();
				shopperManager.OnPlayerCompleteList(listManager.currentListDifficulty);
				UpdateShoppersDesiredGrocery();
				produceRandomizer.RandomizeProduce();
				return;
			}

			Debug.Log("Still Missing some stuff ..");

		}
	}

	private void UpdateShoppersDesiredGrocery()
	{
		foreach(DistractingShopper shopper in shoppers)
		{
			shopper.OnPlayerCompletesList();
		}
	}

}
