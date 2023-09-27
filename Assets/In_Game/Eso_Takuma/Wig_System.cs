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
        this.transform.localPosition = new Vector3(0, sin * wig_degree, this.transform.position.z);
        this.transform.localPosition += new Vector3(0, 0, wig_speed);//移動
        transform.LookAt(gameover_zone.transform);
    }
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("result");
    }
}
