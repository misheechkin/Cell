using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    public static int CountBalls;
  

    private void Awake()
    {
        for (var i = 0; i < CountBalls; i++)
        {
            Instantiate(ballPrefab);
        }
            
           
    }

  
}
