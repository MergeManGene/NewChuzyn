using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBack : IBallState {

    public void OnEnter(ActorBall arg_ball){

    }

    public void OnUpdate(ActorBall arg_ball){
        //コライダーオブジェクト格納時
        if (arg_ball.colGameObject)
        {
            switch (arg_ball.colGameObject.tag)
            {
                //地形に当たったら戻ってくる
                case "Ground":
                    arg_ball.transform.position = Vector3.MoveTowards(arg_ball.transform.position, arg_ball.playerObject.transform.position, 0.5f);
                    break;
                //壁に当たったらその座標に移動する
                case "Wall":
                    arg_ball.playerObject.transform.position = Vector3.MoveTowards(arg_ball.playerObject.transform.position, arg_ball.hitPosition, 0.5f);
                    break;
                //モンスターに当たったらくっつけて戻ってくる
                case "Monster":
                case "PassWall":
                    arg_ball.colGameObject.transform.position = arg_ball.transform.position;
                    arg_ball.transform.position = Vector3.MoveTowards(arg_ball.transform.position, arg_ball.playerObject.transform.position, 0.5f);
                    break;
                default:
                    break;
            }
        }//コライダーオブジェクト消失時はそのままプレイヤーの位置へ戻る
        else { arg_ball.transform.position = Vector3.MoveTowards(arg_ball.transform.position, arg_ball.playerObject.transform.position, 0.5f); }

        //プレイヤーの位置まで戻ったら通常時に移行
        if (arg_ball.transform.position == arg_ball.playerObject.transform.position){
            arg_ball.StateTransion(new BallIdle());
        }
            

    }

    public void OnExit(ActorBall arg_ball){

    }
}
