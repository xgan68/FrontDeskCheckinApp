using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ModeSelectionView : UIViewBase
{
    [SerializeField]
    private GameObject m_modeSelectionPanel;
    [SerializeField]
    private Toggle m_selectionToggle;
    [SerializeField]
    private Button m_normalModeButton;
    [SerializeField]
    private Button m_adminModeButton;
    [SerializeField]
    private Button m_offlineModeButton;


    private void Awake()
    {
        m_selectionToggle.onValueChanged.AddListener((bool _isOn) => { OnSelectionToggle(_isOn); });
        m_normalModeButton.onClick.AddListener(() => { OnNormalModeButton(); });
        m_adminModeButton.onClick.AddListener(() => { OnAdminModeButton(); });
        m_offlineModeButton.onClick.AddListener(() => { OnOfflineModeButton(); });
    }

    private void OnSelectionToggle(bool _isOn)
    { 
        if (_isOn)
        {
            m_modeSelectionPanel.SetActive(true);
        }
        else
        {
            m_modeSelectionPanel.SetActive(false);
        }
    }

    private void OnNormalModeButton()
    {
        AppFacade.instance.SendNotification(Const.Notification.SWITCH_MODE, new ModeVO(Mode.Normal));
    }

    private void OnAdminModeButton()
    {

        AppFacade.instance.SendNotification(Const.Notification.GAME_SERVER_LOGOUT);
        AppFacade.instance.SendNotification(Const.Notification.SWITCH_MODE, new ModeVO(Mode.Admin));
    }

    private void OnOfflineModeButton()
    {
        AppFacade.instance.SendNotification(Const.Notification.SWITCH_MODE, new ModeVO(Mode.Offline));
    }

}
