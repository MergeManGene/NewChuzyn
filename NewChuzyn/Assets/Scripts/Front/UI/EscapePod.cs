using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePod : MonoBehaviour {

    private Animator m_animator;

    /// <summary>当たったオブジェクト</summary>
    private GameObject m_colObject;

    private bool Moving;

    private Rigidbody2D m_rigidbody2D;

    private Vector3 m_movePower;

	// Use this for initialization
	void Start () {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_movePower = new Vector3(0, 5f, 0);
	}

    //プレイヤーと衝突したときアニメーション開始
    private void OnTriggerEnter2D(Collider2D arg_col){
        
        if (arg_col.tag == "Player"){
            m_colObject = arg_col.gameObject;
            Escape();
        }
    }

    //プレイヤーを非表示にして上へ上昇
    private void Escape(){
        m_animator.Play("Move");
        m_colObject.SetActive(false);
        Moving = true;
    }

    //上へ上昇
   private void MovePod(){
        m_rigidbody2D.AddForce(m_movePower, ForceMode2D.Force);
    }

    private void Update(){
        if (Moving) MovePod();        
    }
}
