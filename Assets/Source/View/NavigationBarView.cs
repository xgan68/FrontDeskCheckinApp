using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NavigationBarView : UIViewBase
{
    public event Action BackButtonClicked = delegate { };
    public event Action HomeButtonClicked = delegate { };

    [SerializeField]
    private Button m_backButton;
    [SerializeField]
    private Button m_homeButton;

    void Start()
    {
        AppFacade.instance.RegisterMediator(new NavigationBarViewMediator(this));
        m_backButton.onClick.AddListener(() => { BackButtonClicked(); });
        m_homeButton.onClick.AddListener(() => { HomeButtonClicked(); });

    }
    
    void OnDestroy()
    {
        AppFacade.instance.RemoveMediator(NavigationBarViewMediator.NAME);
    }
}
