using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class GameSessionProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "GameSessionProxy";

    public GameSessionProxy() : base(NAME) { }

    public void RequestForGameSessions()
    {
        GameSessionDelegate gameSessionDelegate = new GameSessionDelegate(this);
        gameSessionDelegate.SendRequest();
    }

    public void OnResult(object _data)
    {
        SendNotification(Const.Notification.GAME_SESSIONS_ARRIVED, _data);
    }

    public void OnFault(object _data)
    {
        SendNotification(Const.Notification.GAME_SESSIONS_REQUEST_FAILED, _data);
    }
}
