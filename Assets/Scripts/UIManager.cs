using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]private TMP_Text _coinText;
    private int _coinAmount;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateCoinText(int coinCount) 
    {
        if (_coinText != null)
        {
            _coinText.text = "Coins:" + coinCount;
        }       
    }   

}
