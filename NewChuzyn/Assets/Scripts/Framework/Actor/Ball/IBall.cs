using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBall : ActorBall {

    //Viewオブジェクトインスタンス
    private BallView m_view { get; set; }

    //危険
    protected IPlayer m_player;

    public override void Init(){
        base.Init();

        m_view = GetComponent<BallView>();

        m_view.Init(this);
        this.StateTransion(new BallIdle());
    }

    public override void UpdateByFrame(){
        m_ballState.OnUpdate(this);

        View();
    }

    /// <summary>
    /// 描画処理
    /// </summary>
    private void View(){

    }

    private void Start(){
        Init();
    }

    private void Update()
    {
        UpdateByFrame();
    }
}
