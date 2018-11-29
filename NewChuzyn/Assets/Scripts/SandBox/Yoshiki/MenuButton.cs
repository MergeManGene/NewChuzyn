using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

    /// <summary>メニューフラグ</summary>
    public bool m_menuFlg = false;

    /// <summary>入れもの</summary>
    [SerializeField]
    private GameObject m_menuPrefab;

    /// <summary>入れもの</summary>
    private GameObject m_menuObject;


    /// <summary>
    /// Menuボタン呼び出し用
    /// </summary>
    public void Menu()
    {
        if (!m_menuFlg)
        {
            m_menuFlg = true;
            Instantiate(m_menuPrefab, Camera.main.transform.position, Quaternion.identity);
        }
    }


}
