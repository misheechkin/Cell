using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public void StartGameEasy()
   {
      Spawner.CountBalls = 1;
   }
   public void StartGameHard()
   {
      Spawner.CountBalls = 20;
   }
   public void StartGameNormal()
   {
      Spawner.CountBalls = 30;
   }
}
