using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public GameObject textWin;
    public GameObject textLose;
    public GameObject Window;
    public Timer time;
    [SerializeField]
    private DrawManager _drawManager;
    private void Awake()
    {
        textWin.SetActive(false);
        textLose.SetActive(false);
        Window.SetActive(false);
    }

    private void Update()
    {
        Check();
    }

    public void Check()
    {
        if (Ball.count==0)
        {
            Window.SetActive(true);
            textLose.SetActive(false);
            textWin.SetActive(true);
            Destroy(_drawManager);
            Destroy(time);
        }
        else if(time._timeLeft==0)
        {
            Window.SetActive(true);
            textLose.SetActive(true);
            textWin.SetActive(false);
            Destroy(_drawManager);
            Destroy(time);
        }
        
    }
    
}
