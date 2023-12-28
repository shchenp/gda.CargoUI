using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private ScreenManager _screenManager;
    [SerializeField] private GameController _gameController;

    protected override void Awake()
    {
        base.Awake();
        
        Instance._gameController.PlayerFailed += _screenManager.ShowFailedScreen;
        Instance._gameController.PlayerPassed += _screenManager.ShowPassScreen;
    }

    private void OnDestroy()
    {
        Instance._gameController.PlayerFailed -= _screenManager.ShowFailedScreen;
        Instance._gameController.PlayerPassed -= _screenManager.ShowPassScreen;
    }
}
