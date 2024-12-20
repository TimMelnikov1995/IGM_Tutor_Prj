using UnityEngine;
using Zenject;

namespace Tutor
{
    public class State_Loading : GameState
    {
        [Inject] MainMenuWindow _mainMenuWindow;
        [Inject] LevelsWindow _levelsWindow;
        [Inject] SettingsWindow _settingsWindow;
        [Inject] GameplayHudWindow _gameplayHudWindow;
        [Inject] LoadingWindow _loadingWindow;
        [Inject] FinishWindow _finishWindow;

        [Inject] PouseInputListner _pouseInputListner;
        [Inject] PlayerMain _playerMain;

        public override void Enter()
        {
            // Запускает шторку загрузки с крутящейся штукой, диактивирует игрока и запускает рекламу, деактивирует мышку.

            _playerMain.Diactivate();

            _mainMenuWindow.Disable();
            _levelsWindow.Disable();
            _settingsWindow.Disable();
            _gameplayHudWindow.Disable();
            _finishWindow.Disable();

            _loadingWindow.Enable();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _pouseInputListner.Deactivate();
        }

        public override void Exit()
        {
            _loadingWindow.Disable();
        }
    }
}