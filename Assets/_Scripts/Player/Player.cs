using Tutor;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody m_rigidbody;

    [Inject] PlayerMain _playerMain;

    void OnEnable()
    {
        _playerMain.Register(transform, m_rigidbody);
    }

    void OnDisable()
    {
        _playerMain.Unregister();
    }
}