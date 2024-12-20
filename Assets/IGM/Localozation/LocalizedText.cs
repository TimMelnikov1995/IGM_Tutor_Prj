using UnityEngine;

namespace IGM.Localization
{
    public abstract class LocalizedText : MonoBehaviour
    {
        protected void OnEnable()
        {
            UpdateText();
            LocalizationManager.Instance.OnChangeLanguage += UpdateText;
        }

        protected void OnDisable()
        {
            LocalizationManager.Instance.OnChangeLanguage -= UpdateText;
        }

        public abstract void UpdateText();
    }
}