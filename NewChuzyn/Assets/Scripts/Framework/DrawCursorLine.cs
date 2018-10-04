using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCursorLine : MonoBehaviour {

    [SerializeField]
    private TouchZone m_touchZone;

    /// <summary>カーソルプレハブ</summary>
    [SerializeField]
    private GameObject m_cursorPrefab;

    /// <summary>カーソルオブジェクト</summary>
    private GameObject cursorObject;

    /// <summary>格納用タッチ開始座標</summary>
    private Vector2 m_curentTouchStartPos;

    /// <summary>格納用タッチ開始座標</summary>
    private Vector2 m_currentTouchMovePos;
    /// <summary>描画フラグ</summary>
    private bool drawing;
	
	// Update is called once per frame
	void Update () {
        DrawLine();     
    }

    void DrawLine(){
        //タップ時に描画
        if (m_touchZone.inputstate == TouchZone.InputState.Touch){
            m_curentTouchStartPos = Camera.main.ScreenToWorldPoint(m_touchZone.pressStartPosition);
            //描画されていなければ描画
            if (!drawing){
                cursorObject = Instantiate(m_cursorPrefab, m_curentTouchStartPos, Quaternion.identity);
                drawing = true;
            }
            else{
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float hogetouch = touchPos.x - m_curentTouchStartPos.x;
                Debug.Log("差分"+hogetouch);
            }
        }
        else{
            Destroy(cursorObject);
            drawing = false;
        }
    }
}
