using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendBall : MonoBehaviour {
    public enum ShotState {def,shot,back };
    public ShotState shotState;

    [SerializeField]
    private Player m_player;
    private Vector3 m_playerPositon;
    /// <summary>当たったオブジェクト格納 </summary>
    private GameObject m_colGameObject;

    /// <summary>開始地点 </summary>
    private Vector3 m_startPostion;

    /// <summary>終点 </summary>
    private Vector3 m_endPosition;

    /// <summary>当たった座標 </summary>
    private Vector3 m_hitPositon;

    private float AngleRotation;

    /// <summary>向いている方向ベクトル </summary>
    private Vector3 angleVec;

    private LineRenderer m_lineRenderer;

    [SerializeField]
    private TouchZone m_touchZone;

    private void Start(){
        m_lineRenderer = GetComponent<LineRenderer>();
        shotState = ShotState.def;
    }

    private void Deffault(){

        transform.position = m_player.transform.position;

        if (m_player.m_playerState==Player.PlayerState.Shot)
                shotState = ShotState.shot;
    }

    private void BallShot(){

        if (m_touchZone.flicking){
            Debug.Log("タッチエンド"+m_touchZone.flickEndPosition);

            m_startPostion = Camera.main.ScreenToWorldPoint(m_touchZone.pressStartPosition);
            //角度指定
            float zRotation = Mathf.Atan2(m_touchZone.flickEndPosition.y -m_startPostion.y,
            m_touchZone.flickEndPosition.x - m_startPostion.x) * Mathf.Rad2Deg;

            //値格納
            AngleRotation = zRotation;

            //取得した角度反映
            transform.rotation = Quaternion.Euler(0f, 0f, AngleRotation);

            //移動量
            angleVec = transform.rotation * new Vector3(10f, 0f, 0);

            //向いている方向に向かって移動
            transform.position += angleVec * Time.deltaTime;
        }

        else if (m_player.m_playerState == Player.PlayerState.Deffault)
            shotState = ShotState.def;
    }

    private void BackBall(){
        switch (m_colGameObject.tag)
        {
            case "Wall":
                transform.position = Vector3.MoveTowards(transform.position, m_player.transform.position, 0.5f);
                break;
            default:
                break;
        }
        if (transform.position == m_player.transform.position)
            shotState = ShotState.def;

    }

    private void OnTriggerEnter2D(Collider2D arg_collision){
        m_hitPositon = transform.position;
        switch (arg_collision.tag){
            case "Wall":
                m_colGameObject = arg_collision.gameObject;
                shotState = ShotState.back;
                break;
            default:
                break;
        }          
    }


    // Update is called once per frame
    void Update () {
        m_lineRenderer.SetPosition(0, m_player.transform.position);
        m_lineRenderer.SetPosition(1, transform.position);

        if (shotState == ShotState.def)
            Deffault();
        if (shotState == ShotState.shot)
            BallShot();
        if (shotState == ShotState.back)
            BackBall();
    }
}
