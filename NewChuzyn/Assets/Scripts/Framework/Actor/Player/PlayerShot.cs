using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : IPlayerState {

    /// <summary>
    /// ステート開始時の処理
    /// </summary>
    /// <param name="arg_player"></param>
	public void OnEnter(ActorPlayer arg_player)
    {

    }

    /// <summary>
    /// 毎フレーム呼ばれる処理
    /// </summary>
    /// <param name="arg_player"></param>
    public void OnUpdate(ActorPlayer arg_player)
    {
        if(arg_player.m_touchZone.flicking){
            arg_player.ballObject.StateTransion(new BallShot());
        }
    }

    /// <summary>
    /// ステート終了時の処理
    /// </summary>
    /// <param name="arg_player"></param>
    public void OnExit(ActorPlayer arg_player)
    {

    }
}
