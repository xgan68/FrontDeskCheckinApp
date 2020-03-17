using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Const
{
    public static class Notification
    {
        #region Http request
        public const string QR_SCAN_LOGIN = "QrScanLogin";
        public const string LOGIN_SUCCESS = "LoginSuccess";
        public const string LOGIN_FAIL = "LoginFail";
        public const string LOGOUT = "Logout";
        public const string LOGOUT_SUCCESS = "LogoutSuccess";
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

        #region Local system
        public const string LOAD_UI_FORM = "LoadUIForm";
        public const string LOAD_UI_ROOT_FORM = "LoadUIRootForm";
        public const string BACK_TO_LAST_FORM = "BackToLastForm";
        public const string GO_TO_HOME_FORM = "GoToHomeForm";
        public const string GAME_STARTED = "GameStarted";
        public const string LOAD_SCENE = "LoadScene";
        #endregion

        #region Communication
        public const string WS_SEND = "WsSend";

        public const string GET_ACTOR_INFO = "GetActorInfo";
        public const string SHOW_ACTOR_INFO = "ShowActorInfo";
        public const string GAME_CLOSED = "GAME_CLOSED";

        //old, cc code ood 
        public const string SEND_LOGIN = "SendLogin";
        public const string CONNECT_TO_WS_SERVER = "ConnectToWsServer";
        public const string SETUP_CONNECTION_WITH_SERVER = "SetupConnectionWithServer";
        #endregion
    }
}
