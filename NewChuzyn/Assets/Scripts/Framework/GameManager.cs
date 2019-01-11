using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    /// <summary>
    /// ステージのクリア状況
    /// </summary>
    public enum StageState { Stage1,Stage2 }
    public StageState stageState;
    
    /// <summary>
    /// プレイヤーの形態状況
    /// </summary>
    public enum PlayerFormState { Normal,Ghost};
    public static PlayerFormState PlayerFormInstanse;

    private AudioSource m_bgm;

    [SerializeField]
    private AudioClip m_clearBgm;


    /// <summary>ステージクリアフラグ</summary>
    public bool Clearing;

    /// <summary>ステージクリア演出</summary>
    [SerializeField]
    private GameObject[] m_clearEffect;

    private GameObject m_clearObject;
    
    private GameObject m_flash;

    private void Start()
    {
        m_bgm = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        m_flash = GameObject.Find("FlashLayer");
    }


    private void StageClear(){
        if (stageState == StageState.Stage1 && Clearing){
            ClearFirst();
        }      
    }

    private void ClearFirst(){
        //クリアしたら表示
        if (Clearing){
            m_bgm.clip = m_clearBgm;
            m_bgm.Play();
            if(m_flash != null)m_flash.SetActive(false);

            m_clearObject = Instantiate(m_clearEffect[0], Camera.main.transform.position, Quaternion.identity);
            Clearing = false;
        }
    }

    /// <summary>
    /// NextStageボタン呼び出し用
    /// </summary>
    public void NextStage(){
        if (stageState == StageState.Stage1){
            FadeManager.Instance.LoadScene("Story1",1f);
            stageState = StageState.Stage2;
        }
    }
    /// <summary>
    /// TitleBackボタン呼び出し用
    /// </summary>
    public void BackTitle(){
        FadeManager.Instance.LoadScene("Title", 0.5f);
    }

    /// <summary>
    /// TitleBackボタン呼び出し用
    /// </summary>
    public void Ending(){
        FadeManager.Instance.LoadScene("Ending", 1f);
    }
    private void Update(){
        StageClear();
    }
}
