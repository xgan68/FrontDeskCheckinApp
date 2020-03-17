using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LoginView : UIViewBase
{
    public event Action TryLogin = delegate { };

    [SerializeField]
    private Button m_loginButton;
    [SerializeField]
    private Text m_loginStatus;

    void Start()
    {
        AppFacade.instance.RegisterMediator(new LoginViewMediator(this));

        m_loginButton.onClick.AddListener(() => { TryLogin(); });
    }
    
    void OnDestroy()
    {
        AppFacade.instance.RemoveMediator(LoginViewMediator.NAME);
    }

    public void OnLoginSuccess(object _vo)
    {
        m_loginStatus.text = _vo as string;
    }

    public void OnLoginFail(object _vo)
    {
        m_loginStatus.text = _vo as string;
    }
}
