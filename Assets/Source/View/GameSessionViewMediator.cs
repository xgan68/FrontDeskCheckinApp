using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class GameSessionViewMediator : Mediator, IMediator
{
    public const string NAME = "GameSessionViewMediator";

    protected GameSessionView m_gameSessionView { get { return m_viewComponent as GameSessionView; } }

    public GameSessionViewMediator(GameSessionView _view) : base(NAME, _view)
    {
        m_gameSessionView.OnShow += TryRequestForGameSessions;
        m_gameSessionView.OnNextButtonClicked += SubmitSelectedGameID;
    }
    
    public override System.Collections.Generic.IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.GAME_SESSIONS_ARRIVED,
            Const.Notification.GAME_SESSIONS_REQUEST_FAILED
        };
    }

    public override void HandleNotification(INotification notification)
    {
        string name = notification.Name;
        object vo = notification.Body;

        switch (name)
        {
            case Const.Notification.GAME_SESSIONS_ARRIVED:
                OnGameSessionsArrived(vo as List<SessionInfoVO>);
                break;
            case Const.Notification.GAME_SESSIONS_REQUEST_FAILED:
                SendNotification(Const.Notification.POP_WARNING, new PopupWarningVO(Const.Notification.GO_TO_HOME_FORM, vo as string));
                break;
        }
    }

    private void TryRequestForGameSessions()
    {
        SendNotification(Const.Notification.GET_GAME_SESSIONS);
    }

    private void OnGameSessionsArrived(List<SessionInfoVO> _sessionInfoVOs)
    {
        foreach(SessionInfoVO _vo in _sessionInfoVOs)
        {
            m_gameSessionView.LoadGameSessionItem(_vo);
        }
    }

    private void OnGameSessionsRequestFailed(string _errMsg)
    {
        Debug.Log(_errMsg);
    }

    private void SubmitSelectedGameID()
    {
        string gameID = m_gameSessionView.GetSelectedSession();
        if (gameID != null)
        {
            SendNotification(Const.Notification.SUBMIT_SELECTED_GAME_ID, gameID);
            SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.ID_BINDING_FORM_NORMAL);
        }
    }
}
