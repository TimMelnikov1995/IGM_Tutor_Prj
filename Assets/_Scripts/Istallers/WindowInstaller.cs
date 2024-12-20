using UnityEngine;
using Zenject;

namespace Tutor
{
    public class WindowInstaller : MonoInstaller
    {
        [SerializeField] MainMenuWindow m_mainMenuWindow;
        [SerializeField] SettingsWindow m_settingsWindow;
        [SerializeField] LevelsWindow m_levelsWindow;
        [SerializeField] GameplayHudWindow m_gameplayHudWindow;
        [SerializeField] LoadingWindow m_loadingWindow;
        [SerializeField] FinishWindow m_finishWindow;
        [SerializeField] PouseWindow m_pouseWindow;
        [SerializeField] DieWindow m_dieWindow;

        public override void InstallBindings()
        {
            Container.Bind<MainMenuWindow>().FromInstance(m_mainMenuWindow).AsSingle().NonLazy();
            Container.Bind<SettingsWindow>().FromInstance(m_settingsWindow).AsSingle().NonLazy();
            Container.Bind<LevelsWindow>().FromInstance(m_levelsWindow).AsSingle().NonLazy();
            Container.Bind<GameplayHudWindow>().FromInstance(m_gameplayHudWindow).AsSingle().NonLazy();
            Container.Bind<LoadingWindow>().FromInstance(m_loadingWindow).AsSingle().NonLazy();
            Container.Bind<FinishWindow>().FromInstance(m_finishWindow).AsSingle().NonLazy();
            Container.Bind<PouseWindow>().FromInstance(m_pouseWindow).AsSingle().NonLazy();
            Container.Bind<DieWindow>().FromInstance(m_dieWindow).AsSingle().NonLazy();
        }
    }
}