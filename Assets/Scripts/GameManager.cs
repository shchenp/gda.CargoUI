using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
   private UIManager _uiManager;
   private Line _line;

   private void Start()
   {
      _uiManager = UIManager.Instance;
   }

   public void Run()
   {
      _line.enabled = true;
   }

   public void SetLineDrawer(Line line)
   {
      Instance._line = line;
   }
   
   public void RestartScene()
   {
      SceneManager.LoadScene(GlobalConstants.SCENE_NAME);
   }
}
