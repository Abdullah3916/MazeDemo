
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement() 
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(Vector3.forward * 5);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(Vector3.back * 5);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(Vector3.left * 5);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(Vector3.right * 5);
        }
    }

}
