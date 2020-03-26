using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class ModelPreCommand : SimpleCommand
{
    public override void Execute(PureMVC.Interfaces.INotification notification)
    {
        Facade.RegisterProxy(new VerifyCodeProxy());
        Facade.RegisterProxy(new PhoneLoginProxy());
        Facade.RegisterProxy(new WechatLoginProxy());
        Facade.RegisterProxy(new GameSessionProxy());
        Facade.RegisterProxy(new IdBindingProxy());
        Facade.RegisterProxy(new LogoutProxy());
        Facade.RegisterProxy(new LoginProxy());
        Facade.RegisterProxy(new GameServerLogoutProxy());
        Facade.RegisterProxy(new ModeConfigsProxy());
    }
}
