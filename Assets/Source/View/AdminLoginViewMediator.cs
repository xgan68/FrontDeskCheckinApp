using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class AdminLoginViewMediator : Mediator, IMediator
{
    public const string NAME = "AdminLoginViewMediator";

    protected AdminLoginView m_adminLoginView { get { return m_viewComponent as AdminLoginView; } }

    public AdminLoginViewMediator(AdminLoginView _view) : base(NAME, _view)
    {
        m_adminLoginView.OnNextStepButtonClicked += GotoSelectSessionPage;
    }
    
    public override System.Collections.Generic.IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
        };
    }

    public override void HandleNotification(INotification notification)
    {
        string name = notification.Name;
        object vo = notification.Body;

        switch (name)
        {
        }
    }

    private void GotoSelectSessionPage()
    {
        SendNotification(Const.Notification.SET_UID, m_adminLoginView.uid);
        SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.GAME_SESSION_FORM_NORMAL);
    }
}
