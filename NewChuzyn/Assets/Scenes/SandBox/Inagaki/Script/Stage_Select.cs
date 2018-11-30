using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Select : MonoBehaviour {
    public GameObject selectObject;


    
    /// <summary>
    /// TitleBackボタン呼び出し用
    /// </summary>
    public void BackTitle(){
        FadeManager.Instance.LoadScene("Title", 0.5f);
    }

    public void stg_1(){
        FadeManager.Instance.LoadScene("Stage1", 1f);
    }
    public void stg_2()
    {
        FadeManager.Instance.LoadScene("Stage2", 1f);
    }

}
