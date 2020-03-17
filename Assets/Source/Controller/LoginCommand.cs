using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LoginCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        LoginProxy loginProxy;
        loginProxy = Facade.RetrieveProxy(LoginProxy.NAME) as LoginProxy;
        string name = _notification.Name;

        switch (name)
        {
            case Const.Notification.QR_SCAN_LOGIN:
                loginProxy.QrScanLogin();
                break;
        }
    }
}
