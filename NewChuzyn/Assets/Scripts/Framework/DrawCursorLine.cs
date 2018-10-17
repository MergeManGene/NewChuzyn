using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCursorLine : MonoBehaviour {

    [SerializeField]
    private TouchZone m_touchZone;

    [SerializeField]
    private Player m_player;

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
        m_curentTouchStartPos = Camera.main.ScreenToWorldPoint(m_touchZone.pressStartPosition);
        DrawCursor();  
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
}
