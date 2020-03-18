using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WechatLoginView : UIViewBase
{
    public event Action TryQrLogin = delegate { };
    public event Action PhoneLoginButtonClicked = delegate { };

    [SerializeField]
    private Button m_loginButton;
    [SerializeField]
    private Button m_phoneLoginButton;

    void Start()
    {
        AppFacade.instance.RegisterMediator(new WechatLoginViewMediator(this));

        m_loginButton.onClick.AddListener(() => { TryQrLogin(); });
        m_phoneLoginButton.onClick.AddListener(() => { PhoneLoginButtonClicked(); });
    }
    
    void OnDestroy()
    {
        AppFacade.instance.RemoveMediator(WechatLoginViewMediator.NAME);
    }

}
