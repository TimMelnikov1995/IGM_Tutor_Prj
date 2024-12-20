using Cysharp.Threading.Tasks;
using UnityEngine;
//using YG;
using Zenject;

namespace Tutor
{
    public class State_Die : GameState
    {
        [Inject] PouseInputListner _pouseInputListner;
        [Inject] PlayerMain _playerMain;
        [Inject] SceneLoader _sceneLoader;
        [Inject] GameStates _gameStates;
        [Inject] DieWindow _dieWindow;
        [Inject] PouseWindow _playerWindow;
        [Inject] SettingsWindow _settingsWindow;

        public override void Enter()
        {
            _pouseInputListner.Deactivate();
            _playerMain.Diactivate();
            _playerWindow.Disable();
            _settingsWindow.Disable();

            _dieWindow.Enable();
            _dieWindow.m_restartButton.onClick.AddListener(ShowAd);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        void ShowAd()
        {
            _dieWindow.m_restartButton.onClick.RemoveListener(ShowAd);

            //YandexGame.Instance.CloseFullscreenAd.AddListener(Continue);
            //YandexGame.Instance.ErrorFullscreenAd.AddListener(Continue);
            //YandexGame.Instance.CantFullscreenAd.AddListener(Continue);
            //YandexGame.FullscreenShow();
        }

        void Continue()
        {
            _sceneLoader.RestartCurrentLevel();
            _gameStates.SetState<State_Loading>();
            _dieWindow.Disable();

            _playerMain.Diactivate();
            _playerMain.Restore();

            //YandexGame.Instance.CloseFullscreenAd.RemoveListener(Continue);
            //YandexGame.Instance.ErrorFullscreenAd.RemoveListener(Continue);
            //YandexGame.Instance.CantFullscreenAd.RemoveListener(Continue);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}