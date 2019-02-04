using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class UserInput : MonoBehaviour {

    private DatabaseReference userDB;

    private InputField inputAge;
    private InputField inputJob;
    private Dropdown inputSex;

    private Text textAge;
    private Text textJob;
    private Text textSex;

    //データ格納
    private DataSnapshot snapshot;

    //格納データ定義
    private Dictionary<string, object> dataDic;
    private Dictionary<string, object> updDic;

    //格納キー
    private string key;


    // Use this for initialization
    void Start () {
        inputAge = GameObject.Find("AgeInput").GetComponent<InputField>();
        inputJob = GameObject.Find("JobInput").GetComponent<InputField>();
        inputSex = GameObject.Find("SexInput").GetComponent<Dropdown>();

        textAge = GameObject.Find("age").GetComponent<Text>();
        textJob = GameObject.Find("job").GetComponent<Text>();
        textSex = GameObject.Find("sex").GetComponent<Text>();

        //データベースURLを設定
        FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("https://new-chuzyn.firebaseio.com/");
        userDB = FirebaseDatabase.DefaultInstance.GetReference("userdata");

        //ageのノードからtimeで昇順ソートして最大10件を取る（非同期)
        userDB.Child("userid").GetValueAsync().ContinueWith(task =>{
            if(task.IsFaulted){
                Debug.Log("取得失敗");
            }else if(task.IsCompleted){

                snapshot = task.Result;

                dataDic = new Dictionary<string, object>();
                updDic = new Dictionary<string, object>();

                key = userDB.Child("useid").Push().Key;
            }
        });

    }

    public void InputAge(){
        Debug.Log("年齢は" + textAge.text);
    }

    public void InputJob(){
        Debug.Log("職業は" + textJob.text);
    }

    public void InputSex(){
        Debug.Log("性別は" + textSex.text);
    }

    public void DataUpdate(){

        // Debug.Log(key);
        // Debug.Log(snapshot.Child("1").Child("age").GetValue(true));

        dataDic.Add("age", textAge.text);
        dataDic.Add("job", textJob.text);
        dataDic.Add("sex", textSex.text);

        updDic.Add(1 + "/" + key, dataDic);
        userDB.UpdateChildrenAsync(updDic);

        //入力に問題がなければシーン遷移
        FadeManager.Instance.LoadScene("STAGE_SELECT",1f);
    }
}
