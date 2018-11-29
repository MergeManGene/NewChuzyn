using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour {

    //以下オブジェクトの共通ステータス

    //スピード
    public float m_ballSpeed;

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
