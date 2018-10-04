using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TouchScript.Gestures;

public class TouchZone : MonoBehaviour {

    public  enum InputState { Default,Touch,Release};

    public  InputState inputstate;
    
    /// <summary>タッチ開始座標 </summary>
    [HideInInspector]
    public Vector3 pressStartPosition;

    /// <summary>Press用フラグ </summary>
    [HideInInspector]
    public bool pressing, releasing, tapping, longpressing;

    /// <summary>
    /// 開始処理
    /// delegateに登録
    /// </summary>
    private void OnEnable(){
        GetComponent<PressGesture>().Pressed += PressedHandle;
        GetComponent<TapGesture>().Tapped += TapeedHandle;
        GetComponent<ReleaseGesture>().Released += ReleasedHandle;
        GetComponent<LongPressGesture>().LongPressed += LongPressedHandle;
    }

    private void OnDisable(){
        UnsubscribeEvent();
    }

    void OnDestroy(){
        UnsubscribeEvent();
    }

    void UnsubscribeEvent(){
        // 登録を解除
        GetComponent<PressGesture>().Pressed += PressedHandle;
        GetComponent<TapGesture>().Tapped += TapeedHandle;
        GetComponent<ReleaseGesture>().Released += ReleasedHandle;
        GetComponent<LongPressGesture>().LongPressed += LongPressedHandle;
    }

    //タップ処理
    void PressedHandle(object arg_sender, System.EventArgs arg_e){
        inputstate = InputState.Touch;
        var send = arg_sender as PressGesture;
        pressStartPosition = send.ScreenPosition;
        Debug.Log("プレス");

    }

    //リリース処理
    void ReleasedHandle(object arg_sender, System.EventArgs arg_e){
        inputstate = InputState.Release;
        Debug.Log("リリース");
    }

    void TapeedHandle(object arg_sender, System.EventArgs arg_e){
        var send = arg_sender as TapGesture;
        Debug.Log("タップ");
    }

    void LongPressedHandle(object arg_sender, System.EventArgs arg_e){
        var send = arg_sender as LongPressGesture;
        longpressing = true;
        Debug.Log("長押し");
    }
}
