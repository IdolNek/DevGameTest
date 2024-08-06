using Assets.Scripts.Infrastructure.GameOption.WindowsData;
using Assets.Scripts.Infrastructure.UI.Factory;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class OpenWindowsButton : MonoBehaviour
    {
        [SerializeField] private WindowsId _windowID;
        [SerializeField] private Button _buttonMenu;
        private IUIFactory _uiFactory;

        public void Construct(IUIFactory uiFactory) =>
            _uiFactory = uiFactory;
        private void Awake() => 
            _buttonMenu.onClick.AddListener(Open);

        private void Open() => 
            _uiFactory.Open(_windowID);
    }
}