using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeChatLogin : AUIPage
{

    private void Start()
    {
        //OnWechatQRCodeUpdated("https://open.weixin.qq.com/connect/confirm?uuid=061ozkkkIyiqxl-r");
        WebViewController.ReceiveMsgFromWebView += OnReceiveMsgFromWebView;
    }

    public void OnWechatLoginButtonClicked()
    {
        WebViewController.Instance.LocalHtml();
    }

    public void OnPhoneLoginButtonClicked()
    {
        UIController.Instance.PhoneLoginPage.Show();
    }

    public void OnWeChatLoginSuccess()
    {
        UIController.Instance.BindWristBandPage.Show();
        WebViewController.Instance.Close();
    }

    public void OnReceiveMsgFromWebView(string msg)
    {
        if (msg == "world")
        {
            OnWeChatLoginSuccess();
        }
    }
}