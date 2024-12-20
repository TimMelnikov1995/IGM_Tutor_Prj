using Zenject;
using UnityEngine;

namespace Tutor
{
    public class PouseWindow : Window
    {
        [Space]
        [Inject] GameStates _gameStates;
        [Inject] SettingsWindow _settingsWindow;
        [Inject] SceneLoader _sceneLoader;

        void Awake()
        {
            DisableInstantly();
        }

        public override void Enable()
        {
            base.Enable();
            print("Pouse");
        }

        public override void Disable()
        {
            base.Disable();
        }

        public void Resume()
        {
            _gameStates.SetState<State_Gameplay>();
        }

        public void Settings()
        {
            _settingsWindow.Enable();
        }

        public void ToMenu()
        {
            _gameStates.SetState<State_Menu>();
            _sceneLoader.UnloadCurrentLevel();
        }
    }
}