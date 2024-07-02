using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _target ;
    private Vector3 _offset = new Vector3(0 , 5 , -3);  
   
    
    private void Start()
    {
        FindPlayer();
    }
    private void LateUpdate()
    {
        LookAtTarget();
    }

    private void LookAtTarget() 
    {
        if (_target != null)
        {
            Vector3 desiredPosition = _target.position + _offset;           
            transform.position = desiredPosition;
            transform.LookAt(_target);         
        }
    }

    private void FindPlayer() 
    {

        if (_target == null)
        {
            _target = GameObject.FindWithTag("Player").transform;
        }
    }
}
