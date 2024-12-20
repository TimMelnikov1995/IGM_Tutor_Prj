using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using Zenject;
//using YG;
using IGM.Localization;

namespace Tutor
{
    public class GameStates 
    {
        Dictionary<Type, GameState> _states = new Dictionary<Type, GameState>();
        GameState _currentState;

        public GameState CurrentState => _currentState;

        [Inject] DiContainer _diContainer;
        [Inject] SaveLoadManager _saveLoadManager;



        [Inject]
        void Init()
        {
            AddGameStates();
            InitProccess();
        }

        async UniTaskVoid InitProccess()
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(0.1f));
            SetState<State_Menu>();
            _saveLoadManager.Load();

            //string lang = YandexGame.EnvironmentData.language;
            LocalizationManager.Instance.SetLanguage("ru");
        }

        void AddGameStates()
        {
            AddState(new State_Menu());
            AddState(new State_Loading());
            AddState(new State_Gameplay());
            AddState(new State_Die());
            AddState(new State_Finish());
            AddState(new State_Pouse());

            foreach (var state in _states.Values)
            {
                _diContainer.Inject(state);
            }
        }

        void AddState(GameState state)
        {
            _states.Add(state.GetType(), state);
        }



        public void SetState<T>() where T : GameState
        {
            var type = typeof(T);

            if (_currentState != null && _currentState.GetType() == type)
            {
                return;
            }

            if (_states.TryGetValue(type, out var newState))
            {
                _currentState?.Exit();
                _currentState = newState;
                _currentState.Enter();
            }
        }
    }
}