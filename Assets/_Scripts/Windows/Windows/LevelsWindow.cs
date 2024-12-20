using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tutor
{
    public class LevelsWindow : Window
    {
        [Space]
        [SerializeField] RectTransform m_content;
        [SerializeField] LevelButton m_levelButton;
        [SerializeField] CloseLevelImage m_closeLevelImage;

        [Inject] GameSaveLoadData _data;
        [Inject] DiContainer _diContainer;

        void Awake()
        {
            DisableInstantly();
        }

        public override void Enable()
        {
            base.Enable();

            int _lastOpenLevel= _data.LastOpenLevel + 1;
            SetLevelCount(_lastOpenLevel);
        }

        float GetContentHeigh(int levelCount)
        {
            return levelCount / 4 * 100;
        }

        void SpawnButtons(int levelCount)
        {
            for(int i = 0; i < levelCount; i++)
            {
                LevelButton levelButton = _diContainer.InstantiatePrefab(m_levelButton, m_content).GetComponent<LevelButton>();
                levelButton.SetLevelIndex(i + 1);
            }
        }

        void SpawnCloseLevelImages(int count)
        {
            for (int i = 0; i < count; i++)
            {
                CloseLevelImage levelImage = _diContainer.InstantiatePrefab(m_closeLevelImage, m_content).GetComponent<CloseLevelImage>();
            }
        }

        void SetLevelCount(int value)
        {
            m_content.sizeDelta = new Vector2(0, GetContentHeigh(value));
            DeleteLevelButtons();

            int maximumLevel = SceneLoader.MaximumLevel;

            if (value > maximumLevel)
                value = maximumLevel;

            SpawnButtons(value);
            SpawnCloseLevelImages(maximumLevel - value);
        }

        void DeleteLevelButtons()
        {
            List<GameObject> toDelete = new List<GameObject>();

            if (m_content.GetComponentsInChildren<Transform>().Length == 0)
                return;

            foreach(Transform go in m_content.GetComponentsInChildren<Transform>())
            {
                if (go != m_content.transform)
                    toDelete.Add(go.gameObject);
            }

            foreach(GameObject go in toDelete)
            {
                Destroy(go);
            }

            toDelete.Clear();
        }
    }
}