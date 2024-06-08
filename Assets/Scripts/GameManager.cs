using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public void StartGameEasy()
   {
      Spawner.CountBalls = 2;
   }
   public void StartGameHard()
   {
      Spawner.CountBalls = 4;
   }
   public void StartGameNormal()
   {
      Spawner.CountBalls = 5;
   }
}
