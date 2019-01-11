using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySkip : MonoBehaviour
{

    public enum SceneType { Title, Prologe,Story1,Ending }
    public SceneType m_sceneType; 
    
    // Update is called once per frame
    void Update()
    {
        //フェードしてない時は入力可能
        if (!FadeManager.Instance.isFading)
        {

            // エディタの場合の処理     
            //ボタン押したときシーンに合わせて次のシーンへ移動
            if (Application.isEditor)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    AudioSource m_audioSource = GetComponent<AudioSource>();
                    m_audioSource.Play();
                    InputSceneAction();
                }
            }
            else
            {
                // エディタ以外の場合
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        InputSceneAction();
                    }
                }
            }
        }
    }

    private void InputSceneAction(){


        if (m_sceneType == SceneType.Prologe)
        {
            FadeManager.Instance.LoadScene("Stage1", 1f);
        }

        if (m_sceneType == SceneType.Title)
        {
            FadeManager.Instance.LoadScene("STAGE_SELECT", 1f);
        }

        if (m_sceneType == SceneType.Story1)
        {
            FadeManager.Instance.LoadScene("Stage2", 1f);
        }

        if (m_sceneType == SceneType.Ending)
        {
            FadeManager.Instance.LoadScene("Title", 1f);
        }
    }
}


