using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearGet : MonoBehaviour {

    private bool GearGetting;

    private bool MessageDrawing;

    private float gearMove;

    [SerializeField]
    private GameObject m_clearText;

	// Update is called once per frame
	void Update () {
        ClearMove();
	}

    /// <summary>
    /// ギア入手時の回転ムーブ（時間がないため完全ごり押し）
    /// </summary>
    private void ClearMove(){
        if (GearGetting){
            transform.Rotate(0, 0, 0.5f);
            
            if (transform.position.y <= -12){
                transform.position += new Vector3(0f, 0.05f, 0);

            }
            else{
                if (!MessageDrawing){
                    transform.localScale = new Vector3(2f, 2f, 0);
                    Instantiate(m_clearText);
                    MessageDrawing = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        GearGetting = true;
    }
}
