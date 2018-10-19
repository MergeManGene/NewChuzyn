using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private TouchZone m_touchZone;

    /// <summary>移動速度 </summary>
    public enum PlayerState { Deffault,Move,Shot};
    public PlayerState m_playerState;
    
    /// <summary>移動速度 </summary>
    [SerializeField][Range(0.1f,0.5f)]
    private float m_moveSpeed;

    //移動を開始する値
    [SerializeField][Range(2f,5f)]
    private float m_triggerLength;

    /// <summary>二点の間隔 </summary>
    private float m_length;

    /// <summary>射出待機フラグ </summary>
    private bool ShotStanding;

    private Rigidbody2D m_rigidbody2D;

    private SpriteRenderer m_spriteRenderer;

    private void Start(){
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update () {
        CurrentPlayerAction();
        Debug.Log(m_playerState);
    }

    //各状態のプレイヤーアクション
    private void CurrentPlayerAction(){

        //一定値その場で長押し状態で射出待機状態
        if (m_touchZone.longpressing && Input.mousePosition == m_touchZone.pressStartPosition){
            m_playerState = PlayerState.Shot;
        }//プレスのみの場合は通常移動
        else if (m_touchZone.pressing && !m_touchZone.longpressing){
            m_playerState = PlayerState.Move;
        }//入力が何もない場合デフォルト状態
        else if (!m_touchZone.pressing && !m_touchZone.longpressing){
            m_playerState = PlayerState.Deffault;
        }

        PlayerAction();
    }

    private void PlayerAction()
    {
        //Move状態時のアクション
        if (m_playerState == PlayerState.Move)
        {
            Vector2 currentTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 touchStartPos = Camera.main.ScreenToWorldPoint(m_touchZone.pressStartPosition);

            m_length = touchStartPos.x - currentTouchPos.x;

            //一定値以上スワイプしたら移動開始
            if (m_length < -m_triggerLength){
                transform.position += new Vector3(m_moveSpeed, 0, 0);
                m_spriteRenderer.flipX = false;
            }
            if (m_length > m_triggerLength){
                m_spriteRenderer.flipX = true;
                transform.position -= new Vector3(m_moveSpeed, 0, 0);
            }

            Debug.Log("移動中");
        }
    }
}
