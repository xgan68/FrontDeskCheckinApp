using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class IdBindingCommand : SimpleCommand
{
    IdBindingProxy idBindingProxy;

    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        idBindingProxy = Facade.RetrieveProxy(IdBindingProxy.NAME) as IdBindingProxy;
        string name = _notification.Name;

        switch (name)
        {
            case Const.Notification.SUBMIT_SELECTED_GAME_ID:
                idBindingProxy.selectedGameID = obj as string;
                break;
            case Const.Notification.BRING_UP_QR_SCANNER:
                ScanWristBandID();
                break;
            case Const.Notification.SET_UID:
                idBindingProxy.uid = obj as string;
                break;
            case Const.Notification.BIND_ID_NORMAL:
                BindIdNormalMode();
                break;
            case Const.Notification.PHONE_LOGIN_SUCCESS:
                idBindingProxy.wbToken = (obj as PhoneLoginResponse).wb_token;
                idBindingProxy.uid = (obj as PhoneLoginResponse).user_id;
                break;
        }
    }

    public void ScanWristBandID()
    {
#if UNITY_IPHONE && !UNITY_EDITOR
        EasyCodeScanner.Initialize();
        EasyCodeScanner.OnScannerMessage += OnScanSuccess;
        EasyCodeScanner.launchScanner(false, "FRAXINUS", -1, false);
#endif

#if UNITY_EDITOR
        OnScanSuccess("20190326b");
#endif
    }

    private void OnScanSuccess(string _data)
    {
        idBindingProxy.bandID = _data;
        SendNotification(Const.Notification.QR_SCAN_SUCCESS);
    }

    private void BindIdNormalMode()
    {
        idBindingProxy.NormalModeBind(idBindingProxy.selectedGameID, idBindingProxy.bandID);
    }
}
