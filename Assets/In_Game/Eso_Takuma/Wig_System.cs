using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wig_System : MonoBehaviour
{
    [SerializeField] GameObject gameover_zone = null;
    public float wig_speed = 0.2f;//����̈ړ����x
    public float wig_degree = 3;//����̐U�ꕝ

    void Start()
    {

    }

    void FixedUpdate()
    {
        float sin = Mathf.Sin(Time.time);
        var dir = transform.TransformDirection(transform.forward);
        this.transform.localPosition += dir * wig_speed;
        //this.transform.localPosition += new Vector3(0, 0, wig_speed);//�ړ�
        transform.LookAt(gameover_zone.transform);
    }
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("result");
    }
}
