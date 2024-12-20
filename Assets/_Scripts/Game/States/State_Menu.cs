using UnityEngine;
using Zenject;

namespace Tutor
{
    public class State_Menu : GameState
    {
        [Inject] MainMenuWindow _mainMenuWindow;
        [Inject] LevelsWindow _levelsWindow;
        [Inject] SettingsWindow _settingsWindow;
        [Inject] GameplayHudWindow _gameplayHudWindow;
        [Inject] LoadingWindow _loadingWindow;
        [Inject] FinishWindow _finishWindow;

        [Inject] PlayerMain _playerMain;
        [Inject] PouseInputListner _pouseInputListner;

        public override void Enter()
        {
            _playerMain.Diactivate();
            _playerMain.Restore();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            _levelsWindow.Disable();
            _settingsWindow.Disable();
            _gameplayHudWindow.Disable();
            _loadingWindow.Disable();
            _finishWindow.Disable();

            _pouseInputListner.Deactivate();

            _mainMenuWindow.Enable();
        }

        public override void Exit()
        {
            _mainMenuWindow.Disable();
            _settingsWindow.Disable();
            _gameplayHudWindow.Disable();
            _loadingWindow.Disable();
            _finishWindow.Disable();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}