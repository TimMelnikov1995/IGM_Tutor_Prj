using Zenject;

namespace Tutor
{
    public class InputsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PouseInputListner>().AsSingle().NonLazy();
        }
    }
}