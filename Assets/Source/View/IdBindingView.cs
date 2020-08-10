using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class IdBindingView : UIViewBase
{
    public event Action OnStartScannerButtonClicked;

    [SerializeField]
    private Button m_startScannerButton;
    [SerializeField]
    private Text m_bindErrorText;

    void Start()
    {
        AppFacade.instance.RegisterMediator(new IdBindingViewMediator(this));
        m_startScannerButton.onClick.AddListener(() => { OnStartScannerButtonClicked(); });
    }
    
    void OnDestroy()
    {
        AppFacade.instance.RemoveMediator(IdBindingViewMediator.NAME);
    }

    public override void Hide()
    {
        base.Hide();
        ClearUI();
    }

    public void ShowBindError(string _err)
    {
        m_bindErrorText.text = _err;
    }

    private void ClearUI()
    {
        m_bindErrorText.text = "";
    }
}
