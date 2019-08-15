using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField]
    private AUIPage m_wechatLoginPage;
    public AUIPage WechatLoginPage { get { return m_wechatLoginPage; } }

    [SerializeField]
    private AUIPage m_phoneLoginPage;
    public AUIPage PhoneLoginPage { get { return m_phoneLoginPage; } }

    [SerializeField]
    private AUIPage m_bindWristBandPage;
    public AUIPage BindWristBandPage { get { return m_bindWristBandPage; } } 

    private void Start()
    {
        Instance = this;
    }

    public void HideAll()
    {
        m_phoneLoginPage.Hide();
    }

}
