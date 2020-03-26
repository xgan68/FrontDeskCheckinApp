using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class AppFacade : Facade, IFacade
{
    public const string STARTUP = "Startup";
    public const string LOGIN = "Login";

    private static AppFacade m_instance;

    public static AppFacade instance
    {
        get{
            if (m_instance == null)
            {
                m_instance = new AppFacade();
            }
            return m_instance;
        }
    }
    
    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(STARTUP, typeof(StartupCommand));
        RegisterCommand(Const.Notification.LOAD_UI_ROOT_FORM, typeof(UICommand));
        RegisterCommand(Const.Notification.LOAD_UI_FORM, typeof(UICommand));
        RegisterCommand(Const.Notification.POP_WARNING, typeof(UICommand));
        RegisterCommand(Const.Notification.GO_TO_HOME_FORM, typeof(UICommand));
        RegisterCommand(Const.Notification.BACK_TO_LAST_FORM, typeof(UICommand));
        RegisterCommand(Const.Notification.REQUEST_FOR_VERIFY_CODE, typeof(PhoneLoginCommand));
        RegisterCommand(Const.Notification.PHONE_LOGIN, typeof(PhoneLoginCommand));
        RegisterCommand(Const.Notification.WECHAT_LOGIN, typeof(WechatLoginCommand));
        RegisterCommand(Const.Notification.GET_GAME_SESSIONS, typeof(GameSessionCommand));
        RegisterCommand(Const.Notification.SUBMIT_SELECTED_GAME_ID, typeof(IdBindingCommand));
        RegisterCommand(Const.Notification.BRING_UP_QR_SCANNER, typeof(IdBindingCommand));
        RegisterCommand(Const.Notification.LOGOUT, typeof(LogoutCommand));
        RegisterCommand(Const.Notification.SWITCH_MODE, typeof(ModeCommand));
        RegisterCommand(Const.Notification.SET_UID, typeof(IdBindingCommand));
        RegisterCommand(Const.Notification.BIND_ID_NORMAL, typeof(IdBindingCommand));
        RegisterCommand(Const.Notification.PHONE_LOGIN_SUCCESS, typeof(IdBindingCommand));
        RegisterCommand(Const.Notification.SEND_ADMIN_LOGIN, typeof(LoginCommand));
        RegisterCommand(Const.Notification.GAME_SERVER_LOGOUT, typeof(LogoutCommand));
    }

    public void startup()
    {
        SendNotification(STARTUP);
        SendNotification(Const.Notification.LOAD_UI_ROOT_FORM, Const.UIFormNames.WECHAT_LOGIN_FORM_NORMAL);
    }
}
