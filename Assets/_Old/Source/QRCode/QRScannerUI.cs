using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QRScannerUI : AUIPage
{
    [SerializeField]
    private Text m_QRCodeID;

    private void Start()
    {
        QRScanManager.QRCodeScanSuccess += UpdateQRCodeID;
        QRScanManager.QRCodeIDBindCallback += OnQRCodeIDBindCallback;
    }

    private void UpdateQRCodeID(string ID)
    {
        m_QRCodeID.text = ID;
    }

    public void OnCloseButtonClicked()
    {
        this.gameObject.SetActive(false);
    }

    public void OnQRCodeIDBindCallback(int errorCode, string errorMsg)
    {
        if (errorCode == 0)
        {
            ClearUI();
            UIController.Instance.BindSuccessPage.Show();
            OnCloseButtonClicked();
        }
        else
        {
            m_QRCodeID.text = errorCode + " |||| " + errorMsg;
        }
    }

    private void ClearUI()
    {
        m_QRCodeID.text = "";
    }

    public override void ClearAll()
    {
        base.ClearAll();
        ClearUI();
    }

    public override void Hide()
    {
        base.Hide();
        ClearUI();
    }
}
