using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WeChatLogin : AUIPage
{
    public static Action WechatLoginSuccess;

    [SerializeField]
    private GameObject m_webviewMask;

    private void Start()
    {
        WebViewController.ReceiveTokenFromWebView += OnReceiveTokenFromWebView;
        WechatLoginSuccess += OnWeChatLoginSuccess;
        WebViewController.WebviewShowed += OnWebviewShowed;
        WebViewController.WebviewClosed += OnWebviewClosed;
    }

    private void WechatLoginQRCodeURLCallback(WechatLoginURLServerResponse response)
    {
        WebViewController.Instance.Load(response.qr_url);
    }

    public void OnWechatLoginButtonClicked()
    {
#if UNITY_EDITOR
        OnReceiveTokenFromWebView("6b1eb3318ff031a5ac09b75d9811b4f6");
#endif

#if UNITY_IPHONE && !UNITY_EDITOR
        NetworkController1.Instance.Get<WechatLoginURLServerResponse>(NetworkController1.GET_WECHAT_LOGIN_QRCODE_URL, WechatLoginQRCodeURLCallback);
#endif
    }

    public void OnPhoneLoginButtonClicked()
    {
        UIController.Instance.PhoneLoginPage.Show();
    }

    public void OnWeChatLoginSuccess()
    {
        GameManager1.Instance.OnLoginSuccess();
        WebViewController.Instance.Close();
    }

    public void OnReceiveTokenFromWebView(string myToken)
    {
        Debug.Log("webview test: " + myToken);
        WWWForm form = new WWWForm();
        form.AddField("token", myToken);
        NetworkController1.Instance.Post<ServerMessage>(NetworkController1.WECHAT_TOKEN_LOGIN, form, WechatTokenLoginCallback);
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

    public void OnWebviewCloseButtonClicked()
    {
        m_webviewMask.SetActive(false);
        WebViewController.Instance.Close();
    }

    private void OnWebviewShowed()
    {
        m_webviewMask.SetActive(true);
    }

    private void OnWebviewClosed()
    {
        m_webviewMask.SetActive(false);
    }
}

public class WechatLoginURLServerResponse
{
    public int err_code;
    public string err_msg;
    public string qr_url;
}