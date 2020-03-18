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
    }
    
    public override System.Collections.Generic.IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {

        };
    }

    public override void HandleNotification(INotification notification)
    {
        string name = notification.Name;
        object vo = notification.Body;

        switch (name)
        {
        }
    }

    private void OnPhoneLoginButton()
    {
        SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.PHONE_LOGIN_FORM_NORMAL);
    }
}
