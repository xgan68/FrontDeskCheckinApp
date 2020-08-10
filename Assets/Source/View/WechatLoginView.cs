using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WechatLoginView : UIViewBase
{
    public event Action TryQrLogin = delegate { };
    public event Action PhoneLoginButtonClicked = delegate { };
    public event Action WechatLoginButtonClicked = delegate { };

    [SerializeField]
    private Button m_loginButton;
    [SerializeField]
    private Button m_phoneLoginButton;
    [SerializeField]
    private Button m_wechatLoginButton;
    [SerializeField]
    private Text m_wechatLoginResult;

    void Start()
    {
        AppFacade.instance.RegisterMediator(new WechatLoginViewMediator(this));

        m_loginButton.onClick.AddListener(() => { TryQrLogin(); });
        m_phoneLoginButton.onClick.AddListener(() => { PhoneLoginButtonClicked(); });
        m_wechatLoginButton.onClick.AddListener(() => { WechatLoginButtonClicked(); });
    }
    
    void OnDestroy()
    {
        AppFacade.instance.RemoveMediator(WechatLoginViewMediator.NAME);
    }

    public override void Show()
    {
        base.Show();
        ClearUI();
    }

    public void UpdateWechatLoginResult(string _resultText)
    {
        m_wechatLoginResult.text = _resultText;
    }

    private void ClearUI()
    {
        m_wechatLoginResult.text = "";
    }
}
