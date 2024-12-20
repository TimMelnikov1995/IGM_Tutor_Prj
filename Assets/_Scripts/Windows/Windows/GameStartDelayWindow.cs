using Cysharp.Threading.Tasks;

namespace Tutor
{
    public class GameStartDelayWindow : Window
    {
        void Awake()
        {
            Enable();
            StartDelay();
        }

        async UniTaskVoid StartDelay()
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(1));
            Disable();
        }
    }
}