using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneLogin : MonoBehaviour
{
    public const float SEND_CODE_COOLDOWN_PERIOD = 5f;
    public const string SEND_CODE_TEXT = "发送验证码";
    public const string INVALID_PHONE_NUMBER_LENGTH_ERROR_MESSAGE = "输入的手机号码位数有误";

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

    private void Start()
    {
    }

    public void OnSendCodeButtonClicked()
    {
        if (IsPhoneNumberValid(m_phoneNumberInput.text))
        {
            OnWaitForVerifyCodeServerResponse(true);
            NetworkController.Instance.PostPhoneNumber(m_phoneNumberInput.text, VerifyCodeRequestCallBack);
        }
        else
        {
            m_invalidPhoneNumberText.text = INVALID_PHONE_NUMBER_LENGTH_ERROR_MESSAGE;
        }
    }

    private void OnWaitForVerifyCodeServerResponse(bool isWaiting)
    {
        if (isWaiting)
        {
            m_sendCodeText.text = "发送中...";
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
        NetworkController.Instance.PostVerificationCode(m_codeInput.text, LoginRequestCallBack);
    }
    
    public void OnCloseButtonClicked()
    {
        this.gameObject.SetActive(false);
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
            m_wrongVerificationCodeText.text = "";
            //bring up 手环
        }
        else
        {
            m_wrongVerificationCodeText.text = errorMsg;
        }
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
}
