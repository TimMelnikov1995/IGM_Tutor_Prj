using UnityEngine;
using Zenject;

namespace Tutor
{
    public class State_Gameplay : GameState
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
            // Убирает шторку загрузки и активирует игрока, диативирует мышку, активирует BulletsWindow

            _loadingWindow.Disable();
            _mainMenuWindow.Disable();
            _levelsWindow.Disable();
            _settingsWindow.Disable();
            _finishWindow.Disable();

            _gameplayHudWindow.Enable();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _pouseInputListner.Activate();
            _playerMain.Activate();
        }
    }
}