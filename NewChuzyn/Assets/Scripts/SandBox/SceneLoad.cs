using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;


public class SceneLoad : MonoBehaviour
{

    private DatabaseReference userDB;

    private Text text;

    // Use this for initialization
    private void Start(){

        text = GetComponent<Text>();

        //データベースURLを設定
        FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("https://new-chuzyn.firebaseio.com/");
        userDB = FirebaseDatabase.DefaultInstance.GetReference("userdata");

        //ageのノードからtimeで昇順ソートして最大10件を取る（非同期)
        userDB.Child("userid").GetValueAsync().ContinueWith(task =>
        {
            //取得失敗時
            if (task.IsFaulted)
            {
                Debug.Log("取得失敗");
            }//取得成功
            else if (task.IsCompleted){
                text.text = "読み込み成功";

                FadeManager.Instance.LoadScene("webui", 1f);
            }
        });
    }

}
