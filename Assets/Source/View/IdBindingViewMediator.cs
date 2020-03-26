using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class IdBindingViewMediator : Mediator, IMediator
{
    public const string NAME = "IdBindingViewMediator";

    protected IdBindingView m_idBindingView { get { return m_viewComponent as IdBindingView; } }

    public IdBindingViewMediator(IdBindingView _view) : base(NAME, _view)
    {
        m_idBindingView.OnStartScannerButtonClicked += TryBringUPQRScanner;
    }
    
    public override System.Collections.Generic.IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.QR_SCAN_SUCCESS,
            Const.Notification.ID_BIND_SUCCESS,
            Const.Notification.ID_BIND_FAILED
        };
    }

    public override void HandleNotification(INotification notification)
    {
        string name = notification.Name;
        object vo = notification.Body;

        switch (name)
        {
            case Const.Notification.ID_BIND_SUCCESS:
                SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.BIND_SUCCESS_FORM_NORMAL);
                break;
            case Const.Notification.ID_BIND_FAILED:
                OnIdBindFailed(vo as string);
                break;
            case Const.Notification.QR_SCAN_SUCCESS:
                SendNotification(Const.Notification.BIND_ID_NORMAL);
                break;
        }
    }

    private void TryBringUPQRScanner()
    {
        SendNotification(Const.Notification.BRING_UP_QR_SCANNER);
    }

    private void OnIdBindFailed(string _errMsg)
    {
        m_idBindingView.ShowBindError(_errMsg);
    }
}
