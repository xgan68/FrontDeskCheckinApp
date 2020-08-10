using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LogoutProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "LogoutProxy";

    public LogoutProxy() : base(NAME) { }

    public void Logout()
    {
        LogoutDelegate logoutDelegate = new LogoutDelegate(this);
        logoutDelegate.LogoutService();
    }

    public void OnResult(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.LOGOUT_SUCCESS);
        Debug.Log("Logout Success");
    }

    public void OnFault(object _data)
    {
        Debug.Log("Logout Failed: " + _data);
    }
}
