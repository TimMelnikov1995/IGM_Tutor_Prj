using System;
using UnityEngine;
using Zenject;

namespace Tutor
{
    public class GameSaveLoadData
    {
        [Inject] SaveLoadManager _saveLoadManager;

        int _lastOpenLevel;

        [SaveLoad("LastOpenLevel")]
        public int LastOpenLevel
        {
            get
            {
                return _lastOpenLevel;
            }
            set
            {
                _lastOpenLevel = value;
                EOnChange_LastOpenLevel?.Invoke(_lastOpenLevel);
            }
        }

        public event Action<int> EOnChange_LastOpenLevel;

        [Inject]
        void Init()
        {
            _saveLoadManager.Register(this);
        }

        public void AddOpenLevel()
        {
            _lastOpenLevel++;
        }
    }
}