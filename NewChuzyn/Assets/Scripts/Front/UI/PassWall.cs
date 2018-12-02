using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWall : MonoBehaviour {

    /// <summary>タイルマップコライダー</summary>
    private Collider2D m_collider2D;

    private AudioSource m_audioSource;

    private IPlayer m_player;
    /// <summary>
    /// タイルマップコライダーのコンポーネント取得
    /// </summary>
    private void Start(){
        m_collider2D = GetComponent<Collider2D>();
        m_audioSource = GetComponent<AudioSource>();
        m_player = GameObject.Find("Player").GetComponent<IPlayer>();
    }

    private void OnCollisionEnter2D(Collision2D arg_col){
        //幽霊状態のプレイヤーが触れたら通れるようになる
        if (arg_col.collider.tag == "Player"){
            if (m_player.m_playerForm == IPlayer.PlayerForm.Ghost){
                m_collider2D.isTrigger = true;
            }           
        }
    }

    /// <summary>
    /// プレイヤーが離れた際に通常形態へ戻す
    /// </summary>
    /// <param name="arg_col"></param>
    private void OnTriggerExit2D(Collider2D arg_col){
        if (m_collider2D.isTrigger){
            m_collider2D.isTrigger = false;
            m_player.m_playerForm = IPlayer.PlayerForm.Normal;
            //音邪
            if (!m_audioSource.isPlaying){
                m_audioSource.Play();
            }
        }
    }
}
