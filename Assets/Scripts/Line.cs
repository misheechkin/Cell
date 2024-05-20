using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;
    
    [SerializeField]
    private EdgeCollider2D _collider;

    [SerializeField] 
    private float scaleCollider = 0.2f;

    private readonly List<Vector2> _points = new List<Vector2>();

    private float x;

    private void Start()
    {
        _collider.transform.position -= transform.position;
    }

    public void SetPosition(Vector2 position)
    {
        if(_lineRenderer.positionCount==0)
            x = position.x;
        position.x = x;
        if(!CanAppend(position)) return;
        _points.Add(position);
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount-1,position);
        _collider.points = _points.ToArray();
        _collider.edgeRadius = scaleCollider;
    }


    private bool CanAppend(Vector2 position)
    {
        if (_lineRenderer.positionCount == 0) return true;
        
        return Vector2.Distance(_lineRenderer.GetPosition(_lineRenderer.positionCount - 1), position) >
               DrawManager.Resolution;
    }
    
}
