using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PhoneLoginView : UIViewBase
{
    public const float SEND_CODE_COOLDOWN_PERIOD = 10f;
    public const string SEND_CODE_TEXT = "发送验证码";
    public const string SENDING_TEXT = "发送中...";
    public const string INVALID_PHONE_NUMBER_LENGTH_ERROR_MESSAGE = "输入号码的位数有误,请确认后重新输入。";

    public event Action TryRequestVerifyCode = delegate { };
    public event Action LoginButtonClicked = delegate { };

    public PhoneLoginVO phoneLoginVO = new PhoneLoginVO();

    [SerializeField]
    private Button m_sendCodeButton;
    [SerializeField]
    private Button m_loginButton;
    [SerializeField]
    private Text m_sendCodeText;
    [SerializeField]
    private InputField m_phoneNumberInput;
    [SerializeField]
    private InputField m_codeInput;
    [SerializeField]
    private Text m_wrongVerificationCodeText;
    [SerializeField]
    private Text m_invalidPhoneNumberText;

    void Start()
    {
        AppFacade.instance.RegisterMediator(new PhoneLoginViewMediator(this));

        m_phoneNumberInput.onValueChanged.AddListener((string _num) => { 
            OnPhoneNumberInputChanged();
            phoneLoginVO.phoneNumber = _num;
        });
        m_codeInput.onValueChange.AddListener((string _code) => { phoneLoginVO.verifyCode = _code; });
        m_sendCodeButton.onClick.AddListener(() => { SendCodeButtonClicked(); });
        m_loginButton.onClick.AddListener(() => { LoginButtonClicked(); });
    }
    
    void OnDestroy()
    {
        AppFacade.instance.RemoveMediator(PhoneLoginViewMediator.NAME);
    }

    public override void Show()
    {
        base.Show();
        ClearUI();
    }

    public override void Hide()
    {
        base.Hide();
        ClearUI();
    }

    public void OnVerifyCodeSent()
    {
        Debug.Log("Verify Code Sent!");
        StartCoroutine(SendCodeButtonCoolDown());
    }

    public void OnVerifyCodeSendFailed(string _errMsg)
    {
        Debug.Log("Verify Code Send Failed: " + _errMsg);
    }

    public void OnLoginSuccess()
    {
        Debug.Log("LoginSuccess!");
    }

    public void OnLoginFailed(string _errMsg)
    {
        m_wrongVerificationCodeText.text = _errMsg;
    }

    public void SendCodeButtonClicked()
    {
        if (IsPhoneNumberValid(m_phoneNumberInput.text))
        {
            OnWaitForVerifyCodeServerResponse(true);
            TryRequestVerifyCode();
        }
        else
        {
            m_invalidPhoneNumberText.text = INVALID_PHONE_NUMBER_LENGTH_ERROR_MESSAGE;
        }
    }

    private void OnPhoneNumberInputChanged()
    {
        OnWaitForVerifyCodeServerResponse(false);
    }

    private void OnWaitForVerifyCodeServerResponse(bool isWaiting)
    {
        if (isWaiting)
        {
            m_sendCodeText.text = SENDING_TEXT;
            m_sendCodeButton.interactable = false;
        }
        else
        {
            m_sendCodeText.text = SEND_CODE_TEXT;
            m_sendCodeButton.interactable = true;
        }
    }

    IEnumerator SendCodeButtonCoolDown()
    {
        float cooldown = 0;
        m_sendCodeButton.interactable = false;
        m_sendCodeText.text = SEND_CODE_TEXT + "(" + SEND_CODE_COOLDOWN_PERIOD.ToString() + ")";

        while (cooldown < SEND_CODE_COOLDOWN_PERIOD)
        {
            yield return new WaitForSeconds(1);
            cooldown++;
            m_sendCodeText.text = SEND_CODE_TEXT + "(" + (SEND_CODE_COOLDOWN_PERIOD - cooldown).ToString() + ")";
        }

        m_sendCodeText.text = SEND_CODE_TEXT;
        m_sendCodeButton.interactable = true;
    }

    private bool IsPhoneNumberValid(string phoneNumber)
    {
        bool isValid = false;

        if (phoneNumber.Length == 11)
        {
            isValid = true;
        }
        else
        {

        }

        return isValid;
    }

    private void ClearUI()
    {
        m_wrongVerificationCodeText.text = "";
        m_invalidPhoneNumberText.text = "";
        m_phoneNumberInput.text = "";
        m_codeInput.text = "";
    }
}
