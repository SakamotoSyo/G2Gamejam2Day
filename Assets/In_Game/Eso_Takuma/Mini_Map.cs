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

        player_start_position = player.transform.position.z;//�v���C���[�̊J�n�ʒu���擾
        player_sprite_start_position = player_sp.transform.localPosition.x;//�v���C���[�̉摜�̊J�n�ʒu���擾
        wig_start_position = wig.transform.position.z;//����̊J�n�ʒu���擾
        wig_sprite_start_position = wig_sp.transform.localPosition.x;//����̉摜�̊J�n�ʒu���擾
        object_total_mileage = Vector3.Distance(player.transform.position, gameover_zone.transform.position);
        sprite_total_mileage = Vector3.Distance(player_sp.transform.localPosition, gameover_zone_sp.transform.localPosition);

    }
    void Update()
    {
        //�v���C���[���X�e�[�W�����������Ă��邩�Z�o����
        player_stage_ratio = (player.transform.position.z - player_start_position) / object_total_mileage;
        Debug.Log(player.transform.position.z+"  "+player_start_position+"  "+object_total_mileage);

        //�v���C���[�̉摜���ǂꂾ���i��ł��邩�Z�o����
        player_sprite_ratio = player_stage_ratio * sprite_total_mileage;
        //�v���C���[�̉摜�̐i�ޗʂ��v�Z����
        player_sp.transform.localPosition = new Vector3(player_sprite_ratio + player_sprite_start_position, 0, 0);
        //Debug.Log(player_sprite_start_position + "  " + player_sprite_ratio);

        wig_stage_ratio = (wig.transform.position.z - player_start_position) / object_total_mileage;
        Debug.Log(wig.transform.position.z +"  "+ wig_start_position +"  "+ object_total_mileage);
        //
        wig_sprite_ratio = wig_stage_ratio * sprite_total_mileage;
        //
        wig_sp.transform.localPosition = new Vector3(wig_sprite_ratio + wig_sprite_start_position, 0, 0);
        //Debug.Log(wig_sprite_start_position + "  " + wig_sprite_ratio);
    }
}
