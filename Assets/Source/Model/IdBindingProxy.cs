using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class IdBindingProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "IdBindingProxy";

    public string selectedGameID { get; set; }
    public string bandID { get; set; }
    public string uid { get; set; }
    public string wbToken { get; set; }

    public IdBindingProxy() : base(NAME)
    {
        selectedGameID = "";
        bandID = "";
        uid = "";
        wbToken = "";
    }
    
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

    public void NormalModeBind(string _gameID, string _bandID)
    {
        IdBindingDelegate idBindingDelegate = new IdBindingDelegate(this, uid, wbToken, _gameID, _bandID);
        idBindingDelegate.Bind();
    }
}
