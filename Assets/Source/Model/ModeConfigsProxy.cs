using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class ModeConfigsProxy : Proxy, IProxy
{
    public const string NAME = "ModeConfigsProxy";

    private readonly ModeConfigVO m_normalModeConfig = new ModeConfigVO();
    private readonly ModeConfigVO m_adminModeConfig = new ModeConfigVO();
    private readonly ModeConfigVO m_networkDownModeConfig = new ModeConfigVO();

    private Mode m_currentMode;

    public ModeConfigsProxy() : base(NAME) 
    {
        m_normalModeConfig.backgroundColor = new Color(1f, 1f, 1f);
        m_adminModeConfig.backgroundColor = new Color(0f, 0f, 0f);
        m_networkDownModeConfig.backgroundColor = new Color(0.7f, 0.7f, 0.7f);

        m_normalModeConfig.modeText = "";
        m_adminModeConfig.modeText = "管理员模式";
        m_networkDownModeConfig.modeText = "离线模式";

        m_normalModeConfig.formAfterUserLogin = Const.UIFormNames.GAME_SESSION_FORM_NORMAL;
        m_adminModeConfig.formAfterUserLogin = Const.UIFormNames.GAME_SESSION_FORM_NORMAL;
        m_networkDownModeConfig.formAfterUserLogin = Const.UIFormNames.OFFLINE_UID_FORM;
    }

    public void SetCurrentMode(Mode _mode)
    {
        m_currentMode = _mode;
    }

    public ModeConfigVO GetCurrentModeConfigVO()
    {
        switch (m_currentMode)
        {
            case Mode.Normal:
                return m_normalModeConfig;
                break;
            case Mode.Admin:
                return m_adminModeConfig;
                break;
            case Mode.Offline:
                return m_networkDownModeConfig;
                break;
        }

        return m_normalModeConfig;
    }

}



public class ModeVO
{
    public Mode mode { get; set; }

    public ModeVO(Mode _mode)
    {
        mode = _mode;
    }
}

public enum Mode
{ 
    Normal,
    Admin,
    Offline
}