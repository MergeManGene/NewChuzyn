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

        //userDB.Child("age").GetValueAsync().ContinueWith(task=>)
    }
}
