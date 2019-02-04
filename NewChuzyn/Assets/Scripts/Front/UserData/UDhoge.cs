using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class UDhoge : MonoBehaviour {

    private DatabaseReference userDB;

    // Use this for initialization
    void Start()
    {
        //データベースURLを設定
        FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("https://new-chuzyn.firebaseio.com/");
        userDB = FirebaseDatabase.DefaultInstance.GetReference("userdata");
        Debug.Log("へい" + userDB);

        //ageのノードからtimeで昇順ソートして最大10件を取る（非同期)
        userDB.Child("userid").GetValueAsync().ContinueWith(task =>{
            //取得失敗時
            if (task.IsFaulted){
                Debug.Log("取得失敗");
            }//取得成功
            else if (task.IsCompleted){
                Debug.Log("取得成功");
                
                //取得結果
                DataSnapshot snapshot = task.Result;

                //取得の仕方例：
                //snapshot.Child("何番か数値").Child("").GetValue(true)));
                Debug.Log(snapshot.Child("1").Child("age").GetValue(true));

                //書き込み
                //ノードにレコードを登録(Push)して生成されたキーを取得
                string key = userDB.Child("userid").Push().Key;

                //登録する一件データをDictionaryで定義(nameとtime)
                Dictionary<string, object> itemMap = new Dictionary<string, object>();
                itemMap.Add("age", "22");
                itemMap.Add("job", "学生");
                itemMap.Add("sex", "女性");

                //itemMap.Add(snapshot.Child("1").GetValue(true).ToString(), name);

                Dictionary<string, object> map = new Dictionary<string, object>();

                // "/"で一段落とせる
                map.Add(1 + "/" + key, itemMap);

                //データ更新
                userDB.UpdateChildrenAsync(map);

                //結果リストをイナムレーターで処理
                IEnumerator<DataSnapshot> en = snapshot.Children.GetEnumerator();
            }
        });
    }
}
