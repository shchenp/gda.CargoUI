using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
   public Action PlayerFailed;
   public Action PlayerPassed;
   
   [SerializeField]
   private Line _line;

   protected override void Awake()
   {
      base.Awake();

      ScreenManager.Instance.OnGameStarted += Run;
   }

   private void Run()
   {
      Instance._line.enabled = true;
   }

   public void SetLineDrawer(Line line)
   {
      Instance._line = line;
   }

   private void OnDestroy()
   {
      ScreenManager.Instance.OnGameStarted -= Run;
   }
}
