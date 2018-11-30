//スクリプト名：ActorPlayer
//概要：プレイヤー共通のステータスクラス
//別ステートのプレイヤーを実装する際には継承する

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorPlayer : ActorBase
{
    //プレイヤーの形態
    public enum PlayerForm { 
        Normal, 
        Ghost 
    }

    //現在のプレイヤーの形態
    public PlayerForm m_playerForm;

    //現在のステート
    public IPlayerState m_currentState;

    //インプット情報
    [HideInInspector]
    public TouchZone m_touchZone;

    //危険
    [HideInInspector]
    public IBall ballObject;

    /// <summary>プレイヤーと衝突したオブジェクト</summary>
    [HideInInspector]
    public GameObject colPlayerOBject;

    public override void Init(){
        m_touchZone = GameObject.Find("TouchZone").GetComponent<TouchZone>();
        ballObject = GameObject.Find("Ball").GetComponent<IBall>();
    
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

    /// <summary>
    /// プレイヤーが衝突時
    /// </summary>
    /// <param name="arg_col"></param>
    private void OnTriggerEnter2D(Collider2D arg_col){
        if (arg_col.tag == "Monster"){
            //プレイヤーを幽霊状態に移行
            m_playerForm = PlayerForm.Ghost;
        }

        if (arg_col.tag == "Paipu"){
            Debug.Log("パイプ");
            colPlayerOBject = arg_col.gameObject;
        }
    }

}
