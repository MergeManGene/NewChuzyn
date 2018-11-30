using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paipu : MonoBehaviour {

    private GameObject m_colGameObject;
    private Vector3 m_colPosition;

    private Animator m_playerAnimator;

    private AudioSource m_audioSource;

    private void Start(){
        m_audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionStay2D(Collision2D arg_col){
        if (arg_col.collider.tag == "Player"){
            m_colGameObject = arg_col.gameObject;

            m_playerAnimator = m_colGameObject.GetComponent<Animator>();
            m_playerAnimator.Play("PlayerFall");
            m_colGameObject.transform.position = new Vector2(transform.position.x, m_colGameObject.transform.position.y);

            if (!m_audioSource.isPlaying)
                m_audioSource.Play();
        }
            
    }
}
