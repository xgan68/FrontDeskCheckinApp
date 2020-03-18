using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class IdBindingProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "IdBindingProxy";

    private string m_selectedGameID = "";
    private string m_uid = "";

    public IdBindingProxy() : base(NAME) { }

    public void Logout()
    {
    }

    public void OnResult(object _data)
    {
        SendNotification(Const.Notification.ID_BIND_SUCCESS, _data);
    }

    public void OnFault(object _data)
    {
        SendNotification(Const.Notification.ID_BIND_FAILED, _data);
    }

    public void SubmitSelectedGameID(string _gameID)
    {
        m_selectedGameID = _gameID;
    }

    public void ScanWristBandID()
    {
#if UNITY_IPHONE && !UNITY_EDITOR
        EasyCodeScanner.Initialize();
        EasyCodeScanner.OnScannerMessage += OnScanSuccess;
        EasyCodeScanner.launchScanner(false, "FRAXINUS", -1, false);
#endif

#if UNITY_EDITOR
        OnScanSuccess("20190318g");
#endif
    }

    private void OnScanSuccess(string _data)
    {
        Debug.Log("data=:" + _data + " " + m_selectedGameID);
        SendNotification(Const.Notification.QR_SCAN_SUCCESS, _data);

        IdBindingDelegate idBindingDelegate = new IdBindingDelegate(this, m_uid, m_selectedGameID, _data);
        idBindingDelegate.Bind();
    }
}
