using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBall : BallBase {

    //現在のステート
    public IBallState m_ballState;

    //危険
    public IPlayer playerObject;

    public override void Init(){
        playerObject = GameObject.Find("Player").GetComponent<IPlayer>();

    }

    public void StateTransion(IBallState arg_nextState){

        if (m_ballState != null) m_ballState.OnExit(this);
        m_ballState = arg_nextState;
        m_ballState.OnEnter(this);
    }
}
