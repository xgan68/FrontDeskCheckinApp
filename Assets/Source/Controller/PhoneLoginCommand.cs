using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class PhoneLoginCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        VerifyCodeProxy verifyCodeProxy;
        verifyCodeProxy = Facade.RetrieveProxy(VerifyCodeProxy.NAME) as VerifyCodeProxy;
        PhoneLoginProxy phoneLoginProxy;
        phoneLoginProxy = Facade.RetrieveProxy(PhoneLoginProxy.NAME) as PhoneLoginProxy;
        string name = _notification.Name;

        switch (name)
        {
            case Const.Notification.REQUEST_FOR_VERIFY_CODE:
                verifyCodeProxy.RequestForVerifyCode(obj as string);
                break;
            case Const.Notification.PHONE_LOGIN:
                phoneLoginProxy.SendLoginRequest(obj as PhoneLoginVO);
                break;
        }
    }
}
