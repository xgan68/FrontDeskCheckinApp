using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class WechatLoginProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "WechatLoginProxy";

    public WechatLoginProxy() : base(NAME) { }

    public void SendLoginRequest(string _token)
    {
        WechatLoginDelegate wechatLoginDelegate = new WechatLoginDelegate(this, _token);
        wechatLoginDelegate.SendRequest();
    }

    public void OnResult(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.WECHAT_LOGIN_SUCCESS, _data);
    }

    public void OnFault(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.WECHAT_LOGIN_FAILED, _data);
    }
}

