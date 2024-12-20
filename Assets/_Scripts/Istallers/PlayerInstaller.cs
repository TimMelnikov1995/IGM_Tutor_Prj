using UnityEngine;
using Zenject;

namespace Tutor
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] PlayerMain m_playerMain;

        public override void InstallBindings()
        {
            Container.Bind<PlayerMain>().FromInstance(m_playerMain).AsSingle().NonLazy();
        }
    }
}