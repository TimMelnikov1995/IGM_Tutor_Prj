using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Tutor
{
    public class State_Finish : GameState
    {
        [Inject] FinishWindow _finishWindow;
        [Inject] GameplayHudWindow _gameplayHudWindow;
        [Inject] PlayerMain _playerMain;
        [Inject] GameSaveLoadData _gameSaveLoadData;
        [Inject] SceneLoader _sceneLoader;
        [Inject] SaveLoadManager _saveLoadManager;

        [Inject] PouseInputListner _pouseInputListner;

        async UniTaskVoid Finish()
        {
            int currentSceneIndex = _sceneLoader.CurrentSceneIndex;
            int lastOpenLevelIndex = _gameSaveLoadData.LastOpenLevel;

            if (currentSceneIndex > lastOpenLevelIndex)
            {
                _gameSaveLoadData.AddOpenLevel();
            }

            _saveLoadManager.Save();

            //await UniTask.Delay(System.TimeSpan.FromSeconds(4));
        }

        public override void Enter()
        {
            _gameplayHudWindow.Disable();
            _playerMain.Diactivate();

            _finishWindow.Enable();

            Finish();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            _pouseInputListner.Deactivate();
        }

        public override void Exit()
        {
            _finishWindow.Disable();
            _playerMain.Restore();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}