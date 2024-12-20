using System;
using UnityEngine;

namespace Tutor
{
    public class DamageTrigger : MonoBehaviour
    {
        [SerializeField] DamageInfo m_damageInfo = new();
        [SerializeField] bool m_destroyAfterDamage;
        [SerializeField] bool m_destroyIfContact;

        public event Action EOn_Contact;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageble damageble))
            {
                damageble.GetDamage(m_damageInfo);
                EOn_Contact?.Invoke();
                Destroy();
            }

            if (m_destroyIfContact)
            {
                EOn_Contact?.Invoke();
                Destroy();
            }
        }

        void Destroy()
        {
            if(m_destroyAfterDamage)
                Destroy(gameObject);
        }
    }
}