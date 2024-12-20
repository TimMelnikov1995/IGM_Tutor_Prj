using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SaveLoadDemo
{
    public class SaveLoadDemo : MonoBehaviour
    {
        [SerializeField] int m_savableInt;
        [SerializeField] string m_savableString;
        [SerializeField] float m_savableFloat;
        [SerializeField] List<string> m_savableArray;

        [Inject] SaveLoadManager _saveLoadManager;



        [SaveLoad("TestInt")]
        public int SavableInt
        {
            get
            {
                return m_savableInt;
            }

            set
            {
                m_savableInt = value;
            }
        }

        [SaveLoad("TestString")]
        public string SavableString
        {
            get
            {
                return m_savableString;
            }

            set
            {
                m_savableString = value;
            }
        }

        [SaveLoad("TestFloat")]
        float SavableFloat
        {
            get
            {
                return m_savableFloat;
            }

            set
            {
                m_savableFloat = value;
            }
        }

        [SaveLoad("SavableArray")]
        List<string> SavableArray
        {
            get
            {
                return m_savableArray;
            }

            set
            {
                m_savableArray = value;
            }
        }

        void Awake()
        {
            _saveLoadManager.Register(this);
        }

        void OnDestroy()
        {
            _saveLoadManager.Unregister(this);
        }
    }
}