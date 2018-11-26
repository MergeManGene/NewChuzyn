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


    public override void Init(){
        playerObject = GameObject.Find("Player").GetComponent<IPlayer>();
        m_touchZone = GameObject.Find("TouchZone").GetComponent<TouchZone>();
    }

    public void StateTransion(IBallState arg_nextState){

        if (m_ballState != null) m_ballState.OnExit(this);
        m_ballState = arg_nextState;
        m_ballState.OnEnter(this);
    }
}
