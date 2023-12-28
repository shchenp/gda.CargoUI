using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class PassScreen : MonoBehaviour
    {
        public Action RestartButtonClicked;
        
        [SerializeField]
        private Button _restartButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(() => RestartButtonClicked?.Invoke());
        }

        private void OnDestroy()
        {
            _restartButton.onClick.RemoveListener(() => RestartButtonClicked?.Invoke());
        }
    }
}