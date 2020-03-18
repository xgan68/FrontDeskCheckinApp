using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class IdBindingCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        IdBindingProxy idBindingProxy;
        idBindingProxy = Facade.RetrieveProxy(IdBindingProxy.NAME) as IdBindingProxy;
        string name = _notification.Name;

        switch (name)
        {
            case Const.Notification.SUBMIT_SELECTED_GAME_ID:
                idBindingProxy.SubmitSelectedGameID(obj as string);
                break;
            case Const.Notification.BRING_UP_QR_SCANNER:
                idBindingProxy.ScanWristBandID();
                break;
        }
    }
}
