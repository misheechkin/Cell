using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    public int CountBalls;

    private void Awake()
    {
        for(var i=0; i < CountBalls; i++)
            Instantiate(ballPrefab);
    }
}
