using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : IPlayerState
{
    //苦肉の策
    private bool moving = false;

    //スワイプ移動間隔の既定値
    private const int swipeLength = 100;

    /// <summary>
    /// ステート開始時の処理
    /// </summary>
    /// <param name="arg_player">Argument player.</param>
    public void OnEnter(ActorPlayer arg_player)
    {

    }

    /// <summary>
    /// 毎フレーム呼ばれる処理
    /// </summary>
    /// <param name="arg_player">M player.</param>
    public void OnUpdate(ActorPlayer arg_player)
    {

        if (arg_player.m_touchZone.pressing){

            float m_length;
            float m_triggerLength = 2f;

            float longPresslengs;
            longPresslengs = Input.mousePosition.x - arg_player.m_touchZone.pressStartPosition.x;


            Vector2 currentTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 touchStartPos = Camera.main.ScreenToWorldPoint(arg_player.m_touchZone.pressStartPosition);

            m_length = touchStartPos.x - currentTouchPos.x;

            //ここでスピードは書いちゃダメです
            arg_player.m_moveSpeed = 0.1f;

            //一定値その場で長押し状態で射出待機状態
            if (arg_player.m_touchZone.longpressing && longPresslengs < swipeLength && longPresslengs > -swipeLength){
                if (!moving){
                    arg_player.StateTransion(new PlayerShot());
                    Debug.Log("射出");
                }
            }

            //一定値以上スワイプしたら移動開始
            if (m_length < -m_triggerLength){
                arg_player.transform.position += new Vector3(arg_player.m_moveSpeed, 0, 0);
                arg_player.m_direction = ActorBase.Direction.Right;
                moving = true;
            }
            if (m_length > m_triggerLength){
                arg_player.transform.position -= new Vector3(arg_player.m_moveSpeed, 0, 0);
                arg_player.m_direction = ActorBase.Direction.Left;
                moving = true;
            }
        }
       //指を離したら通常に戻る
         else{
            arg_player.StateTransion(new PlayerIdle());
        }
    }
        /// <summary>
        /// ステート終了時に呼ばれる処理
        /// </summary>
        /// <param name="arg_player">M player.</param>
        public void OnExit(ActorPlayer arg_player){

        }
    }


