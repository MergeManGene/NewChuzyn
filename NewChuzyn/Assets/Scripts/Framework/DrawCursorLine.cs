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

    /// <summary>カメラ座標</summary>
    private Vector3 m_cameraStartPos;

    /// <summary>描画フラグ</summary>
    private bool drawing;

    private void Start(){
        m_cameraStartPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update () {
        m_curentTouchStartPos = Camera.main.ScreenToWorldPoint(m_touchZone.pressStartPosition);
        DrawCursor();

        //カメラ座標更新時にマーカー再描画
        if(m_cameraStartPos!=Camera.main.transform.position){
            DrawUpdate();
        }
    }

    
    private void DrawLine(){
        cursorObject = Instantiate(m_cursorPrefab, m_curentTouchStartPos, Quaternion.identity);
    }
    private void DrawCursor(){
        //タップ時に描画
        if (m_touchZone.inputstate == TouchZone.InputState.Touch){
            
            //描画されていなければ描画
            if (!drawing){
                DrawLine();
                drawing = true;
            }
        }
        else{
            Destroy(cursorObject);
            drawing = false;
        }
    }

    /// <summary>
    /// カメラ座標が動いた時呼び出し
    /// カメラ初期座標を更新してマーカーを再描画
    /// </summary>
    private void DrawUpdate()
    {
        if (cursorObject)
        {
            cursorObject.transform.position = m_curentTouchStartPos;
            m_cameraStartPos = Camera.main.transform.position;
        }
    }
}
