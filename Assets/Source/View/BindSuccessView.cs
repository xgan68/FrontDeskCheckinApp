using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BindSuccessView : UIViewBase
{
    public event Action ScreenButtonClicked = delegate { };

    [SerializeField]
    private Button m_screenButton;

    void Start()
    {
        AppFacade.instance.RegisterMediator(new BindSuccessViewMediator(this));
        m_screenButton.onClick.AddListener(() => { ScreenButtonClicked(); });
    }
    
    void OnDestroy()
    {
        AppFacade.instance.RemoveMediator(BindSuccessViewMediator.NAME);
    }
}
