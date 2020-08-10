using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class GameServerLogoutProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "GameServerLogoutProxy";

    public GameServerLogoutProxy() : base(NAME) { }

    public void Logout()
    {
        GameServerLogoutDelegate logoutDelegate = new GameServerLogoutDelegate(this);
        logoutDelegate.LogoutService();
    }

    public void OnResult(object _data)
    {
        SendNotification(Const.Notification.GAME_SERVER_LOGOUT_SUCCESS);
        Debug.Log("Game Server Logout Success");
    }

    public void OnFault(object _data)
    {
        SendNotification(Const.Notification.GAME_SERVER_LOGOUT_FAILED);
        Debug.Log("Logout Failed: " + _data);
    }
}
