using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour {



    /// <summary>
    /// Menu呼び出し
    /// </summary>
    public void OpenMenu()
    {

    }

    /// <summary>
    /// Menuを閉じる
    /// </summary>
    public void BackToGame()
    {

    }

    /// <summary>
    /// Titleに戻りますか？呼び出し
    /// </summary>
    public void TitleButton()
    {
        
    }

    /// <summary>
    /// Titleに戻らないボタン
    /// </summary>
    public void RetrunToTitle()
    {
        
    }

    /// <summary>
    /// Titleに戻るボタン
    /// </summary>
    public void GoToTitleScene()
    {
        FadeManager.Instance.LoadScene("Title", 0.5f);
    }

    /// <summary>
    /// Manualボタン呼び出し用
    /// </summary>
    public void ManualButton()
    {

    }
    
    /// <summary>
    /// 最初からやり直しボタン
    /// </summary>
    public void ReStartButton()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        FadeManager.Instance.LoadScene(sceneName, 0.5f);

    }


}
