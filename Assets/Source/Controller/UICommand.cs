using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class UICommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;

        string name = _notification.Name;

        switch (name)
        {
            case Const.Notification.LOAD_UI_FORM:
                UIManager.instance.ShowForm(obj as string, false);
                break;
            case Const.Notification.LOAD_UI_ROOT_FORM:
                UIManager.instance.ShowForm(obj as string, true);
                break;
            case Const.Notification.BACK_TO_LAST_FORM:
                UIManager.instance.ShowLastOpenedForm();
                break;
            case Const.Notification.GO_TO_HOME_FORM:
                UIManager.instance.ShowHomeForm();
                break;
        }
    }
}