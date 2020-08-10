using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Const
{
    public static class Notification
    {
        #region Http response
        public const string PHONE_VERIFY_CODE_SENT = "PhoneVerifyCodeSent";
        public const string PHONE_VERIFY_CODE_FAILED = "PhoneVerifyCodeFailed";
        public const string PHONE_LOGIN_SUCCESS = "PhoneLoginSuccess";
        public const string PHONE_LOGIN_FAILED = "PhoneLoginFailed";
        public const string WECHAT_LOGIN_SUCCESS = "WechatLoginSuccess";
        public const string WECHAT_LOGIN_FAILED = "WechatLoginFailed";
        public const string GAME_SESSIONS_ARRIVED = "GameSessionsArrived";
        public const string GAME_SESSIONS_REQUEST_FAILED = "GameSessionRequestFailed";
        public const string LOGOUT_SUCCESS = "LogoutSuccess";
        public const string GAME_SERVER_LOGOUT_SUCCESS = "GameServerLogoutSuccess";
        public const string GAME_SERVER_LOGOUT_FAILED = "GameServerLogoutFailed";

        #endregion

        #region Login
        public const string REQUEST_FOR_VERIFY_CODE = "RequestForVerityCode";
        public const string PHONE_LOGIN = "PhoneLogin";
        public const string WECHAT_LOGIN = "WechatLogin";
        public const string GET_GAME_SESSIONS = "GetGameSessions";
        public const string SUBMIT_SELECTED_GAME_ID = "SubmitSelectedGameID";
        public const string BRING_UP_QR_SCANNER = "BringUpQRScanner";
        public const string QR_SCAN_SUCCESS = "QRScanSuccess";
        public const string ID_BIND_SUCCESS = "IdBindSuccess";
        public const string ID_BIND_FAILED = "IdBindFailed";
        public const string LOGOUT = "Logout";
        public const string SET_UID = "SetUid";
        public const string BIND_ID_NORMAL = "BindIdNormal";
        public const string SEND_ADMIN_LOGIN = "SendAdminLogin";
        public const string GAME_SERVER_LOGOUT = "GameServerLogout";
        #endregion

        #region Local system
        public const string LOAD_UI_FORM = "LoadUIForm";
        public const string LOAD_UI_ROOT_FORM = "LoadUIRootForm";
        public const string POP_WARNING = "PopWarning";
        public const string BACK_TO_LAST_FORM = "BackToLastForm";
        public const string GO_TO_HOME_FORM = "GoToHomeForm";
        public const string GAME_STARTED = "GameStarted";
        public const string LOAD_SCENE = "LoadScene";
        public const string SWITCH_MODE = "SwitchMode";
        #endregion


        //old, cc code ood 
        #region Http request
        public const string QR_SCAN_LOGIN = "QrScanLogin";
        public const string LOGIN_SUCCESS = "LoginSuccess";
        public const string LOGIN_FAIL = "LoginFail";
        public const string CHECK_LOGIN_STATUS = "CheckLoginStatus";
        public const string CHECK_USER_INFO_EXIST = "CheckUserInfo";
        public const string SUBMIT_USER_INFO = "SubmitUserInfo";
        public const string UPDATE_QUEST_INFO_TASK = "TravelTaskInfo";
        public const string REQUEST_HINT_INFO = "RequestHintInfo";
        public const string SEND_HINT_NAME = "SendHintName"; 
        public const string UPDATE_HINT_TEXT = "TravelHintText";
        public const string BACK_HINT_INFO = "BackHintInfo";
        public const string UPDATE_EMAIL_NUMBER = "WikiNumber";
        public const string GET_EMAIL_NUM = "GetEmailNumber";
        public const string GET_WIKI_GROUP_INFO = "GetWikiGroupInfo";
        public const string GET_WIKI_RECORD_INFO = "GetWikiRecordInfo";
        public const string RECEIVE_WIKI_RECORD_INFO = "ReceiveWikiRecordName";
        #endregion



        #region Communication
        public const string WS_SEND = "WsSend";

        public const string GET_ACTOR_INFO = "GetActorInfo";
        public const string SHOW_ACTOR_INFO = "ShowActorInfo";
        public const string GAME_CLOSED = "GAME_CLOSED";



        public const string CONNECT_TO_WS_SERVER = "ConnectToWsServer";
        public const string SETUP_CONNECTION_WITH_SERVER = "SetupConnectionWithServer";
        #endregion
    }
}
