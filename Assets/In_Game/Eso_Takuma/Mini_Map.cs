using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Map : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject wig;
    [SerializeField] GameObject gameover_zone;

    private GameObject player_sp;
    private GameObject wig_sp;
    private GameObject gameover_zone_sp;

    public float object_total_mileage;
    public float sprite_total_mileage;

    public float player_start_position;
    public float player_sprite_start_position;
    public float wig_start_position;
    public float wig_sprite_start_position;

    public float player_stage_ratio;
    public float player_sprite_ratio;
    public float wig_stage_ratio;
    public float wig_sprite_ratio;

    void Start()
    {
        player_sp = transform.Find("player_sprite").gameObject;
        wig_sp = transform.Find("wig_sprite").gameObject;
        gameover_zone_sp = transform.Find("gameover_zone_sprite").gameObject;

        player_start_position = player.transform.position.z;
        player_sprite_start_position = player_sp.transform.localPosition.x;
        wig_start_position = wig.transform.position.z;
        wig_sprite_start_position = wig_sp.transform.localPosition.x;
        object_total_mileage = Vector3.Distance(player.transform.position, gameover_zone.transform.position);
        sprite_total_mileage = Vector3.Distance(player_sp.transform.localPosition, gameover_zone_sp.transform.localPosition);

    }
    void Update()
    {
        //プレイヤーがステージを何割歩けているか産出する
        player_stage_ratio = (player.transform.position.z - player_start_position) / object_total_mileage;
        //Debug.Log(player_stage_ratio);
        //
        player_sprite_ratio = player_stage_ratio * sprite_total_mileage;
        //Debug.Log(player_sprite_ratio);
        //
        player_sp.transform.localPosition = new Vector3(player_sprite_ratio + player_sprite_start_position, 0, 0);


        wig_stage_ratio = (wig.transform.position.z - player_start_position) / object_total_mileage;
        //Debug.Log(wig_stage_ratio);
        //
        wig_sprite_ratio = wig_stage_ratio * sprite_total_mileage;
        //Debug.Log(wig_sprite_ratio);
        //
        wig_sp.transform.localPosition = new Vector3(wig_sprite_ratio + player_sprite_start_position, 0, 0);
    }
}
