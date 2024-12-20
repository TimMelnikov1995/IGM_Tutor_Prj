using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Threading;

namespace Tutor
{
    public class GameplayHudWindow : Window
    {
        [Space]
        [SerializeField] TextMeshProUGUI m_valueText;
        [SerializeField] float m_reactionTime = 0.5f;
        [SerializeField] float m_reactionSize = 1.5f;

        CancellationTokenSource _cts = new();

        void Awake()
        {
            DisableInstantly();
        }

        async UniTaskVoid UiReaction()
        {
            m_valueText.transform.DOKill();

            m_valueText.transform.DOScale(m_reactionSize, m_reactionTime / 2);
            await UniTask.Delay(System.TimeSpan.FromSeconds(m_reactionTime / 2), cancellationToken: _cts.Token);

            m_valueText.transform.DOScale(1, m_reactionTime / 2);
        }

        void OnDisable()
        {
            _cts.Cancel();
            m_valueText.transform.DOKill();
            m_valueText.transform.localScale = Vector3.one;
        }

        public void SetVale(int value)
        {
            m_valueText.text = value.ToString();
            UiReaction();
        }
    }
}