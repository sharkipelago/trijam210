using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceRandomizer : MonoBehaviour
{
    [SerializeField] ProduceCrate[] produceCrates;
    [SerializeField] ListManager listManager;
    // Start is called before the first frame update
    void Start()
    {
		RandomizeProduce();
	}
    
    public void RandomizeProduce()
    {

		var groceryPoolCopy = listManager.GetGroceryPoolCopy();

		for (int i = 0; i < produceCrates.Length; i++)
		{
			if (groceryPoolCopy.Count == 0) { groceryPoolCopy = listManager.GetGroceryPoolCopy(); }
			int randomIndex = Random.Range(0, groceryPoolCopy.Count);
			produceCrates[i].SetUpProduceCrate(groceryPoolCopy[randomIndex]);

			groceryPoolCopy.RemoveAt(randomIndex);
		}
	}
}
