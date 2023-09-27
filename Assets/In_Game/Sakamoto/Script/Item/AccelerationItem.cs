//日本語対応
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スピードアップアイテム
/// </summary>
public class AccelerationItem : MonoBehaviour, IItem 
{
    [Tooltip("上昇させる値")]
    [SerializeField] private float _acceletarion = 0;

    public void Execute(IPlayer player)
    {
        player.Speed += _acceletarion;
        Debug.Log("スピードアップ");
        player.AccelerationEffect();
    }
}
