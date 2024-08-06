using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class InteractButton: MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        public event Action OnClick;

        private void Awake() => 
            _button.onClick.AddListener(() => OnClick?.Invoke());

    }
}