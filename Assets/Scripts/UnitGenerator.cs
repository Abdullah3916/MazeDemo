using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class UnitGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _collectableCoin;
    [SerializeField] private GameObject _player;
    [SerializeField] int _amountOfCoin;

    //dont make this awake at all cost
    private void Start()
    {
        MazeCell cell = GetRandomMazeCell();
        Instantiate(_player, cell.transform.position, Quaternion.identity);
        cell.IsOccupied = true;
        for (int i = 0; i < _amountOfCoin; i++)
        {
            while (cell.IsOccupied)
            {
                cell = GetRandomMazeCell();
            }
            Instantiate(_collectableCoin,cell.transform.position + new Vector3(0,0.5f,0),Quaternion.identity);
            cell.IsOccupied = true;
        }
    }

    private MazeCell GetRandomMazeCell() 
    {
        System.Random rnd = new System.Random();
        int row = rnd.Next(0,MazeGenerator._mazeGrid.GetLength(1));
        int column = rnd.Next(0,MazeGenerator._mazeGrid.GetLength(0));

        return MazeGenerator._mazeGrid[row, column];
    }
    
}
