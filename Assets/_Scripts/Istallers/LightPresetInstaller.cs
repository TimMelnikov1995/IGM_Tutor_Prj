using UnityEngine;
using Zenject;

namespace Tutor
{
    public class LightPresetInstaller : MonoInstaller
    {
        [SerializeField] LightPresetManager m_lightPresetManager;

        public override void InstallBindings()
        {
            Container.Bind<LightPresetManager>().FromInstance(m_lightPresetManager).AsSingle().NonLazy();
        }
    }
}