using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarassGhost : MonoBehaviour {

    private SpriteRenderer m_renderer;

    private AudioSource m_audioSource;

    [SerializeField]
    private Sprite m_sprite;

    /// <summary>
    /// 消滅処理
    /// </summary>
    private IEnumerator Extinction()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_renderer = GetComponent<SpriteRenderer>();
        m_renderer.sprite = m_sprite;
        Color color = m_renderer.color;
        
        m_audioSource.Play();

        while (m_renderer.color.a >= 0)
        {
            
            color.a -= 0.01f;
            m_renderer.color = color;
            yield return null ;

        }

        this.gameObject.SetActive(false);
        yield return null;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "SearchLight")
        {
            StartCoroutine("Extinction");
        }
    }


}
