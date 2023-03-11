using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb2d;
    [SerializeField] float _speed = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 inputVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _speed; 

        _rb2d.AddForce(inputVelocity);  
    }
}
