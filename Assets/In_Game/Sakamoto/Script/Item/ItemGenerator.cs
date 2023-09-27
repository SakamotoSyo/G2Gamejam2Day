//日本語対応
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [Tooltip("何秒ごとに生成するか")]
    [SerializeField] private float _generateTime;

    [Tooltip("生成のタイミングにどれ程度ランダム性を持たせるか")]
    [SerializeField] private float _randomNum = 0;

    [Tooltip("スタート位置")]
    [SerializeField] private Transform _startPos;

    [SerializeField] private List<StageGachaData> _itemGachaList = new List<StageGachaData>();

    private float _startY;

    private void Start()
    {
        _startY = _startPos.position.y;
        StartCoroutine(ItemGenerate());
    }


    private IEnumerator ItemGenerate()
    {
        var time = _generateTime;
        var randomNum = Random.Range(_randomNum * -1, _randomNum);
        time += randomNum;
        yield return new WaitForSeconds(time);

        Instantiate(_itemGachaList[StageChoose()].Prefab, new Vector3(_startPos.position.x, _startY, _startPos.position.z), gameObject.transform.rotation);
        Debug.Log("生成");
        StartCoroutine(ItemGenerate());
    }

    /// <summary>
    ///設定した確率からアイテムを選ぶ
    /// </summary>
    public int StageChoose()
    {

        //合計の重みを計算
        float total = 0;
        for (int i = 0; i < _itemGachaList.Count; i++)
        {
            total += _itemGachaList[i].Probability;
        }

        float randomNum = Random.value * total;
        float saveProbability = 0;
        //抽選
        for (int i = 0; i < _itemGachaList.Count; i++)
        {
            if (randomNum < _itemGachaList[i].Probability + saveProbability)
            {
                return (int)_itemGachaList[i].ItemType;
            }
            else
            {
                saveProbability += _itemGachaList[i].Probability;
            }
        }

        return (int)_itemGachaList[_itemGachaList.Count - 1].ItemType;
    }

    [System.Serializable]
    class StageGachaData
    {
        public float Probability => _probability;
        public GameObject Prefab => _itemPrefab;
        public ItemType ItemType => _itemType;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private float _probability;
    }


    public enum ItemType
    {
        Invincible,
        Deceleration,
        Acceleration,
    }

}
