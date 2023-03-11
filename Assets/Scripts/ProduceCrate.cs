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

    public GroceryObject GetGroccery()
    {	
        if (_groceryObject == null)
            Debug.LogWarning(name + ": _groceryObject field not set!");
        return _groceryObject;
	}
}
