using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer : ActorPlayer {

    private PlayerView m_view { get; set; }

    public override void Init(){
        base.Init();

        m_view = GetComponent<PlayerView>();
        m_view.Init(this);

        this.StateTransion(new PlayerIdle());
    }

    public override void UpdateByFrame(){
        m_currentState.OnUpdate(this);

        //追記：Stateクラスで全ての状態遷移を管理するため削除
        //入力がなければ通常状態に以降
       // if (!m_touchZone.pressing) m_currentState = new PlayerIdle();

        //描画処理
        View();
    }

    /// <summary>
    /// 描画処理
    /// </summary>
    private void View(){
        m_view.UpdateByFrame(this);
    }

    /// <summary>
    /// 開始処理(controller)
    /// </summary>
    private void Start(){
        Init();
    }

    /// <summary>
    /// 毎フレーム処理(controller)
    /// </summary>
    private void Update(){
        UpdateByFrame();
        Debug.Log(m_currentState);
    }
} 
