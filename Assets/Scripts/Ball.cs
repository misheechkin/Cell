using UnityEngine;
using Random = System.Random;

public class Ball : MonoBehaviour
{
    public float speed=1f;
    private Rigidbody2D rb;
    private Vector2 vector;
    private Vector2 lastvelocity;
    private void Start()
    {
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
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 surfaceNormal=other.contacts[0].normal;
        vector = Vector2.Reflect(lastvelocity.normalized,surfaceNormal);
     
    }
}
