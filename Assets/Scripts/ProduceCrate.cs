using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceCrate : MonoBehaviour
{
    [SerializeField] GroceryObject _groceryObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GroceryItem GetGroccery()
    {	
        if (_groceryObject == null)
            Debug.LogWarning(name + ": _groceryObject field not set!");
        return new GroceryItem(_groceryObject.Name, _groceryObject.Sprite);
	}
}
