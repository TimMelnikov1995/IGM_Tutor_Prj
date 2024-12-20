//using YG;
using UnityEngine;
using Zenject;

namespace Tutor
{
    public class FinishWindow : Window
    {
        [Space]
        [Inject] SceneLoader _sceneLoader;
        [Inject] GameStates _gameStates;

        void Awake()
        {
            DisableInstantly();
        }

        void Continue()
        {
            _sceneLoader.LoadNextLevel();
            _gameStates.SetState<State_Loading>();

            //YandexGame.Instance.CloseFullscreenAd.RemoveListener(Continue);
            //YandexGame.Instance.ErrorFullscreenAd.RemoveListener(Continue);
            //YandexGame.Instance.CantFullscreenAd.RemoveListener(Continue);
        }

        public void ShowAd()
        {
            //YandexGame.Instance.CloseFullscreenAd.AddListener(Continue);
            //YandexGame.Instance.ErrorFullscreenAd.AddListener(Continue);
            //YandexGame.Instance.CantFullscreenAd.AddListener(Continue);
            //YandexGame.FullscreenShow();
        }
    }
}