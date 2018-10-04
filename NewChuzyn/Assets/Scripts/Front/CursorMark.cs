using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMark : MonoBehaviour {

    private LineRenderer m_lineRenderer;
    /// <summary>描画始点マーク</summary>
    [SerializeField]
    private GameObject m_startMark;

    /// <summary>終点座標</summary>
    private Vector2 m_endPoint;

    // Use this for initialization
    void Start(){
        m_lineRenderer = GetComponent<LineRenderer>();
    }

	// Update is called once per frame
	void Update () {
        Stroke();
	}

    void Stroke(){
        //描画ラインの始点終点を制御
        m_lineRenderer.SetPosition(0, m_startMark.transform.position);
        m_lineRenderer.SetPosition(1, transform.position);

        CursorEndPoint();
    }

    void CursorEndPoint(){
        //悪い手法
        m_endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = m_endPoint;
    }
}
