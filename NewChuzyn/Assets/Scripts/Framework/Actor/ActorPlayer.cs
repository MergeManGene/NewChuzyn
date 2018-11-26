//スクリプト名：ActorPlayer
//概要：プレイヤー共通のステータスクラス
//別ステートのプレイヤーを実装する際には継承する

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorPlayer : ActorBase
{

    //現在のステート
    public IPlayerState m_currentState;

    //インプット情報
    public TouchZone m_touchZone;

    public override void Init(){
        m_touchZone = GameObject.Find("TouchZone").GetComponent<TouchZone>();  
    }

    /// <summary>
    /// プレイヤーのステートを変更する
    /// </summary>
    /// <param name="arg_nextState">Argument next state.</param>
    public void StateTransion(IPlayerState arg_nextState){
       
        if (m_currentState != null) m_currentState.OnExit(this);

        m_currentState = arg_nextState;
        m_currentState.OnEnter(this);
    }

}
