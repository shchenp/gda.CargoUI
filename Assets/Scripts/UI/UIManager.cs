using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _failedScreen;
    [SerializeField] private GameObject _passScreen;

    private GameManager _gameManager;
    private bool _isFirstAttempt = true;

    protected override void Awake()
    {
        base.Awake();
        
        if (Instance._isFirstAttempt)
        {
            Instance.ShowStartScreen();
            
            Instance._isFirstAttempt = false;   
        }
        else
        {
            GameManager.Instance.Run();
        }
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    public void ShowStartScreen()
    {
        ShowScreen(_startScreen);
    }
    
    public void ShowFailedScreen()
    {
        ShowScreen(_failedScreen);
    }
    
    public void ShowPassScreen()
    {
        ShowScreen(_passScreen);
    }
    
    private void ShowScreen(GameObject screen)
    {
        screen.SetActive(true);
    }
}
