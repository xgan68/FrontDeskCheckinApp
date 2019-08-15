using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeChatLogin : AUIPage
{
    public void OnPhoneLoginButtonClicked()
    {
        UIController.Instance.PhoneLoginPage.Show();
    }
}
