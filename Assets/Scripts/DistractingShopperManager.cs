using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DistractingShopperManager : MonoBehaviour
{
	[SerializeField] DistractingShopper[] allShoppers;
	[SerializeField] List<DistractingShopper> nonActiveShoppers;

	private void Start()
	{
		nonActiveShoppers = allShoppers.ToList();
	}

	public void OnPlayerCompleteList(int difficulty)
	{
		int numOfShoppersToAdd = ShopperAmountBasedOnDifficulty(difficulty);
		for (int i = 0; i < numOfShoppersToAdd; i++)
		{
			if(!ActivateRandomShopper()) { break; }
		}
	}
	
	bool ActivateRandomShopper()
	{
		if(nonActiveShoppers.Count == 0) {  return false; }

		int randomIndex = Random.Range(0, nonActiveShoppers.Count);
		nonActiveShoppers[randomIndex].gameObject.SetActive(true);
		nonActiveShoppers[randomIndex].OnActivated();
		nonActiveShoppers.RemoveAt(randomIndex);
		return true;
	}
	int ShopperAmountBasedOnDifficulty(int difficulty)
	{
		if (difficulty == 2) { return 0; }
		if (difficulty == 3) { return 1; }
		if (difficulty == 4) { return 2; }
		return 3;
	}

	public void ResetShopperPosition(DistractingShopper shopper)
	{
		shopper.gameObject.SetActive(false);
		shopper.gameObject.transform.position = shopper.originalPosition;
		nonActiveShoppers.Add(shopper);
	}
}
