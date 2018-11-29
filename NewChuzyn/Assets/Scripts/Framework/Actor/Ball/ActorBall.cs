using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBall : BallBase {

    //現在のステート
    public IBallState m_ballState;

    //危険
    public IPlayer playerObject;

    //Player側でも参照している
    public TouchZone m_touchZone;

    //衝突座標
    public Vector3 hitPosition;



    //衝突したゲームオブジェクト
    [HideInInspector]
    public GameObject colGameObject;

    public override void Init(){
        playerObject = GameObject.Find("Player").GetComponent<IPlayer>();
        m_touchZone = GameObject.Find("TouchZone").GetComponent<TouchZone>();
    }

    //ボールのステート遷移
    public void StateTransion(IBallState arg_nextState){

        if (m_ballState != null) m_ballState.OnExit(this);
        m_ballState = arg_nextState;
        m_ballState.OnEnter(this);
    }

    //衝突したオブジェクト格納　衝突時のステート変更もまとめてここで
    private void OnTriggerEnter2D(Collider2D arg_col)
    {
        hitPosition = transform.position;
        switch(arg_col.tag){
            case "Ground":
            case "Wall":
            case "Monster":
            case "PassWall":
                colGameObject = arg_col.gameObject;
                this.StateTransion(new BallBack());
                break;
            default:
                break;
        }
    }


}
