using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LogoutCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        LogoutProxy logoutProxy;
        logoutProxy = Facade.RetrieveProxy(LogoutProxy.NAME) as LogoutProxy;
        string name = _notification.Name;

        switch (name)
        {
            case Const.Notification.LOGOUT:
                logoutProxy.Logout();
                break;
        }
    }
}
