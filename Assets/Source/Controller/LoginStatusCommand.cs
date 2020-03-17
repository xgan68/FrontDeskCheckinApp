using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;


public class LoginStatusCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        LoginStatusProxy loginStatusProxy = Facade.RetrieveProxy(LoginStatusProxy.NAME) as LoginStatusProxy;
        string name = _notification.Name;

        switch (name)
        {
            case Const.Notification.CHECK_LOGIN_STATUS:
                loginStatusProxy.CheckLoginStatus();
                break;
        }
    }
}
