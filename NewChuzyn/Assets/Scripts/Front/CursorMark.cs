using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMark : MonoBehaviour {

    private LineRenderer m_lineRenderer;

    [SerializeField]
    private Player m_player;

    private GameObject m_playerObject;

    /// <summary>描画始点マーク</summary>
    [SerializeField]
    private GameObject m_startMark;

    /// <summary>終点座標</summary>
    private Vector2 m_endPoint;

    private SpriteRenderer m_SpriteRenderer;

    // Use this for initialization
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_lineRenderer = GetComponent<LineRenderer>();

        //HierarchyからPlayerを探してコンポーネント取得
        if (!m_player){
            m_playerObject = GameObject.Find("Player");
            m_player = m_playerObject.GetComponent<Player>();
        }
    }

	// Update is called once per frame
	void Update () {
        if (m_player.m_playerState == Player.PlayerState.Move)
        {
            Stroke();
            Debug.Log("Move時はストローク描画");
        }

        if (m_player.m_playerState == Player.PlayerState.Shot){
            DrawLongPress();
            Debug.Log("ショット時は長押し描画");
        }
    }

   private void Stroke(){
        //描画ラインの始点終点を制御
        m_lineRenderer.SetPosition(0, m_startMark.transform.position);
        m_lineRenderer.SetPosition(1, transform.position);

        CursorEndPoint();
    }

    private void CursorEndPoint(){
        //悪い手法
        m_endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = m_endPoint;
    }

    private void DrawLongPress(){
        m_SpriteRenderer.color = Color.blue;
    }
}
