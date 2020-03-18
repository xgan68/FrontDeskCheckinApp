using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class GameSessionCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        GameSessionProxy gameSessionProxy;
        gameSessionProxy = Facade.RetrieveProxy(GameSessionProxy.NAME) as GameSessionProxy;
        string name = _notification.Name;

        switch (name)
        {
            case Const.Notification.GET_GAME_SESSIONS:
                gameSessionProxy.RequestForGameSessions();
                break;
        }
    }
}
