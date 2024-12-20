using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Tutor
{
    public class PouseInputListner
    {
        bool _isActive;

        [Inject] GameStates _gameStates;

        [Inject]
        void Init()
        {
            Start();
        }

        async UniTaskVoid Start()
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(0.1f));

            UpdateService.AddUpdate(OnUpdate);
        }

        void OnUpdate()
        {
            if (_isActive == false)
                return;

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (_gameStates.CurrentState.GetType() == typeof(State_Gameplay))
                    _gameStates.SetState<State_Pouse>();
                else
                    _gameStates.SetState<State_Gameplay>();
            }
        }

        public void Activate()
        {
            _isActive = true;
        }

        public void Deactivate()
        {
            _isActive = false;
        }
    }
}