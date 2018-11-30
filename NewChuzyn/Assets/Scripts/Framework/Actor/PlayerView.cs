using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour {

    private Animator m_animator { get; set; }
    private SpriteRenderer m_spriteRenderer { get; set; }

    private IPlayer m_player { get; set; }

    public void Init(IPlayer arg_player){
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_player = GetComponent<IPlayer>();
    }

    public void UpdateByFrame(IPlayer arg_player){
        ViewDirection(arg_player.m_direction);
        ViewStateAnimation(arg_player.m_currentState);
    }

    /// <summary>
    /// Flip描画処理
    /// </summary>
    private void ViewDirection(ActorBase.Direction arg_direction){
        switch(arg_direction){
            case ActorBase.Direction.Left:
                m_spriteRenderer.flipX = true;
                break;
            case ActorBase.Direction.Right:
                m_spriteRenderer.flipX = false;
                break;
        }
    }

    /// <summary>
    /// ステートに応じたアニメーション描画
    /// </summary>
    /// <param name="arg_playerState">Argument player state.</param>
    private void ViewStateAnimation(IPlayerState arg_playerState)
    {

        switch (m_player.m_playerForm)
        {
            //通常形態アニメーション
            case IPlayer.PlayerForm.Normal:

        if (arg_playerState.GetType() == typeof(PlayerIdle)){
            m_animator.Play("Player");
        }else if (arg_playerState.GetType() == typeof(PlayerRun)){
            m_animator.Play("PlayerMove");
        }break;

            //幽霊状態アニメーション
            case IPlayer.PlayerForm.Ghost:
                if (arg_playerState.GetType() == typeof(PlayerIdle)){
                    m_animator.Play("PlayerGhost");
                }else if (arg_playerState.GetType() == typeof(PlayerRun)){
                    m_animator.Play("PlayerGhostMove");
                }break;
            
            default:
                break;
        }
    }
}
