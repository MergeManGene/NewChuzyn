using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    /// <summary>スイッチフラグ</summary>
    public bool pushing;

    private SpriteRenderer m_spriteRenderer;

    private AudioSource m_audioSource;

    private void Start(){
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_audioSource = GetComponent<AudioSource>();
    }

    //スイッチ押されたら赤くなる
    private　void PushSwich(){
        if (!m_audioSource.isPlaying)
        {
            m_audioSource.Play();
        }

        pushing = true;
        m_spriteRenderer.color = Color.red;
    }
    private void OnTriggerEnter2D(Collider2D arg_col){
        PushSwich();
    }
}