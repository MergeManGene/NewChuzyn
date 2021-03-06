﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : IPlayerState {


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
        arg_player.transform.position =
                      new Vector2(arg_player.colPlayerOBject.transform.position.x, 
                                  arg_player.transform.position.y);

        //パイプから離れたら通常に戻る
        if (arg_player.ExitCollider)
            arg_player.StateTransion(new PlayerIdle());
    }

    /// <summary>
    /// ステート終了時の処理
    /// </summary>
    /// <param name="arg_player">Argument player.</param>
    public void OnExit(ActorPlayer arg_player){
        arg_player.colPlayerOBject = null;
        arg_player.ExitCollider = false;
    }
}
