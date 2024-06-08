using System;
using System.Collections.Generic;
using UnityEngine;


public class DrawManager : MonoBehaviour
{
    private Camera _camera;
    
    [SerializeField] 
    private Line _linePrefab;
    public const float Resolution = 0.1f;
    private Line _currentLine;
    private Vector2 _tempPosition;
    private bool _temp;
    private bool _ver;
    private List<Line> _listLine;
    private void Start()
    {
        _temp = true;
        _ver = true;
        _camera = Camera.main;
        _listLine = new List<Line>();
    }

    private void Update()
    {
        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (_temp)
            {
                _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);
                _currentLine.SetPosition(mousePos);
                _tempPosition = mousePos;
                
                _temp = false;
            }
           
        }

        if (_currentLine == null)
        {
            _temp = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            _ver = !_ver;
        }  
        
        if (Input.GetMouseButton(0)&& _currentLine!=null)
        {
            if (_ver)
            {
                if (Math.Abs( mousePos.x - _tempPosition.x)<1)
                {
                    mousePos.x = _tempPosition.x;
                    _currentLine.SetPosition(mousePos);
                    _tempPosition.y = _currentLine._lineRenderer.GetPosition(_currentLine._lineRenderer.positionCount-1).y;
                }
            
            }
            else
            {
                if (Math.Abs( mousePos.y - _tempPosition.y)<1)
                {
                    mousePos.y = _tempPosition.y;
                    _currentLine.SetPosition(mousePos);
                    _tempPosition.x = _currentLine._lineRenderer.GetPosition(_currentLine._lineRenderer.positionCount-1).x;

                }
              
            }
            
        }

        if (Input.GetKey(KeyCode.Escape) )
        {
            Destroy(_currentLine.gameObject);
        }
        if (Input.GetMouseButtonUp(0) && _currentLine!=null)
        {
            if (!_temp)
            {
                if (Vector2.Distance(mousePos, _currentLine._lineRenderer.GetPosition(0)) < 0.3f)
                {
                    _temp = true;
                    _currentLine.SetCreate();
                    _listLine.Add(_currentLine);
                }

                else if (_listLine.Count != 0)
                {
                    foreach (var line in _listLine)
                    {
                        for (int i = 0; i < line._lineRenderer.positionCount; i++)
                        {
                            if (Vector3.Distance(_currentLine._lineRenderer.GetPosition(0),line._lineRenderer.GetPosition(i))<0.15f)
                            {
                                for (int j = 0; j < line._lineRenderer.positionCount; j++)
                                {
                                    if (Vector2.Distance(mousePos, line._lineRenderer.GetPosition(j)) < 0.15f)
                                    {
                                        _temp = true;
                                        _currentLine.SetCreate();
                                        return;
                                    }
                                }
                            }
                        }
                        
                    }
                  
                }
                  
            }
        }
          
          
        
    }
    
        
}

