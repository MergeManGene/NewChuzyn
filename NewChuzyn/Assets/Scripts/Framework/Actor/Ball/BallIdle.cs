using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallIdle : IBallState {

    /// <summary>
    /// ステート開始時に呼ばれる処理
    /// </summary>
    /// <param name="arg_ball">Argument player.</param>
    public void OnEnter(ActorBall arg_ball){

    }

    /// <summary>
    /// 毎フレーム呼ばれる処理
    /// </summary>
    /// <param name="arg_ball">Argument player.</param>
    public void OnUpdate(ActorBall arg_ball){
        arg_ball.transform.position = arg_ball.playerObject.transform.position;
    }


    /// <summary>
    /// ステート終了時に呼ばれる処理
    /// </summary>
    /// <param name="arg_ball">Argument player.</param>
    public void OnExit(ActorBall arg_ball){

    }
}
