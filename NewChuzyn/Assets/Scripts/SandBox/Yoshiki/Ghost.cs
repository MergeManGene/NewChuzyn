using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    /// <summary>
    /// 移動距離
    /// </summary>
    [SerializeField]
    private float m_distance;

    /// <summary>
    /// スピード
    /// </summary>
    [SerializeField]
    private float m_speed;

    private Rigidbody2D m_rigidbody2d;

	private void Start () {
        m_rigidbody2d = GetComponent<Rigidbody2D>();
        StartCoroutine("Move");
	}
	
	private void Update () {
        
	}

    private IEnumerator Move()
    {
        int count = 0;
        
        while (true)
        {
            if (count > 5)
            {
                m_rigidbody2d.velocity += (Vector2.left * m_speed) * Time.fixedDeltaTime;
                
            }
            else
            {
                m_rigidbody2d.velocity -= (Vector2.left * m_speed) * Time.fixedDeltaTime;
            }

            count++;

            if (count > 10) 
            {
                count = 1;
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
