using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class Ball : MonoBehaviour
{
    public float speed=1f;
    private Rigidbody2D rb;
    private Vector2 vector;
    private Vector2 lastvelocity;
    private int _countRays=360;
    private float Timeleft = 3f;
    public static int count=0;
    private bool temp;
 

    private void Start()
    {
        count++;
        rb = GetComponent<Rigidbody2D>();
        Random rd = new Random();
        var tuple = (0, 0);
        while (tuple.Item1==0 && tuple.Item2==0)
        {
            tuple.Item1 = rd.Next(-1, 1);
            tuple.Item2 = rd.Next(-1, 1);
        }
        vector = new Vector2(tuple.Item1, tuple.Item2);
    }

    private void FixedUpdate()
    {
        rb.velocity = vector*speed; 
        lastvelocity = rb.velocity;
    }

    private void Update()
    {
        if (!Rays())
        {
            if (Timeleft > 0)
                Timeleft -= Time.deltaTime;
            if (Timeleft <= 0)
            {
                if (speed != 0)
                {
                    count--;
                    Debug.Log(count);
                }
                speed = 0;
               
            }
              

        }
        else
        {
            Timeleft = 3f;
        }
       
    }
    
    
    
    private bool Rays ()
    {
        float circumference = 2 * Mathf.PI;
        float angle = circumference / _countRays; 
        for (float currAngle = 0; currAngle < circumference; currAngle += angle)
        {
            Vector2 direction = new Vector2(Mathf.Cos(currAngle), Mathf.Sin(currAngle));
            RaycastHit2D hit= Physics2D.Raycast(transform.position,direction);
            BoxCollider2D temp = hit.collider.gameObject.GetComponent<BoxCollider2D>();
            if (temp != null)
                return true;
        }

        return false;

    }

    

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 surfaceNormal=other.contacts[0].normal;
        vector = Vector2.Reflect(lastvelocity.normalized,surfaceNormal);
     
    }
    
    
}
