using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class PhoneLoginProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "PhoneLoginProxy";

    public PhoneLoginProxy() : base(NAME) { }

    public void SendLoginRequest(PhoneLoginVO _vo)
    {
        PhoneLoginDelegate phoneLoginDelegate = new PhoneLoginDelegate(this, _vo);
        phoneLoginDelegate.SendRequest();
    }

    public void OnResult(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.PHONE_LOGIN_SUCCESS, _data);
    }

    public void OnFault(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.PHONE_LOGIN_FAILED, _data);
    }
}

