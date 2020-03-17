using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LoginStatusProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "LoginStatusProxy";

    public LoginStatusProxy() : base(NAME) { }

    public void CheckLoginStatus()
    {
        LoginStatusDelegate loginStatusDelegate = new LoginStatusDelegate(this);
        loginStatusDelegate.GetLoginStatus();
    }

    public void OnResult(object _data)
    {
        Debug.Log(_data as string);
        AppFacade.instance.SendNotification(Const.Notification.LOGIN_SUCCESS, _data);
    }

    public void OnFault(object _data)
    {
        Debug.Log("Not Log in yet");
        AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_ROOT_FORM, Const.UIFormNames.LOGIN_FORM);
    }
}
