using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeChatLogin : AUIPage
{
    [SerializeField]
    private RawImage m_QRCodeImage;

    private void Start()
    {
        OnWechatQRCodeUpdated("https://open.weixin.qq.com/connect/confirm?uuid=061ozkkkIyiqxl-r");
    }

    private void OnWechatQRCodeUpdated(string url)
    {
        QRGenerateManger.GenerateQRImage(m_QRCodeImage, url, 256, 256);
    }

    public void OnPhoneLoginButtonClicked()
    {
        UIController.Instance.PhoneLoginPage.Show();
    }
}
