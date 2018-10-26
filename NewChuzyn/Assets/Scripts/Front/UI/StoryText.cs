using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryText : MonoBehaviour {

    RectTransform m_rect;


    private void Start()
    {
        m_rect = GetComponent<RectTransform>();
    }
    private void TextMove(){
        m_rect.localPosition += new Vector3(0, 1f, 0);
    }
	// Update is called once per frame
	void Update () {
        TextMove();
	}
}
