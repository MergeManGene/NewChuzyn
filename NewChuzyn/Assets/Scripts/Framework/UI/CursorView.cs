using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorView : MonoBehaviour {

    private LineRenderer m_lineRenderer;

    [SerializeField]
    private IPlayer m_player;

    /// <summary>描画始点マーク</summary>
    [SerializeField]
    private GameObject m_startMark;

    /// <summary>終点座標</summary>
    private Vector2 m_endPoint;

    private SpriteRenderer m_SpriteRenderer;

    // Use this for initialization
    void Start(){
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_lineRenderer = GetComponent<LineRenderer>();

        //HierarchyからPlayerを探してコンポーネント取得
        if (!m_player)
        {
            //プレイヤーが存在する時のみ取得
            if (GameObject.Find("Player")){
                m_player = GameObject.Find("Player").GetComponent<IPlayer>();
            }
        }
    }

    private void Update(){
        UpdateByFrame();
    }

    // Update is called once per frame
    void UpdateByFrame(){       
        //プレイヤーが参照できてれば(ゴリおし)
        if (m_player){
            if (m_player.m_currentState.GetType()==typeof(PlayerRun)){
                Stroke();
            }
            if (m_player.m_currentState.GetType() == typeof(PlayerShot)){
                DrawLongPress();
            }
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
