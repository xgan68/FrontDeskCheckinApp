using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LoginProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "LoginProxy";

    public LoginProxy() : base(NAME) { }

    public void QrScanLogin()
    {
#if UNITY_IPHONE && !UNITY_EDITOR
        EasyCodeScanner.Initialize();

        EasyCodeScanner.OnScannerMessage += onScannerMessage;
        //EasyCodeScanner.OnScannerEvent += onScannerEvent;
        //EasyCodeScanner.OnDecoderMessage += onDecoderMessage;

        EasyCodeScanner.launchScanner(false, "FRAXINUS", -1, false);
#endif

#if UNITY_EDITOR
        SendLogin(new LoginVO("1234512345", "TestUWB123"));
#endif
    }

    private void onScannerMessage(string _data)
    {
        Debug.Log("EasyCodeScannerExample - onScannerMessage data=:" + _data);

        SendLogin(new LoginVO(_data, "TestUWB123"));
    }
    
    public void SendLogin(object _data)
    {
    }

    public void OnResult(object _data)
    {
        //Debug.Log("Band ID Login Success");
        AppFacade.instance.SendNotification(Const.Notification.LOGIN_SUCCESS, _data);
    }

    public void OnFault(object _data)
    {
        //Debug.Log(_data as string);
        AppFacade.instance.SendNotification(Const.Notification.LOGIN_FAIL, _data);
    }
}

