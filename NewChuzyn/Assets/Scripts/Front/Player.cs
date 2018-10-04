using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private TouchZone m_touchZone;

    /// <summary>移動速度 </summary>
    [SerializeField][Range(0.01f,0.05f)]
    private float m_moveSpeed;

    //移動を開始する値
    [SerializeField][Range(2f,5f)]
    private float m_triggerLength;

    /// <summary>二点の間隔 </summary>
    private float m_length;

    private Rigidbody2D m_rigidbody2D;

    private SpriteRenderer m_spriteRenderer;

    private void Start(){
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        PlayerMove();
	}

    void PlayerMove(){
        if (m_touchZone.pressing)
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
        }
    }
}
