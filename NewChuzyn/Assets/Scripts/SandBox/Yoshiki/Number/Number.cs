using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour {

    private GameObject m_numOrder;

    [SerializeField]
    private int m_hitNumber;

    private NumberOrder m_order;

    private Animator m_animetor;

    private PolygonCollider2D m_collider;

    public bool hited = false;

    private void Start()
    {
        m_numOrder = transform.parent.transform.gameObject;
        m_order = m_numOrder.GetComponent<NumberOrder>();
        m_animetor = GetComponent<Animator>();
        m_collider = GetComponent<PolygonCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //bool m_hitflg = GetComponent<BoxCollider2D>().IsTouchingLayers(1 << LayerMask.NameToLayer("Player"));
        if (/*m_hitflg &&*/ !hited)
        {
            if (m_hitNumber == m_order.count)
            {
                m_order.Match();
                m_animetor.SetBool("light", true);
                hited = true;
                m_collider.enabled = false;
            }
            else
            {
                m_order.Reset();
            }
        }
    }
}
