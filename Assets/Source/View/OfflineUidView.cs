using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OfflineUidView : UIViewBase
{
    public event Action ScreenButtonClicked = delegate { };
    public event Action ViewShowed = delegate { };

    [SerializeField]
    private Button m_screenButton;
    [SerializeField]
    private Text m_uidText;

    void Awake()
    {
        AppFacade.instance.RegisterMediator(new OfflineUidViewMediator(this));
        m_screenButton.onClick.AddListener(() => { ScreenButtonClicked(); });
    }
    
    void OnDestroy()
    {
        AppFacade.instance.RemoveMediator(OfflineUidViewMediator.NAME);
    }

    public override void Show()
    {
        base.Show();
        ViewShowed();
    }

    public void SetUidText(string _uid)
    {
        m_uidText.text = _uid;
    }

    public void ClearUI()
    {
        m_uidText.text = ""; 
    }
}
