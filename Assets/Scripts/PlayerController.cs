using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb2d;
    [SerializeField] float _speed = 1;

    [SerializeField] List<GroceryItem> heldGroceries;
    [SerializeField] ProduceCrate _currentCrate;

    // Start is called before the first frame update
    void Start()
    {
        heldGroceries = new List<GroceryItem>();
        _currentCrate = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
		Vector2 inputVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _speed; 

        _rb2d.AddForce(inputVelocity);

		//Pickingup Grocceries
		if (_currentCrate != null)
        {
			if (Input.GetKeyDown(KeyCode.P))
			{
                PickupGroccery(_currentCrate.GetGroccery());
			}
		}


    }
    
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.TryGetComponent(out ProduceCrate triggeredCrate))
		{
			_currentCrate = triggeredCrate;
		}



	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (!other.TryGetComponent(out ProduceCrate triggeredCrate)) { return; }

        if(triggeredCrate.Equals(_currentCrate))
        {
            _currentCrate = null;
        }
	}

	void PickupGroccery(GroceryItem newItem)
    {
        heldGroceries.Add(newItem);
    }
}
