using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class VerifyCodeProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "VerifyCodeProxy";

    public VerifyCodeProxy() : base(NAME) { }

    public void RequestForVerifyCode(string _phoneNumber)
    {
        VerifyCodeDelegate verifyCodeDelegate = new VerifyCodeDelegate(this, _phoneNumber);
        verifyCodeDelegate.SendRequest();
    }

    public void OnResult(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.PHONE_VERIFY_CODE_SENT, _data);
    }

    public void OnFault(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.PHONE_VERIFY_CODE_FAILED, _data);
    }
}

