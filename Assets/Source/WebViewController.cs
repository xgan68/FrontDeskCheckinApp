using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WebViewController : MonoBehaviour
{
    public static Action<string> ReceiveMsgFromWebView;

    [Header("距离屏幕上边缘距离")]
    public int top = 0;
    [Header("距离屏幕下边缘距离")]
    public int bottom = 0;
    [Header("距离屏幕左边缘距离")]
    public int left = 0;
    [Header("距离屏幕右边缘距离")]
    public int right = 0;

    public static WebViewController Instance { get; private set; }

    void Start()
    {
        Instance = this;
    }

    void ShowMsg(string info)
    {
        Debug.Log("New Message: " + info);
        ReceiveMsgFromWebView(info);
    }

    public void Load(string url)
    {
        ULiteWebView.Ins.Show(top, bottom, left, right);
        ULiteWebView.Ins.LoadUrl(url);
    }

    public void Close()
    {
        ULiteWebView.Ins.Close();
    }

    public void LocalHtml()
    {

        string localUrl = "/ulitewebview_test.html";
        ULiteWebView.Ins.RegistJsInterfaceAction("ShowMsg", ShowMsg);
        ULiteWebView.Ins.Show(top, bottom, left, right);
        ULiteWebView.Ins.LoadLocal(localUrl);
    }

    public void CallJS()
    {
        ULiteWebView.Ins.CallJS("callJS", "unity is here");
    }
}

