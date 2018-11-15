using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOrder : MonoBehaviour {

    [SerializeField]
    private GameObject[] m_objectCount;

    private Number[] m_objectNumber = new Number[5];
    private Animator[] m_objectAnimator = new Animator[5];
    private PolygonCollider2D[] m_objectCollider = new PolygonCollider2D[5];

    private AudioSource m_audioSource;
    [SerializeField]
    private AudioClip m_numClear;

    public int count = 0;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {

        for (int i = 0; i < m_objectCount.Length; i++)
        {
            m_objectNumber[i] = m_objectCount[i].GetComponent<Number>();
            m_objectAnimator[i] = m_objectCount[i].GetComponent<Animator>();
            m_objectCollider[i] = m_objectCount[i].GetComponent<PolygonCollider2D>();
            m_audioSource = GetComponent<AudioSource>();
        }
    }

    public void Match()
    {

        count++;
        if (count == m_objectCount.Length)
        {
            m_audioSource.clip = m_numClear;
            m_audioSource.Play();
        }
    }

    public void Reset()
    {
        if (count != 0)
        {
            count = 0;

            for (int i = 0; i < m_objectCount.Length; i++)
            {
                m_objectNumber[i].hited = false;
                m_objectAnimator[i].SetBool("light", false);
                m_objectCollider[i].enabled = true;

            }

        }
    }

}
