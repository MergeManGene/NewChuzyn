using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedFlash : MonoBehaviour {

    /// <summary> イメージ </summary>
    private Image m_image;
    /// <summary> 透明な赤 </summary>
    private Color m_clearRed;
    /// <summary> 透明色 </summary>
    private Color m_clear;
    /// <summary> カラー遷移フラグ </summary>
    private bool m_colorChanging;

    // Use this for initialization
    void Start () {
        m_image = GetComponent<Image>();
        
        //透明な赤い色
        m_clearRed = new Color(1.0f, 0, 0, 0.4f);

        //カラー遷移用の透明色
        m_clear = new Color(1.0f, 0, 0, 0);

        //初期値を透明な赤い色に指定
        m_image.color = m_clearRed;
    }

    private void Update()
    {
        //赤⇒透明
        if (m_image.color == m_clearRed){
            m_colorChanging = true;
        }
        //透明⇒赤
        else if (m_image.color == m_clear){
            m_colorChanging = false;
        }

        ColorChange();
    }

    private void ColorChange(){
        if (m_colorChanging){
            //赤い色から透明になる
            m_image.color = Color.Lerp(m_image.color, m_clear, Time.deltaTime);
        }else{
            //透明から赤い色になる
            m_image.color = Color.Lerp(m_image.color, m_clearRed, Time.deltaTime);
        }
    }
}
