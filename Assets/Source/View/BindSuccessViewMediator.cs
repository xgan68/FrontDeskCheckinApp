using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class BindSuccessViewMediator : Mediator, IMediator
{
    public const string NAME = "BindSuccessViewMediator";

    protected BindSuccessView m_bindSuccessView { get { return m_viewComponent as BindSuccessView; } }

    public BindSuccessViewMediator(BindSuccessView _view) : base(NAME, _view)
    {
        m_bindSuccessView.ScreenButtonClicked += BackToFirstStep;
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

    private void BackToFirstStep()
    {

        SendNotification(Const.Notification.LOGOUT);
        SendNotification(Const.Notification.GO_TO_HOME_FORM);
    }
}
