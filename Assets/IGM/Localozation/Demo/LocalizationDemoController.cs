using UnityEngine;

namespace IGM.Localization.Demo
{
    public class LocalizationDemoController : MonoBehaviour
    {
        public void SetLanguage(string language)
        {
            LocalizationManager.Instance.SetLanguage(language);
        }
    }
}