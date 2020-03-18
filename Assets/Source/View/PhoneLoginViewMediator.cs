using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class PhoneLoginViewMediator : Mediator, IMediator
{
    public const string NAME = "PhoneLoginViewMediator";

    protected PhoneLoginView m_wechatLoginView { get { return m_viewComponent as PhoneLoginView; } }

    public PhoneLoginViewMediator(PhoneLoginView _view) : base(NAME, _view)
    {
        m_wechatLoginView.TryRequestVerifyCode += RequestForVerifyCode;
        m_wechatLoginView.LoginButtonClicked += TryPhoneLogin;
    }
    
    public override System.Collections.Generic.IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.PHONE_VERIFY_CODE_SENT,
            Const.Notification.PHONE_VERIFY_CODE_FAILED,
            Const.Notification.PHONE_LOGIN_SUCCESS,
            Const.Notification.PHONE_LOGIN_FAILED
        };
    }

    public override void HandleNotification(INotification notification)
    {
        string name = notification.Name;
        object vo = notification.Body;

        switch (name)
        {
            case Const.Notification.PHONE_VERIFY_CODE_SENT:
                m_wechatLoginView.OnVerifyCodeSent();
                break;
            case Const.Notification.PHONE_VERIFY_CODE_FAILED:
                m_wechatLoginView.OnVerifyCodeSendFailed(vo as string);
                break;

            case Const.Notification.PHONE_LOGIN_SUCCESS:
                m_wechatLoginView.OnLoginSuccess();
                SendNotification(Const.Notification.LOAD_UI_FORM,Const.UIFormNames.GAME_SESSION_FORM_NORMAL);
                break;
            case Const.Notification.PHONE_LOGIN_FAILED:
                m_wechatLoginView.OnLoginFailed(vo as string);
                break;
        }
    }

    private void RequestForVerifyCode()
    {
        SendNotification(Const.Notification.REQUEST_FOR_VERIFY_CODE, m_wechatLoginView.phoneLoginVO.phoneNumber);
    }

    private void TryPhoneLogin()
    {
        SendNotification(Const.Notification.PHONE_LOGIN, m_wechatLoginView.phoneLoginVO);
    }
}
