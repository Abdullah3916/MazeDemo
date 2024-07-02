using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    [SerializeField] private GameObject _gridBlock;
    [SerializeField] private int _worldSizeX;
    [SerializeField] private int _worldSizeZ;
    [SerializeField] private float _gridOffset;

    private void Start()
    {
        for (int x = 0; x < _worldSizeX; x++)
        {
            for (int z = 0; z < _worldSizeZ; x++) 
            {
                Vector3 pos = new Vector3(x * _gridOffset, 0 , z * _gridOffset);
                GameObject block = Instantiate(_gridBlock, pos , Quaternion.identity) as GameObject;

                block.transform.SetParent(this.transform);
            }
        }
    }
}
