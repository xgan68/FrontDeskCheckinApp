using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class WechatLoginCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        WechatLoginProxy wechatLoginProxy;
        wechatLoginProxy = Facade.RetrieveProxy(WechatLoginProxy.NAME) as WechatLoginProxy;
        string name = _notification.Name;

        switch (name)
        {
            case Const.Notification.WECHAT_LOGIN:
                wechatLoginProxy.SendLoginRequest(obj as string);
                break;
        }
    }
}
