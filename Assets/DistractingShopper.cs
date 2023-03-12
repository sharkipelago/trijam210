using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DistractingShopper : MonoBehaviour
{
	[SerializeField] ListManager listManager;
	[SerializeField] GroceryObject desiredObject;
	[SerializeField] PlayerController player;
	[SerializeField] DistractingShopperManager distractingShopperManager;

	[SerializeField] Collider2D baseCollider;
	[SerializeField] Collider2D trigger;
	public Vector3 originalPosition;

	Vector3 lerpDestination;
	public int angerLevel = 0;
	public bool ascending = false;
	public bool ascended = false;
	// Start is called before the first frame update
	void Awake()
	{
		lerpDestination = new Vector3(transform.position.x, transform.position.y + 30, transform.position.z);
		originalPosition = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (ascending)
		{
			transform.position = Vector3.Lerp(transform.position, lerpDestination, Time.deltaTime);
			if (transform.position.Equals(lerpDestination))
			{
				ascending = false;
				ascended= true;
				distractingShopperManager.ResetShopperPosition(this);
			}
		}
	}

	public void OnActivated()
	{
		desiredObject = listManager.GetRandomGrocery();
		baseCollider.enabled = true;
		trigger.enabled = true;
	}

	public void OnPlayerCompletesList()
	{
		desiredObject = listManager.GetRandomGrocery();
	}

	public bool TryGiveGrocery()
	{
		Debug.Log(desiredObject);
		Debug.Log(listManager.ListHasItem(desiredObject));
		if (listManager.ListHasItem(desiredObject))
		{
			Debug.Log("Here");
			listManager.UncheckListItem(desiredObject);
			Ascend();
			return true;
		}
		GetBothered();
		return false;
	}


	public void OnAskedDesiredGrocery()
	{
		// Hover their grocery over their head
	}

	public void OnAskedToShutUp()
	{
		//Stop hovering their grocery
	}

	void GetBothered()
	{
		if (angerLevel < 3)
		{
			Color c = GetComponent<SpriteRenderer>().color;
			c.r += .2f;
			GetComponent<SpriteRenderer>().color = c;
			angerLevel++;
			//Play Annoyed Audio
			return;
		}
		else
		{
			Shove();
		}
	}

	void Shove()
	{
		Debug.Log("Shoving time");
		player.OnShoved();
		Vector2 shopperToPlayer = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y -transform.position.y);
		Vector2 shoveForce = shopperToPlayer.normalized * 20f;
		Debug.Log(shoveForce);

		player._rb2d.velocity = shoveForce;
	}
	public void Ascend()
	{
		baseCollider.enabled = false;
		trigger.enabled = false;
		ascending = true;
		//Play Ascend sound
		
	}

	
	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.TryGetComponent(out PlayerController player))
		{
			GetBothered();
		}
	}
}
