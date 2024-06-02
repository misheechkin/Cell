using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
    public LineRenderer _lineRenderer;
    
    [SerializeField]
    private EdgeCollider2D _collider;

    [SerializeField] 
    private float scaleCollider = 0.1f;

    public  List<Vector2> _points = new List<Vector2>();
    private EdgeCollider2D EdgeCollider2D;
  
    // public void SetCreate()
    // {
    //     EdgeCollider2D.isTrigger = false;
    // }
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     Ball ball = collision.GetComponent<Ball>();
    //     if (collision != null && ball != null)
    //     {
    //         Destroy(gameObject);
    //     }
    // }
    private void Start()
    {
        _collider.transform.position -= transform.position;
        EdgeCollider2D = this.GetComponent<EdgeCollider2D>();
        // EdgeCollider2D.isTrigger = true;
        
    }

  

    public void SetPosition(Vector2 position)
    {
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
