using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wig_System : MonoBehaviour
{
    [SerializeField] GameObject gameover_zone = null;
    public float wig_speed = 0.2f;//かつらの移動速度
    public float wig_degree = 3;//かつらの振れ幅

    void Start()
    {

    }

    void FixedUpdate()
    {
        float sin = Mathf.Sin(Time.time);
        var dir = transform.TransformDirection(transform.forward);
        this.transform.localPosition += dir * wig_speed;
        transform.LookAt(gameover_zone.transform);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("当たった");
        if (other.gameObject.CompareTag("peoples"))
        {
            SceneManager.LoadScene("result");
        }
        else if (other.gameObject.CompareTag("wig"))
        {
            SceneManager.LoadScene("Clear");
        }
    }
}
