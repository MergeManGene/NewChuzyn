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

    /// <summary>
    /// 縦移動もしくは横移動
    /// デフォは横
    /// </summary>
    [SerializeField]
    private bool m_sideMove = true;

    private Vector2 m_position;

    private Rigidbody2D m_rigidbody2d;

	private void Start () {
        m_rigidbody2d = GetComponent<Rigidbody2D>();

        if (m_sideMove)
        {
            StartCoroutine("MoveSide");
        }
        else
        {
            StartCoroutine("MoveVertical");
        }
        
        m_position = transform.position;
	}
	
	private void Update () {
        
	}

    private IEnumerator MoveSide()
    {
        
        while (true)
        {

            if (m_position.x + m_distance < transform.position.x)
            {
                m_rigidbody2d.velocity += (Vector2.left * m_speed);

            }
            else if (m_position.x + m_distance > transform.position.x) 
            {
                m_rigidbody2d.velocity -= (Vector2.left * m_speed);
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator MoveVertical()
    {

        while (true)
        {

            if (m_position.y + m_distance < transform.position.y)
            {
                m_rigidbody2d.velocity += (Vector2.down * m_speed);

            }
            else if (m_position.y + m_distance > transform.position.y)
            {
                m_rigidbody2d.velocity -= (Vector2.down * m_speed);
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D arg_col){
        if (arg_col.tag == "Player"){
            Destroy(this.gameObject);
        }
    }
}
