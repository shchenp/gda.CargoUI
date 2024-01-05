using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UI;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScreenManager : Singleton<ScreenManager>
{
    public Action OnGameStarted;
    
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private FailedScreen _failedScreen;
    [SerializeField] private PassScreen _passScreen;
    
    private bool _isFirstAttempt = true;

    protected override void Awake()
    {
        base.Awake();
    
        Instance._startScreen.PlayButtonClicked += StartGame;

        Instance._failedScreen.RestartButtonClicked += RestartGame;

        Instance._passScreen.RestartButtonClicked += RestartGame;
        
        if (Instance._isFirstAttempt)
        {
            ShowStartScreen();
            
            Instance._isFirstAttempt = false;   
        }
        else
        {
            StartGame();
        }
    }

    private void ShowStartScreen()
    {
        Instance._startScreen.gameObject.SetActive(true);
    }

    private void StartGame()
    {
        Instance._startScreen.gameObject.SetActive(false);
        Instance.OnGameStarted?.Invoke();
    }

    private void RestartGame()
    { 
        SceneManager.LoadScene(GlobalConstants.SCENE_NAME);
        
        Instance._failedScreen.gameObject.SetActive(false);
        Instance._passScreen.gameObject.SetActive(false);
    }

    public void ShowFailedScreen()
    {
        Instance._failedScreen.gameObject.SetActive(true);
    }

    public void ShowPassScreen()
    {
        Instance._passScreen.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        Instance._startScreen.PlayButtonClicked -= StartGame;

        Instance._failedScreen.RestartButtonClicked -= RestartGame;

        Instance._passScreen.RestartButtonClicked -= RestartGame;
    }
}
