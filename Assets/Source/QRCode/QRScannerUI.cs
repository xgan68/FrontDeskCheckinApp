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
    }

    private void UpdateQRCodeID(string ID)
    {
        m_QRCodeID.text = ID;
    }

    public void OnCloseButtonClicked()
    {
        this.gameObject.SetActive(false);
    }
}
