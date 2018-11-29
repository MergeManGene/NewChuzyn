using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : IBallState {

    public void OnEnter(ActorBall arg_ball){

    }

    public void OnUpdate(ActorBall arg_ball){

        Vector3 m_startPostion = Camera.main.ScreenToWorldPoint(arg_ball.m_touchZone.pressStartPosition);
        //角度指定
        float zRotation = Mathf.Atan2(arg_ball.m_touchZone.flickEndPosition.y - m_startPostion.y,
                                      arg_ball.m_touchZone.flickEndPosition.x - m_startPostion.x) * Mathf.Rad2Deg;

        //値格納
        float AngleRotation = zRotation;

        //取得した角度反映
        arg_ball.transform.rotation = Quaternion.Euler(0f, 0f, AngleRotation);

        //移動量
        Vector3 angleVec = arg_ball.transform.rotation * new Vector3(20, 0f, 0);

        //向いている方向に向かって移動
        arg_ball.transform.position += angleVec * Time.deltaTime;
    }

    public void OnExit(ActorBall arg_ball){

    }
}