using System;
using Assets.Scripts.Infrastructure.GameOption.WindowsData;
using Assets.Scripts.Infrastructure.Services.Asset;
using Assets.Scripts.Infrastructure.Services.PlayerProgress;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.UI.Factory
{
    class UIFactory : IUIFactory
    {
        private readonly IAssetService _asset;
        private readonly IStaticDataService _staticData;
        private readonly GameStateMachine _stateMachine;
        private readonly IProgressService _progressService;
        private Transform _uiRoot;

        public UIFactory(IAssetService asset, IStaticDataService staticData, GameStateMachine stateMachine, IProgressService progressService)
        {
            _asset = asset;
            _staticData = staticData;
            _stateMachine = stateMachine;
            _progressService = progressService;
        }

        public void CreateUIRoot() =>
            _uiRoot = _asset.Instantiate(AssetPath.UIRootPath).transform;

        public void Open(WindowsId windowID)
        {
            switch (windowID)
            {
                case WindowsId.None:
                    break;
                case WindowsId.GameMenu:
                    CreateGameMenuWindow();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(windowID), windowID, null);
            }
        }

        private void CreateGameMenuWindow()
        {
            WindowConfig windowConfig = _staticData.GetWindow(WindowsId.GameMenu);
            FirstMenuPresenter firstMenuPresenter = GameObject.Instantiate(windowConfig.WindowPrefab, _uiRoot).GetComponent<FirstMenuPresenter>();
            firstMenuPresenter.Construct(_stateMachine, _staticData, _progressService);
            firstMenuPresenter.Initialize(_progressService.CurrrentScore);
        }
    }
}