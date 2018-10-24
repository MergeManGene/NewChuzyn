using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    /// <summary>スイッチフラグ</summary>
    public bool pushing;

    private SpriteRenderer m_spriteRenderer;

    private void Start(){
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //スイッチ押されたら赤くなる
    private　void PushSwich(){
        pushing = true;
        m_spriteRenderer.color = Color.red;
    }
    private void OnTriggerEnter2D(Collider2D arg_col){
        PushSwich();
    }
}