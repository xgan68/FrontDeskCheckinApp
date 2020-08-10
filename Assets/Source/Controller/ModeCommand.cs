using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class ModeCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        ModeConfigsProxy modeConfigsProxy;
        modeConfigsProxy = Facade.RetrieveProxy(ModeConfigsProxy.NAME) as ModeConfigsProxy;
        string name = _notification.Name;

        switch (name)
        {
            case Const.Notification.SWITCH_MODE:
                modeConfigsProxy.SetCurrentMode((obj as ModeVO).mode);
                SwitchModeHandler((obj as ModeVO).mode);
                break;
        }
    }

    private void SwitchModeHandler(Mode _mode)
    {
        switch (_mode)
        {
            case Mode.Normal:
                SendNotification(Const.Notification.LOAD_UI_ROOT_FORM, Const.UIFormNames.WECHAT_LOGIN_FORM_NORMAL);
                break;
            case Mode.Admin:
                SendNotification(Const.Notification.LOAD_UI_ROOT_FORM, Const.UIFormNames.ADMIN_LOGIN_FORM);
                break;
            case Mode.Offline:
                SendNotification(Const.Notification.LOAD_UI_ROOT_FORM, Const.UIFormNames.WECHAT_LOGIN_FORM_NORMAL);
                break;
        }
    }
}
