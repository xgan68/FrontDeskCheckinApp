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

    [SerializeField]
    private AUIPage m_bindSuccessPage;
    public AUIPage BindSuccessPage { get { return m_bindSuccessPage; } }

    [SerializeField]
    private AUIPage m_selectGameSessionPage;
    public AUIPage SelectGameSessionPage { get { return m_selectGameSessionPage; } }

    private void Start()
    {
        Instance = this;
    }

    public void HideAll()
    {
        m_phoneLoginPage.Hide();
        m_wechatLoginPage.Hide();
        m_bindWristBandPage.Hide();
        m_bindSuccessPage.Hide();
        m_selectGameSessionPage.Hide();
    }

    public void ClearAll()
    {
        m_phoneLoginPage.ClearAll();
        m_wechatLoginPage.ClearAll();
        m_bindWristBandPage.ClearAll();
        m_bindSuccessPage.ClearAll();
        m_selectGameSessionPage.ClearAll();
    }
}
