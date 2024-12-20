using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Tutor
{
    public class GameState
    {
        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {
            
        }
    }
}

public class Statics
{
    public class Wallet
    {
        public static readonly string CoinWalletName = "Coins";
    }

    public class Life
    {
        public static readonly int MaxLifeCount = 123;
    }
}