using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
       
    public static GoldManager instance;
    private int _totalGold = 0;
    public int TotalGold
    { 
        get { return _totalGold; }
        set { _totalGold = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void AddGold(int amount) 
    {
        _totalGold += amount;
    }
    public void SubtractGold(int amount) 
    {
        _totalGold -= amount;
        if (_totalGold < 0)
        {
            _totalGold = 0;
        }
    }
}
