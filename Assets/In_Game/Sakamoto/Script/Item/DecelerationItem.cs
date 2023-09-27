//日本語対応
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 減速アイテム
/// </summary>
public class DecelerationItem : MonoBehaviour, IItem
{
    [SerializeField] private float _decelerationNum = 0;

    public void Execute(IPlayer player)
    {
        player.Speed = player.DefaultSpeed;
        player.DecelerationEffect();
        Debug.Log("スピードがダウンしました");
    }
}
