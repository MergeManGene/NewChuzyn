using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallView : MonoBehaviour {
    private Animator m_animator { get; set; }
    private SpriteRenderer m_spriteRenderer { get; set; }


    public void Init(IBall arg_ball){
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateByFrame(IBall arg_ball){

    }

    //描画に必要処理は以下に記述
}
