using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WeChatLogin : AUIPage
{
    public static Action WechatLoginSuccess;

    private void Start()
    {
        WebViewController.ReceiveTokenFromWebView += OnReceiveTokenFromWebView;
        WechatLoginSuccess += OnWeChatLoginSuccess;
    }

    private void WechatLoginQRCodeURLCallback(WechatLoginURLServerResponse response)
    {
        WebViewController.Instance.Load(response.qr_url);
    }

    public void OnWechatLoginButtonClicked()
    {
        //WebViewController.Instance.Load("https://baidu.com");
        NetworkController.Instance.Get<WechatLoginURLServerResponse>(NetworkController.GET_WECHAT_LOGIN_QRCODE_URL, WechatLoginQRCodeURLCallback);
    }

    public void OnPhoneLoginButtonClicked()
    {
        UIController.Instance.PhoneLoginPage.Show();
    }

    public void OnWeChatLoginSuccess()
    {
        GameManager.Instance.OnLoginSuccess();
        WebViewController.Instance.Close();
    }

    public void OnReceiveTokenFromWebView(string myToken)
    {
        Debug.Log("webview test: " + myToken);
        WWWForm form = new WWWForm();
        form.AddField("token", myToken);
        NetworkController.Instance.Post<ServerMessage>(NetworkController.WECHAT_TOKEN_LOGIN, form, WechatTokenLoginCallback);
    }

    public void WechatTokenLoginCallback(ServerMessage response)
    {
        Debug.Log("token login status: " + response.err_code);
        if (response.err_code == 0)
        {
            OnWeChatLoginSuccess();
        }
        else
        {
            WebViewController.Instance.Close();
        }
    }
}

public class WechatLoginURLServerResponse
{
    public int err_code;
    public string err_msg;
    public string qr_url;
}