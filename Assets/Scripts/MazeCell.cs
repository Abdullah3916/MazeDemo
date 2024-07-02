using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField] private GameObject _leftWall;
    [SerializeField] private GameObject _rightWall;
    [SerializeField] private GameObject _frontWall;
    [SerializeField] private GameObject _backWall;
    [SerializeField] private GameObject _ground;
    [SerializeField] private GameObject _unvisitedBlock;
    [SerializeField] private Color _passedColor = Color.white;
    [SerializeField] private Color _defaultColor = Color.black;
    [SerializeField] private float _durationOfColor = 15f;
    [SerializeField] private float _durationOfColorFadeOut = 2f;
     

    private Coroutine _coroutine;
    public bool IsVisited { get; private set; }
    public bool IsOccupied { get;  set; }
    public bool IsPassedTroughByPlayer { get; set; }

    
    public void Visit() 
    {
        IsVisited = true;
        _unvisitedBlock.SetActive(false);
    }
    public void ClearLeftWall() 
    {
        _leftWall.SetActive(false);
    }
    public void ClearRightWall() 
    {
        _rightWall.SetActive(false);
    }
    public void ClearFrontWall() 
    {
        _frontWall.SetActive(false);
    }
    public void ClearBackWall() 
    {
        _backWall.SetActive(false);
    }
    public void PaintCell(Color color) 
    {
        _ground.GetComponentInChildren<Renderer>().material.color = color;

    }

    private IEnumerator ChangeColor() 
    {
        _ground.GetComponentInChildren<Renderer>().material.color = _passedColor;

        yield return new WaitForSeconds(_durationOfColor);

        float elapsedTime = 0f;
        while (elapsedTime < _durationOfColorFadeOut)
        {
            _ground.GetComponentInChildren<Renderer>().material.color = Color.Lerp(_passedColor, _defaultColor, elapsedTime / _durationOfColorFadeOut);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _ground.GetComponentInChildren<Renderer>().material.color= _defaultColor;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(typeof(PlayerController), out var player))
        {          
          TriggerColorChange();                
        }
    }

    private void TriggerColorChange() 
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeColor());
    }

    
}
