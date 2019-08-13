using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneLogin : MonoBehaviour
{
    public const float SEND_CODE_COOLDOWN_PERIOD = 5f;
    public const string SEND_CODE_TEXT = "发送验证码";

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
    private GameObject m_wrongVerificationCodeText;

    private void Start()
    {
       // m_sendCodeButton.interactable = false;
    }

    public void OnSendCodeButtonClicked()
    {
        if (IsPhoneNumberValid(m_phoneNumberInput.text))
        {
            NetworkController.Instance.PostPhoneNumber(m_phoneNumberInput.text, delegate { });
            StartCoroutine(SendCodeButtonCoolDown());
        }
    }

    public void OnLoginButtonClicked()
    {
        NetworkController.Instance.PostVerificationCode(m_codeInput.text, ShowWorngCodeText);
    }

    public void ShowWorngCodeText()
    {
        m_wrongVerificationCodeText.SetActive(true);
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

        return isValid;
    }
}
