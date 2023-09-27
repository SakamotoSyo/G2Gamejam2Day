//日本語対応
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class InvincibleItem : MonoBehaviour, IItem
{
    [SerializeField] private float _invincibleNum = 3;
    public void Execute(IPlayer player)
    {
        player.InvincibleEffectOn();
        Invincible(player).Forget();
    }

    private async UniTask Invincible(IPlayer player) 
    {
        player.God = true;
        await UniTask.WaitForSeconds(_invincibleNum);
        player.God = false;
        player.InvincibleEffectOff();
    }

}
