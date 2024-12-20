using UnityEngine;
using Zenject;

namespace SaveLoadDemo
{
    public class Game : MonoBehaviour
    {
        [Inject] SaveLoadManager _saveLoadManager;

        void Start()
        {
            //_saveLoadManager.Load();
        }

        [ContextMenu("Save")]
        void Save()
        {
            _saveLoadManager.Save();
        }

        [ContextMenu("Clear")]
        void Clear()
        {
            _saveLoadManager.Clear();
        }
    }
}