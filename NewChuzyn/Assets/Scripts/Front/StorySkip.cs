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
        //ボタン押したときシーンに合わせて次のシーンへ移動
        if (Input.GetMouseButtonDown(0))
        {
            if (m_sceneType == SceneType.Prologe)
            {
                FadeManager.Instance.LoadScene("Stage1", 1f);
            }

            if (m_sceneType == SceneType.Title)
            {
                FadeManager.Instance.LoadScene("Prologue", 1f);
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
}
