using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenStarter : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    private void Start()
    {
        _startScreen.SetActive(true);
    }
}
