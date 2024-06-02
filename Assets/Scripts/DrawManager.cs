using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class DrawManager : MonoBehaviour
{
    private Camera _camera;
    
    [SerializeField] 
    private Line _linePrefab;
    
    public const float Resolution = 0.1f;

    private Line _currentLine;
    

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
            _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);
        if (Input.GetMouseButton(0) )
            _currentLine.SetPosition(mousePos);

    }
}
