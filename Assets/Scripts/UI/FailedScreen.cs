using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FailedScreen : MonoBehaviour
    {
        public Action RestartButtonClicked;
        public Action ExitButtonClicked;
        
        [SerializeField]
        private Button _restartButton;
        [SerializeField]
        private Button _exitButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(() => RestartButtonClicked?.Invoke());
            _exitButton.onClick.AddListener(() => ExitButtonClicked?.Invoke());
        }

        private void OnDestroy()
        {
            _restartButton.onClick.RemoveListener(() => RestartButtonClicked?.Invoke());
            _exitButton.onClick.RemoveListener(() => ExitButtonClicked?.Invoke());
        }
    }
}