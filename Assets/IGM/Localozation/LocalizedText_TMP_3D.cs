using TMPro;
using UnityEngine;

namespace IGM.Localization
{
    [RequireComponent(typeof(TextMeshPro))]
    public class LocalizedText_TMP_3D : LocalizedText
    {
        [SerializeField] string m_textName;
        [SerializeField, HideInInspector] TextMeshPro m_text;

        void Awake()
        {
            m_text = GetComponent<TextMeshPro>();
            UpdateText();
        }

        new void OnEnable()
        {
            base.OnEnable();
        }

        new void OnDisable()
        {
            base.OnDisable();
        }

        public override void UpdateText()
        {
            m_text.text = LocalizationManager.Instance.GetTextByName(m_textName);
        }
    }
}