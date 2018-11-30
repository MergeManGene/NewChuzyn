using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : IPlayerState {

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



        //落下状態は例外として最優先する
        if(arg_player.colPlayerOBject){
            if (arg_player.colPlayerOBject.tag == "Paipu")
            {
                arg_player.StateTransion(new PlayerFall());
            }
       }

        //入力が無い場合は
        else if (!arg_player.m_touchZone.pressing && !arg_player.m_touchZone.longpressing){
            arg_player.StateTransion(new PlayerIdle());
        }

        //プレスのみの場合は通常移動
        else if (arg_player.m_touchZone.pressing)
        {
            arg_player.StateTransion(new PlayerRun());
        }//入力が何もない場合デフォルト状態
        
    }

    /// <summary>
    /// ステート終了時の処理
    /// </summary>
    /// <param name="arg_player">Argument player.</param>
    public void OnExit(ActorPlayer arg_player){

    }
}
