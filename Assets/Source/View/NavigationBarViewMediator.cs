using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class NavigationBarViewMediator : Mediator, IMediator
{
    public const string NAME = "NavigationBarViewMediator";

    protected NavigationBarView m_bindSuccessView { get { return m_viewComponent as NavigationBarView; } }

    public NavigationBarViewMediator(NavigationBarView _view) : base(NAME, _view)
    {
        m_bindSuccessView.BackButtonClicked += Back;
        m_bindSuccessView.HomeButtonClicked += Home;
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

    private void Back()
    {
        SendNotification(Const.Notification.BACK_TO_LAST_FORM);
    }

    private void Home()
    {
        SendNotification(Const.Notification.GO_TO_HOME_FORM);
    }
}
