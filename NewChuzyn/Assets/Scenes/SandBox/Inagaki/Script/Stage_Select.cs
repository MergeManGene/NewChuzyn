using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Select : MonoBehaviour {
    public GameObject selectObject;


    
    /// <summary>
    /// TitleBackボタン呼び出し用
    /// </summary>
    public void BackTitle(){
        if(!FadeManager.Instance.isFading)
        FadeManager.Instance.LoadScene("Title", 0.5f);
    }

    public void stg_1(){
        if (!FadeManager.Instance.isFading)
            FadeManager.Instance.LoadScene("Prologue", 1f);
    }
    public void stg_2(){
        if (!FadeManager.Instance.isFading)
            FadeManager.Instance.LoadScene("Story1", 1f);
    }

}
