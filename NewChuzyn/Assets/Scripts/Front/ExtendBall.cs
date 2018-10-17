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

    /// <summary>フックボールの移動速度 </summary>
    [SerializeField]
    private float m_ballSpeed;

    /// <summary>反映角度 </summary>
    private float AngleRotation;

    /// <summary>向いている方向ベクトル </summary>
    private Vector3 angleVec;

    private LineRenderer m_lineRenderer;

    [SerializeField]
    private TouchZone m_touchZone;

    private void Start(){
        m_lineRenderer = GetComponent<LineRenderer>();
        
        //開始時はデフォルト状態
        shotState = ShotState.def;
    }

    private void Deffault(){

        transform.position = m_player.transform.position;

        //プレイヤーが射出待機状態の時射出可能
        if (m_player.m_playerState==Player.PlayerState.Shot)
                shotState = ShotState.shot;
    }

    private void BallShot(){

        //フリックされたら射出
        if (m_touchZone.flicking){

            m_startPostion = Camera.main.ScreenToWorldPoint(m_touchZone.pressStartPosition);
            //角度指定
            float zRotation = Mathf.Atan2(m_touchZone.flickEndPosition.y -m_startPostion.y,
            m_touchZone.flickEndPosition.x - m_startPostion.x) * Mathf.Rad2Deg;

            //値格納
            AngleRotation = zRotation;

            //取得した角度反映
            transform.rotation = Quaternion.Euler(0f, 0f, AngleRotation);

            //移動量
            angleVec = transform.rotation * new Vector3(m_ballSpeed, 0f, 0);

            //向いている方向に向かって移動
            transform.position += angleVec * Time.deltaTime;
        }


        else if (m_player.m_playerState == Player.PlayerState.Deffault)
            shotState = ShotState.def;
    }

    private void BackBall(){
        switch (m_colGameObject.tag)
        {
            //地形に当たったら戻ってくる
            case "Ground":
                transform.position = Vector3.MoveTowards(transform.position, m_player.transform.position, 0.5f);
                break;
            //壁に当たったらその座標に移動する
            case "Wall":
                m_player.transform.position = Vector3.MoveTowards(m_player.transform.position, m_hitPositon, 0.5f);
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
            case "Ground":
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
