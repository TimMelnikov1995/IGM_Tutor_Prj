using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace IGM.Localization
{
    public class LocalizationManager : MonoBehaviour
    {
        #region Singelton
        private static LocalizationManager _instance;
        public static LocalizationManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = GameObject.FindObjectOfType<LocalizationManager>();

                return _instance;
            }
        }
        #endregion

        [SerializeField] Language[] m_languages;
        [SerializeField, HideInInspector] string[] _allTexts;
        string text;

        public Action OnChangeLanguage;



        [Inject]
        void Construct()
        {
            SetLanguage("ru");
        }


        [ContextMenu("GetTexts")]
        void GetTexts()
        {
            _allTexts = text.Split("//");
            for (int i = 0; i < _allTexts.Length; i++)
            {
                _allTexts[i] = _allTexts[i].Trim();
            }
        }

        [ContextMenu("Cheack text same names")]
        void CheackTextSameNames()
        {
            GetTexts();

            var dict = new Dictionary<string, int>();
            bool allGood = true;

            for (int i = 0; i < _allTexts.Length; i++)
            {
                if ((i % 2) == 0)
                {
                    dict.TryGetValue(_allTexts[i], out int count);
                    dict[_allTexts[i]] = count + 1;
                }
            }

            foreach (var pair in dict)
            {
                if (pair.Value > 1)
                {
                    Debug.LogError("Name <<" + pair.Key + ">> occurred " + pair.Value + " times.");
                    allGood = false;
                }
            }

            if (allGood)
                print("No same names");
        }

        
        public void SetLanguage(string language)
        {
            bool hasLang = false;
            foreach(var lang in m_languages)
            {
                if(lang.Lang == language)
                    hasLang = true;
            }

            if (hasLang == false)
                return;

            text = m_languages[GetLangIndex(language)].Text;

            GetTexts();

            OnChangeLanguage?.Invoke();
        }

        public int GetLangIndex(string lang)
        {
            int langIndex = 0;

            for (int i = 0; i < m_languages.Length; i++)
            {
                if (m_languages[i].Lang == lang)
                {
                    langIndex = i;
                    break;
                }
            }

            return langIndex;
        }

        public string GetTextByName(string textName)
        {
            int index = Array.IndexOf(_allTexts, textName);
            return _allTexts[index + 1];
        }




        [Serializable]
        class Language
        {
            [SerializeField] string m_lang;

            [Tooltip("Format:\n" +
            "Name1//\n" +
            "Text1\n" +
            "//Name2//\n" +
            "Text2\n" +
            "//Name3//\n" +
            "Text3")]
            [SerializeField] TextAsset m_text;

            public string Lang => m_lang;
            public string Text => m_text.text;
        }
    }
}