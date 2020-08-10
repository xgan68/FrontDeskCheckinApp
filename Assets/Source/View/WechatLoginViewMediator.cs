using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class WechatLoginViewMediator : Mediator, IMediator
{
    public const string NAME = "WechatLoginViewMediator";

    protected WechatLoginView m_wechatLoginView { get { return m_viewComponent as WechatLoginView; } }

    public WechatLoginViewMediator(WechatLoginView _view) : base(NAME, _view)
    {
        m_wechatLoginView.PhoneLoginButtonClicked += OnPhoneLoginButton;
        m_wechatLoginView.WechatLoginButtonClicked += OnWechatLoginButton;
    }
    
    public override System.Collections.Generic.IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.WECHAT_LOGIN_SUCCESS,
            Const.Notification.WECHAT_LOGIN_FAILED
        };
    }

    public override void HandleNotification(INotification notification)
    {
        string name = notification.Name;
        object vo = notification.Body;

        switch (name)
        {
            case Const.Notification.WECHAT_LOGIN_SUCCESS:
                OnWechaLoginSuccess();
                break;
            case Const.Notification.WECHAT_LOGIN_FAILED:
                OnWechaLoginFailed(vo as string);
                break;
        }
    }

    private void OnPhoneLoginButton()
    {
        SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.PHONE_LOGIN_FORM_NORMAL);
    }

    private void OnWechatLoginButton()
    {
#if UNITY_EDITOR
        //OnReceiveTokenFromWebView("6b1eb3318ff031a5ac09b75d9811b4f6");
        //SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.OFFLINE_UID_FORM);
        SendNotification(Const.Notification.WECHAT_LOGIN, "6b1eb3318ff031a5ac09b75d9811b4f6");
#endif

#if UNITY_IPHONE && !UNITY_EDITOR
        //NetworkController1.Instance.Get<WechatLoginURLServerResponse>(NetworkController1.GET_WECHAT_LOGIN_QRCODE_URL, WechatLoginQRCodeURLCallback);
#endif

    }

    private void OnWechaLoginSuccess()
    {
        SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.GAME_SESSION_FORM_NORMAL);
    }

    private void OnWechaLoginFailed(string _errMsg)
    {
        m_wechatLoginView.UpdateWechatLoginResult(_errMsg);
    }

}
