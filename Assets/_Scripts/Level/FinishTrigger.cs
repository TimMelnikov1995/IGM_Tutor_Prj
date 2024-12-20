using UnityEngine;
using Zenject;

namespace Tutor
{
    [RequireComponent(typeof(Collider))]
    public class FinishTrigger : MonoBehaviour
    {
        [Inject] GameStates _gameState;
        Collider _collider;

        void Awake()
        {
            _collider = GetComponent<BoxCollider>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                _collider.enabled = false;
                _gameState.SetState<State_Finish>();
            }
        }
    }
}