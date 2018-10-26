using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWall : MonoBehaviour {

    /// <summary>タイルマップコライダー</summary>
    private Collider2D m_collider2D;

    private AudioSource m_audioSource;
    /// <summary>
    /// タイルマップコライダーのコンポーネント取得
    /// </summary>
    private void Start(){
        m_collider2D = GetComponent<Collider2D>();
        m_audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D arg_col){
        //幽霊状態のプレイヤーが触れたら通れるようになる
        if (arg_col.collider.tag == "Player"){
            if (GameManager.PlayerFormInstanse == GameManager.PlayerFormState.Ghost){
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
            GameManager.PlayerFormInstanse = GameManager.PlayerFormState.Normal;

            //音邪
            if (!m_audioSource.isPlaying){
                m_audioSource.Play();
            }
        }
    }
}
