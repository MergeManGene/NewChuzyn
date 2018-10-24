using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftBall : MonoBehaviour {

    [SerializeField]
    private GameObject m_endMarker;

    private float m_liftSpeed = 0.05f;

    [SerializeField]
    private Switch m_switch;

    //リフトのボールを動かすだけ
    private void LiftMove(){
        if(m_switch.pushing)
        transform.position = Vector3.Lerp(transform.position, m_endMarker.transform.position, 0.05f);
    }
	
	// Update is called once per frame
	void Update () {
        LiftMove();
	}
}
