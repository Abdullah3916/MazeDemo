using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private int _coinCount;    
    private Vector3 _rotationSpeed = new Vector3(15,30,45);
    private void Start()
    {
        UIManager.Instance.UpdateCoinText(_coinCount);        
    }

    private void Update()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(typeof(PlayerController), out var player))
        {
            Destroy(gameObject);
            GoldManager.instance.AddGold(1);          
            Debug.Log(GoldManager.instance.TotalGold);
            UIManager.Instance.UpdateCoinText(GoldManager.instance.TotalGold);
        }
    }
   
}
