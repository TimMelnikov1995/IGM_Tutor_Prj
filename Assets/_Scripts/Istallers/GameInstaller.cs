using Zenject;

namespace Tutor
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStates>().AsSingle().NonLazy();

            Container.Bind<SceneLoader>().AsSingle().NonLazy();
            Container.Bind<SaveLoadManager>().AsSingle().NonLazy();
            Container.Bind<GameSaveLoadData>().AsSingle().NonLazy();
        }
    }
}