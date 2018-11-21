using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : IPlayerState {

    /// <summary>
    /// ステート開始時の処理
    /// </summary>
    /// <param name="arg_player">Argument player.</param>
    public void OnEnter(ActorPlayer arg_player){

    }

    /// <summary>
    /// 毎フレーム呼ばれる処理
    /// </summary>
    /// <param name="arg_player">Argument player.</param>
    public void OnUpdate(ActorPlayer arg_player){

        float m_length;

        Vector2 currentTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 touchStartPos = Camera.main.ScreenToWorldPoint(arg_player.m_touchZone.pressStartPosition);

        m_length = touchStartPos.x - currentTouchPos.x;

        //ステート検証用
        //タップ時にステート変更　値は適当
        if (arg_player.m_touchZone.pressing){
            arg_player.StateTransion(new PlayerRun());
        }
    
    }

    /// <summary>
    /// ステート終了時の処理
    /// </summary>
    /// <param name="arg_player">Argument player.</param>
    public void OnExit(ActorPlayer arg_player){

    }
}
