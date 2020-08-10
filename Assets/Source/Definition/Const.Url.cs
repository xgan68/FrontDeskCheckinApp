using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Const
{
    public static class Url
    {
        public const string GAME_SERVER_ADDRESS = "http://testgame.fraxinusmothership.cn"; //"http://152.136.99.117";
        public const string USER_SERVER_ADDRESS = "http://testuser.fraxinusmothership.cn";

        public const string REQUEST_FOR_VERIFY_CODE = USER_SERVER_ADDRESS + "/auth/get_register_verify_code/";
        public const string PHONE_LOGIN = USER_SERVER_ADDRESS + "/auth/quick_login/";
        public const string WECHAT_LOGIN = USER_SERVER_ADDRESS + "/auth/wechat_token_login/";
        public const string GET_GAME_SESSIONS = GAME_SERVER_ADDRESS + "/game_map/get_available_game_sessions/";
        public const string ID_BINGDING = GAME_SERVER_ADDRESS + "/game_auth/bind_wristband/";
        public const string CONTROL_CENTER_LOGIN = GAME_SERVER_ADDRESS + "/game_auth/control_center_login/";
        public const string GAME_SERVER_LOGOUT = GAME_SERVER_ADDRESS + "/game_auth/device_logout/";
        public const string USER_SERVER_LOGOUT = USER_SERVER_ADDRESS + "/auth/logout/";

           
        //_outdated
        public const string WEB_SOCKET_HOST_URI = "http://www.fraxinusmothership.cn";
        public const string WEB_SOCKET_SERVER_ADDRESS = "ws://www.fraxinusmothership.cn/ws/player/";

        
        public const string POST_WRISTBAND_ID = GAME_SERVER_ADDRESS + "/auth/wrist_band_login/";

        public const string GET_LOGIN_STATUS = GAME_SERVER_ADDRESS + "/auth/check_user_login/";

        public const string GET_USERINFO=GAME_SERVER_ADDRESS + "/auth/check_user_extra_info/";
        public const string POST_SUBMIT_USERINFO = GAME_SERVER_ADDRESS + "/auth/update_user_extra_info/";
        public const string GET_WS_TOKEN = GAME_SERVER_ADDRESS + "/auth/get_ws_token/";


        public const string GET_HINT = GAME_SERVER_ADDRESS + "/game_map/get_wiki_group_info/";

        public const string GET_WIKI_GROUP_INFO = GAME_SERVER_ADDRESS + "/game_map/get_wiki_group_info/";
        public const string GET_WIKI_RECORD_INFO = GAME_SERVER_ADDRESS + " /game_map/get_wiki_info/";

        public const string GET_GIVELIKE = GAME_SERVER_ADDRESS + " /game_map/get_current_game_group_user/";
        /*
        public const string CONTROL_CENTER_LOGIN = GAME_SERVER_ADDRESS + "/auth/check_control_center_login/";
        public const string REQUEST_WS_TOKEN = GAME_SERVER_ADDRESS + "/auth/get_ws_token/";

        public const string CHANGE_GAME_STATUS = GAME_SERVER_ADDRESS + "/game_map/change_game_status/";
        public const string GET_AVAILABLE_GAME_SESSIONS = GAME_SERVER_ADDRESS + "/game_map/get_available_game_sessions/";

    */
    }
}
