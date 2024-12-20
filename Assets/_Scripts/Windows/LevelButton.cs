using TMPro;
using UnityEngine;
using Zenject;

namespace Tutor
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI m_levelName;

        [Inject] GameStates _gameStates;
        [Inject] SceneLoader _sceneLoader;

        int _levelIndex;

        void SetUI()
        {
            m_levelName.text = _levelIndex.ToString();
        }

        public void SetLevelIndex(int levelIndex)
        {
            _levelIndex = levelIndex;
            SetUI();
        }

        public void LoadLevel()
        {
            _gameStates.SetState<State_Loading>();
            _sceneLoader.LoadScene(_levelIndex);
        }
    }
}