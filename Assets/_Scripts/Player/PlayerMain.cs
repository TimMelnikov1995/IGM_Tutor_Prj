using UnityEngine;
using Zenject;

namespace Tutor
{
    public class PlayerMain : MonoBehaviour
    {
        [SerializeField] Transform m_selfTransform;
        [SerializeField] Rigidbody m_rigidbody;

        [Inject] GameStates _gameStates;

        public Transform SelfTransform => m_selfTransform;



        void OnDead()
        {
            _gameStates.SetState<State_Die>();
        }



        public void Activate()
        {
            if (m_rigidbody)
                m_rigidbody.isKinematic = false;
        }

        public void Diactivate()
        {
            if (m_rigidbody)
                m_rigidbody.isKinematic = true;
        }

        public void Restore()
        {

        }

        public void Ressurect()
        {

        }



        public void Register(Transform selfTransform, Rigidbody rigidbody)
        {
            m_selfTransform = selfTransform;
            m_rigidbody = rigidbody;
        }

        public void Unregister()
        {

        }
    }
}