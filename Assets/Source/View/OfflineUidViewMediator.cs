using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class OfflineUidViewMediator : Mediator, IMediator
{
    public const string NAME = "OfflineUidViewMediator";

    protected OfflineUidView m_offlineUidView { get { return m_viewComponent as OfflineUidView; } }

    public OfflineUidViewMediator(OfflineUidView _view) : base(NAME, _view)
    {
        m_offlineUidView.ScreenButtonClicked += BackToFirstStep;
        m_offlineUidView.ViewShowed += UpdateUid;
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

    private void UpdateUid()
    {
        m_offlineUidView.SetUidText((AppFacade.instance.RetrieveProxy(IdBindingProxy.NAME) as IdBindingProxy).uid);
    }
}
