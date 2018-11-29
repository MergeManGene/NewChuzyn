using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallView : MonoBehaviour {
    private Animator m_animator { get; set; }
    private SpriteRenderer m_spriteRenderer { get; set; }

    private IPlayer m_player { get; set; }

    public void Init(IBall arg_ball){
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_player = arg_ball.playerObject;
    }

    public void UpdateByFrame(IBall arg_ball){

        //プレイヤーが非アクティブ時にはボールも非表示
        if (!m_player.gameObject.activeSelf)
        {
            arg_ball.gameObject.SetActive(false);
        }
    }

    //描画に必要処理は以下に記述
}
