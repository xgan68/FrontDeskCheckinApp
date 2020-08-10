using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class WarningPopupViewMediator : Mediator, IMediator
{
    public const string NAME = "WarningPopupViewMediator";

    protected WarningPopupView m_warningPopupView { get { return m_viewComponent as WarningPopupView; } }

    public WarningPopupViewMediator(WarningPopupView _view) : base(NAME, _view)
    {
        m_warningPopupView.ButtonClicked += OnButtonClicked;
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

    private void OnButtonClicked()
    {
        if (m_warningPopupView.popupWarningVO.notificationVO != null)
        {
            SendNotification(m_warningPopupView.popupWarningVO.actionNotification, 
                             m_warningPopupView.popupWarningVO.notificationVO);
        }
        else
        {
            SendNotification(m_warningPopupView.popupWarningVO.actionNotification);
        }

        m_warningPopupView.Hide();
    }
}
