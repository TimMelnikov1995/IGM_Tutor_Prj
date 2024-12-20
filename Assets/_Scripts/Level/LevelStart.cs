using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Tutor
{
    public class LevelStart : MonoBehaviour
    {
        [SerializeField] Transform m_startPoint;

        [Inject] GameStates _gameStates;
        [Inject] PlayerMain _playerMain;

        void Start()
        {
            if (_playerMain.SelfTransform)
            {
                _playerMain.SelfTransform.position = m_startPoint.position;
                _playerMain.SelfTransform.rotation = m_startPoint.rotation;
            }

            StartLevel();
        }

        async UniTaskVoid StartLevel()
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(0.5f));
            _gameStates.SetState<State_Gameplay>();
        }
    }
}