using DG.Tweening;
using System;
using UnityEngine;

namespace Tutor
{
    public class Window : MonoBehaviour
    {
        [SerializeField] CanvasGroup m_canvasGroup;
        [SerializeField] GameObject m_toggle;
        [SerializeField] float m_fadeTime = 0.5f;

        public event Action EOn_Enable;
        public event Action EOn_Disable;

        public virtual void Enable()
        {
            m_canvasGroup.interactable = true;
            m_canvasGroup.blocksRaycasts = true;
            m_toggle.SetActive(true);
            m_canvasGroup.DOKill();

            if (m_fadeTime > 0)
                m_canvasGroup.DOFade(1, m_fadeTime).SetUpdate(true);
            else
                m_canvasGroup.alpha = 1f;

            EOn_Enable?.Invoke();
        }

        public virtual void Disable()
        {
            m_canvasGroup.interactable = false;
            m_canvasGroup.blocksRaycasts = false;
            m_canvasGroup.DOKill();

            if (m_fadeTime > 0)
            {
                m_canvasGroup.DOFade(0, m_fadeTime).SetUpdate(true).onComplete += () => m_toggle.SetActive(false);
            }
            else
            {
                m_canvasGroup.alpha = 0;
                m_toggle.SetActive(false);
            }
                
            EOn_Disable?.Invoke();
        }

        public virtual void DisableInstantly()
        {
            m_canvasGroup.alpha = 0;
            m_toggle.SetActive(false);

            EOn_Disable?.Invoke();
        }
    }
}