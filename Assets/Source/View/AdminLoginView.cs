using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AdminLoginView : UIViewBase
{
    public event Action OnNextStepButtonClicked;

    [SerializeField]
    private Text m_signInNextPlayerText;
    [SerializeField]
    private Button m_nextStepButton;
    [SerializeField]
    private InputField m_uidInputField;

    public string uid { get; private set; }

    void Start()
    {
        AppFacade.instance.RegisterMediator(new AdminLoginViewMediator(this));
        m_nextStepButton.onClick.AddListener(() => { NextStepButtonClicked(); });
        m_uidInputField.onValueChanged.AddListener((string _uid) => { uid = _uid; });
    }
    
    void OnDestroy()
    {
        AppFacade.instance.RemoveMediator(AdminLoginViewMediator.NAME);
    }

    public override void Show()
    {
        base.Show();

    }

    private void NextStepButtonClicked()
    { 
        if (m_uidInputField.text.Length > 0)
        {
            OnNextStepButtonClicked();
        }
    }

    private void ClearUI()
    {
        m_uidInputField.text = "";
    }
}
