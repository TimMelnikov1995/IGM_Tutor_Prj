using UnityEngine;
using Zenject;

namespace Tutor
{
    public class MainMenuWindow : Window
    {
        [Space]
        [Inject] GameStates _gameStates;
        [Inject] SceneLoader _sceneLoader;
        [Inject] GameSaveLoadData _gameSaveLoadData;
        [Inject] LevelsWindow _levelsWindow;
        [Inject] SettingsWindow _settingsWindow;
        [Inject] GameplayHudWindow _bulletsWindow;

        public override void Enable()
        {
            base.Enable();

            _bulletsWindow.Disable();
            _levelsWindow.Disable();
            _settingsWindow.Disable();
        }

        public override void Disable()
        {
            base.Disable();

            _bulletsWindow.Disable();
            _levelsWindow.Disable();
            _settingsWindow.Disable();
        }

        public void Play()
        {
            _gameStates.SetState<State_Loading>();
            _sceneLoader.LoadScene(_gameSaveLoadData.LastOpenLevel + 1);
            Disable();
        }

        public void Levels()
        {
            _levelsWindow.Enable();
            _settingsWindow.Disable();
            _bulletsWindow.Disable();
        }

        public void Settings()
        {
            _settingsWindow.Enable();
            _levelsWindow.Disable();
            _bulletsWindow.Disable();
        }

        public void HowToPlay()
        {
            _levelsWindow.Disable();
            _settingsWindow.Disable();
            _bulletsWindow.Disable();
        }
    }
}