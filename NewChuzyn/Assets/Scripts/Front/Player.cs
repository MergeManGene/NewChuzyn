using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private TouchZone m_touchZone;

    /// <summary>移動速度 </summary>
    public enum PlayerState { Deffault, Move, Shot };
    public PlayerState m_playerState;

    /// <summary>移動速度 </summary>
    [SerializeField]
    [Range(0.01f, 0.05f)]
    private float m_moveSpeed;

    //移動を開始する値
    [SerializeField]
    [Range(2f, 5f)]
    private float m_triggerLength;

    /// <summary>二点の間隔 </summary>
    private float m_length;

    private Rigidbody2D m_rigidbody2D;

    private SpriteRenderer m_spriteRenderer;

    private Animator m_animator;

    private AnimatorClipInfo m_animClip;

    private AudioSource m_audioSource;

    private float longPresslengs;

    [SerializeField]
    private AudioClip m_ghostSE;
    [SerializeField]
    private AudioClip m_playerWalk;

    private void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {

        CurrentPlayerAction();
        Debug.Log(m_playerState);
    }

    /// <summary>
    /// 各状態のプレイヤーアクション
    /// </summary>
    private void CurrentPlayerAction()
    {

        //現在再生されてるアニメーション取得
        m_animClip = m_animator.GetCurrentAnimatorClipInfo(0)[0];

        longPresslengs = Input.mousePosition.x - m_touchZone.pressStartPosition.x;
        //一定値その場で長押し状態で射出待機状態
        if (m_touchZone.longpressing && longPresslengs < 100 && longPresslengs > -100)
        {
            Debug.Log(longPresslengs);
            m_playerState = PlayerState.Shot;
        }
        //プレスのみの場合は通常移動
        else if (m_touchZone.pressing && !m_touchZone.longpressing)
        {
            m_playerState = PlayerState.Move;

        }//入力が何もない場合デフォルト状態
        else if (!m_touchZone.pressing && !m_touchZone.longpressing)
        {
            m_playerState = PlayerState.Deffault;
        }
        PlayerAction();
    }

    private void PlayerAction()
    {
        //アニメーション開始
        PlayerAnimation();

        //Move状態時のアクション
        if (m_playerState == PlayerState.Move)
        {
            m_audioSource.clip = m_playerWalk;

            if (!m_audioSource.isPlaying)
            {
                m_audioSource.Play();
            }

            Vector2 currentTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 touchStartPos = Camera.main.ScreenToWorldPoint(m_touchZone.pressStartPosition);

            m_length = touchStartPos.x - currentTouchPos.x;

            //一定値以上スワイプしたら移動開始
            if (m_length < -m_triggerLength)
            {
                transform.position += new Vector3(m_moveSpeed, 0, 0);
                m_spriteRenderer.flipX = false;
            }
            if (m_length > m_triggerLength)
            {
                m_spriteRenderer.flipX = true;
                transform.position -= new Vector3(m_moveSpeed, 0, 0);
            }
        }

        if (m_playerState == PlayerState.Deffault)
        {
            //歩く音が流れてたら停止
            if (m_audioSource.clip == m_playerWalk)
            {
                m_audioSource.Stop();
            }
        }
    }

    /// <summary>
    /// アニメーション再生
    /// </summary>
    private void PlayerAnimation()
    {

        //プレイヤーがノーマル状態
        if (GameManager.PlayerFormInstanse == GameManager.PlayerFormState.Normal)
        {
            //Move状態時のアニメーション
            if (m_playerState == PlayerState.Move)
            {
                m_animator.Play("PlayerMove");
            }

            if (m_playerState == PlayerState.Deffault)
            {
                //プレイヤーが下降中でなければ通常アニメーション
                if (m_animClip.clip.name != "PlayerBack")
                {
                    m_animator.Play("Player");
                }
            }
        }

        //プレイヤーが幽霊状態時のアニメーション
        if (GameManager.PlayerFormInstanse == GameManager.PlayerFormState.Ghost)
        {
            if (m_playerState == PlayerState.Deffault)
            {
                m_animator.Play("PlayerGhost");
            }
            //Move状態時のアニメーション
            if (m_playerState == PlayerState.Move)
            {
                m_animator.Play("PlayerGhostMove");
            }
        }
    }
    /// <summary>
    /// プレイヤーが衝突時
    /// </summary>
    /// <param name="arg_col"></param>
    private void OnTriggerEnter2D(Collider2D arg_col)
    {
        if (arg_col.tag == "Monster")
        {
            m_audioSource.clip = m_ghostSE;
            m_audioSource.Play();

            //プレイヤーを幽霊状態に移行
            GameManager.PlayerFormInstanse = GameManager.PlayerFormState.Ghost;
        }
    }
}
