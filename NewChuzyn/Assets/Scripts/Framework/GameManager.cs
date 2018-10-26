using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    /// <summary>
    /// ステージのクリア状況保存用
    /// </summary>
    public enum StageState { Stage1,Stage2 }
    public StageState m_stageState;

    /// <summary>ステージクリアフラグ</summary>
    public bool Clearing;

    /// <summary>ステージクリア演出</summary>
    [SerializeField]
    private GameObject[] m_clearEffect;

    private GameObject m_clearObject;


    private void StageClear(){
        if (m_stageState == StageState.Stage1 && Clearing){
            ClearFirst();
        }      
    }

    private void ClearFirst(){
        //クリアしたら表示
        if (Clearing){
            m_clearObject = Instantiate(m_clearEffect[0], Camera.main.transform.position, Quaternion.identity);
            Clearing = false;
        }
    }

    public void NextStage(){
        Debug.Log("次のシーンへ移行する");
    }

    public void BackTitle(){
        Debug.Log("タイトルへ移行する");
    }
    private void Update(){
        StageClear();
    }
}
