using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneLogin : AUIPage
{
    public const float SEND_CODE_COOLDOWN_PERIOD = 10f;
    public const string SEND_CODE_TEXT = "发送验证码";
    public const string SENDING_TEXT = "发送中...";
    public const string INVALID_PHONE_NUMBER_LENGTH_ERROR_MESSAGE = "输入号码的位数有误,请确认后重新输入。";

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

    public void OnSendCodeButtonClicked()
    {
        if (IsPhoneNumberValid(m_phoneNumberInput.text))
        {
            OnWaitForVerifyCodeServerResponse(true);
            NetworkController1.Instance.PostPhoneNumber(m_phoneNumberInput.text, VerifyCodeRequestCallBack);
        }
        else
        {
            m_invalidPhoneNumberText.text = INVALID_PHONE_NUMBER_LENGTH_ERROR_MESSAGE;
        }
    }

    private void Start()
    {
        m_phoneNumberInput.onValueChanged.AddListener(delegate { OnPhoneNumberInputChanged(); });
    }

    private void OnEnable()
    {
        RefreshUserInputs();
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

    public void OnLoginButtonClicked()
    {
        NetworkController1.Instance.PostVerificationCode(m_phoneNumberInput.text, m_codeInput.text, LoginRequestCallBack);
    }
    
    public void OnCloseButtonClicked()
    {
        Hide();
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

    private void LoginRequestCallBack(int errorCode, string errorMsg)
    {
        if (errorCode == 0)
        {
            OnPhoneLoginSuccess();
        }
        else
        {
            m_wrongVerificationCodeText.text = errorMsg;
        }
    }

    private void OnPhoneLoginSuccess()
    {
        m_wrongVerificationCodeText.text = "";
        GameManager1.Instance.OnLoginSuccess();
    }

    private void VerifyCodeRequestCallBack(int errorCode, string errorMsg)
    {
        if (errorCode == 0)
        {
            m_invalidPhoneNumberText.text = "";
            StartCoroutine(SendCodeButtonCoolDown());
        }
        else
        {
            m_invalidPhoneNumberText.text = errorMsg;
        }
        OnWaitForVerifyCodeServerResponse(false);
    }

    private void OnPhoneNumberInputChanged()
    {
        OnWaitForVerifyCodeServerResponse(false);
    }

    private void RefreshUserInputs()
    {
        m_wrongVerificationCodeText.text = "";
        m_invalidPhoneNumberText.text = "";
        m_phoneNumberInput.text = "";
        m_codeInput.text = "";
    }

    public override void ClearAll()
    {
        base.ClearAll();
        RefreshUserInputs();
    }
}
