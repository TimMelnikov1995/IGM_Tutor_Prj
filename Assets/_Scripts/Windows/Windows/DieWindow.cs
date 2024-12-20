using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Tutor
{
    public class DieWindow : Window
    {
        [Space]
        [field: SerializeField] public Button m_restartButton;
        [SerializeField] float m_restartButtonDelay = 2;

        void Awake()
        {
            DisableInstantly();
        }

        public override void Enable()
        {
            base.Enable();

            Proccess();
        }

        async UniTaskVoid Proccess()
        {
            m_restartButton.gameObject.SetActive(false);
            await UniTask.Delay(System.TimeSpan.FromSeconds(m_restartButtonDelay));
            m_restartButton.gameObject.SetActive(true);
        }
    }
}