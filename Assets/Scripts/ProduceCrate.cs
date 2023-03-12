using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceCrate : MonoBehaviour
{
    [SerializeField] GroceryObject _groceryObject;
    [SerializeField] SpriteRenderer grocerySpriteRenderer;
    // Start is called before the first frame update
    public void SetUpProduceCrate(GroceryObject groceryObject)
    {
        _groceryObject = groceryObject;
        grocerySpriteRenderer.sprite = groceryObject.Sprite;
	}

    public GroceryObject GetGroccery()
    {	
        if (_groceryObject == null)
            Debug.LogWarning(name + ": _groceryObject field not set!");
        return _groceryObject;
	}
}
