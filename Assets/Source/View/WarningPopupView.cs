using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WarningPopupView : UIViewBase
{
    public event Action ButtonClicked = delegate { };

    public PopupWarningVO popupWarningVO { get; private set; }

    [SerializeField]
    private Button m_confirmButton;
    [SerializeField]
    private Text m_warningText;

    void Start()
    {
        AppFacade.instance.RegisterMediator(new WarningPopupViewMediator(this));
        m_confirmButton.onClick.AddListener(() => { ButtonClicked(); });
    }
    
    void OnDestroy()
    {
        AppFacade.instance.RemoveMediator(WarningPopupViewMediator.NAME);
    }

    public void UpdatePopupwarningVO(PopupWarningVO _vo)
    {
        popupWarningVO = _vo;
        m_warningText.text = _vo.warningText;
    }
}

public class PopupWarningVO
{
    public string actionNotification { get; private set; }
    public object notificationVO { get; private set; }
    public string warningText { get; private set; }

    public PopupWarningVO(string _actionNoti, object _notiVO, string _warningText)
    {
        actionNotification = _actionNoti;
        notificationVO = _notiVO;
        warningText = _warningText;
    }

    public PopupWarningVO(string _actionNoti, string _warningText)
    {
        actionNotification = _actionNoti;
        notificationVO = null;
        warningText = _warningText;
    }
}