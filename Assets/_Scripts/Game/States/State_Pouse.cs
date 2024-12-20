using UnityEngine;
using Zenject;

namespace Tutor
{
    public class State_Pouse : GameState
    {
        [Inject] PouseWindow _pouseWindow;

        [Inject] PouseInputListner _pouseInputListner;
        [Inject] PlayerMain _playerMain;

        public override void Enter()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            _pouseWindow.Enable();
            Time.timeScale = 0;

            _pouseInputListner.Activate();
            _playerMain.Diactivate();
        }

        public override void Exit()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _playerMain.Activate();
            _pouseWindow.Disable();
            Time.timeScale = 1;
        }
    }
}