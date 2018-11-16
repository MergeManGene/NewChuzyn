// ActorBase
// キャラクター共通のステータスクラス
// キャラ実装時には継承する

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorBase : MonoBehaviour {

    //以下全キャラクター共通ステータス

    public enum Direction{
        Left = -1,
        Right = 1
    }

    //現在のキャラクターの向き
    public Direction m_direction;


    /// <summary>
    /// 初期化関数
    /// </summary>
    public virtual void Init(){

    }

    /// <summary>
    /// フレーム更新用関数
    /// </summary>
    public virtual void UpdateByFrame(){

    }

}
