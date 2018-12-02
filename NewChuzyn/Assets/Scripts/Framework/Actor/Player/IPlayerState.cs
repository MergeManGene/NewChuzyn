using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState  {

    /// <summary>
    /// ステート開始時に呼ばれる処理
    /// </summary>
    /// <param name="arg_player">Argument player.</param>
    void OnEnter(ActorPlayer arg_player);

    /// <summary>
    /// 毎フレーム呼ばれる処理
    /// </summary>
    /// <param name="arg_player">Argument player.</param>
    void OnUpdate(ActorPlayer arg_player);


    /// <summary>
    /// ステート終了時に呼ばれる処理
    /// </summary>
    /// <param name="arg_player">Argument player.</param>
    void OnExit(ActorPlayer arg_player);
}
