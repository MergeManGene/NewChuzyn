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

    [HideInInspector]
    public Vector3 flickEndPosition;

    /// <summary>Press用フラグ </summary>
    [HideInInspector]
    public bool pressing, releasing, tapping, longpressing,flicking;

    /// <summary>
    /// 開始処理
    /// delegateに登録
    /// </summary>
    private void OnEnable(){
        GetComponent<PressGesture>().Pressed += PressedHandle;
        GetComponent<TapGesture>().Tapped += TapeedHandle;
        GetComponent<ReleaseGesture>().Released += ReleasedHandle;
        GetComponent<LongPressGesture>().LongPressed += LongPressedHandle;
        GetComponent<FlickGesture>().Flicked += FlickedHandle;

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
        GetComponent<FlickGesture>().Flicked += FlickedHandle;

    }

    //タップ処理
    void PressedHandle(object arg_sender, System.EventArgs arg_e){
        inputstate = InputState.Touch;
        var send = arg_sender as PressGesture;
        pressStartPosition = send.ScreenPosition;

        pressing = true;
        Debug.Log("プレス");
    }

    //リリース処理
    void ReleasedHandle(object arg_sender, System.EventArgs arg_e){
        inputstate = InputState.Release;
        Debug.Log("リリース");
        pressing = false;
        longpressing = false;
    }

    void TapeedHandle(object arg_sender, System.EventArgs arg_e){
        var send = arg_sender as TapGesture;
        Debug.Log("タップ");
    }

    void LongPressedHandle(object arg_sender, System.EventArgs arg_e){
        var send = arg_sender as LongPressGesture;
        longpressing = true;

        Debug.Log("長押し");

        //長押し中フリックが残っていたらオフ
        if (flicking)
            flicking = false;
    }

    //フリック検知
    void FlickedHandle(object arg_sender,System.EventArgs arg_e){
        var gesture = arg_sender as FlickGesture;

        Vector3 flickEnd = gesture.ScreenPosition;
        flickEndPosition = Camera.main.ScreenToWorldPoint(flickEnd);

        //暴発防止のため長押し時のみフリックを有効にする
        if(longpressing)flicking = true;
        Debug.Log("フリッキング");
    }
}
