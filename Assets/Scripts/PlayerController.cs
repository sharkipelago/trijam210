using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D _rb2d;
    public bool beingShoved = false;
    public float shoveTimeWindow = 1.5f;
    public float currentShove = 0;
    [SerializeField] float _speed = 2;

    [SerializeField] ProduceCrate _currentCrate;
    [SerializeField] DistractingShopper _currentShopper;

    [SerializeField] ListManager listManager;

    // Start is called before the first frame update
    void Start()
    {
        _currentCrate = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (beingShoved)
        {
            currentShove -= Time.deltaTime;
            if(currentShove < 0) { 
                beingShoved = false;
                currentShove = 0;
            }
        }
        else
        {
			Vector2 inputVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _speed;
			if (inputVelocity.Equals(Vector2.zero))
			{
				_rb2d.velocity = Vector2.zero;
			}
			_rb2d.velocity = inputVelocity;

		}


		//Pickingup Grocceries
		if (_currentCrate != null)
        {
			if (Input.GetKeyDown(KeyCode.P))
			{
                PickupGroccery(_currentCrate.GetGroccery());
			}
		}
        if(_currentShopper != null)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                GiveGroceryToShopper();
            }
        }


    }

    public void OnShoved()
    {
        beingShoved = true;
        currentShove = shoveTimeWindow;
    }
    
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.TryGetComponent(out ProduceCrate triggeredCrate))
		{
			_currentCrate = triggeredCrate;
		}
        if (other.TryGetComponent(out DistractingShopper triggeredShopper))
        {
            _currentShopper = triggeredShopper;
            _currentShopper.OnAskedDesiredGrocery();
        }
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.TryGetComponent(out ProduceCrate triggeredCrate))
		{
			if (triggeredCrate.Equals(_currentCrate))
			{
				_currentCrate = null;
			}
		}
		if (other.TryGetComponent(out DistractingShopper triggeredShopper))
		{
			if (triggeredShopper.Equals(_currentShopper))
			{
				_currentShopper = null;
			}
		}


	}

	void PickupGroccery(GroceryObject newItem)
    {
        if(listManager.ListHasItem(newItem)) { return; }
        listManager.TryCheckOffListItem(newItem);
    }

    void GiveGroceryToShopper()
    {
        _currentShopper.TryGiveGrocery();
    }

}
