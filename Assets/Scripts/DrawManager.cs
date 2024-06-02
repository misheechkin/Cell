using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using MouseButton = Unity.VisualScripting.MouseButton;

public class DrawManager : MonoBehaviour
{
    private Camera _camera;
    
    [SerializeField] 
    private Line _linePrefab;
    public const float Resolution = 0.01f;
    private Line _currentLine;
    private Vector2 tempPosition;
    private bool temp;
    private bool ver;

    private void Start()
    {
        temp = true;
        ver = true;
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (temp)
            {
                _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);
                _currentLine.SetPosition(mousePos);
                tempPosition = mousePos;
                
                temp = false;
            }
           
        }
      
        if (Input.GetMouseButton(0))
        {
            if (ver)
            {
                if (Math.Abs( mousePos.x - tempPosition.x)<1)
                {
                    mousePos.x = tempPosition.x;
                    _currentLine.SetPosition(mousePos);
                    tempPosition.y = _currentLine._lineRenderer.GetPosition(_currentLine._lineRenderer.positionCount-1).y;
                }
            
            }
            else
            {
                if (Math.Abs( mousePos.y - tempPosition.y)<1)
                {
                    mousePos.y = tempPosition.y;
                    _currentLine.SetPosition(mousePos);
                    tempPosition.x = _currentLine._lineRenderer.GetPosition(_currentLine._lineRenderer.positionCount-1).x;

                }
              
            }
            
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            ver = !ver;
            if (!temp)
            {
                Vector2 vector2 = _currentLine._lineRenderer.GetPosition(0);
                if (Vector2.Distance(vector2,mousePos)<0.4f)
                {
                    temp = true;
                }
            }
          
          
        }

       
        
        
    }
}
