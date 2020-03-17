using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Const
{
    public static class Url
    {

        public const string HTTP_SERVER_ADDRESS = "http://152.136.99.117";
        public const string WEB_SOCKET_HOST_URI = "http://www.fraxinusmothership.cn";
        public const string WEB_SOCKET_SERVER_ADDRESS = "ws://www.fraxinusmothership.cn/ws/player/";

        
        public const string POST_WRISTBAND_ID = HTTP_SERVER_ADDRESS + "/auth/wrist_band_login/";
        public const string LOGOUT = HTTP_SERVER_ADDRESS + "/auth/logout/";
        public const string GET_LOGIN_STATUS = HTTP_SERVER_ADDRESS + "/auth/check_user_login/";

        public const string GET_USERINFO=HTTP_SERVER_ADDRESS + "/auth/check_user_extra_info/";
        public const string POST_SUBMIT_USERINFO = HTTP_SERVER_ADDRESS + "/auth/update_user_extra_info/";
        public const string GET_WS_TOKEN = HTTP_SERVER_ADDRESS + "/auth/get_ws_token/";


        public const string GET_HINT = HTTP_SERVER_ADDRESS + "/game_map/get_wiki_group_info/";

        public const string GET_WIKI_GROUP_INFO = HTTP_SERVER_ADDRESS + "/game_map/get_wiki_group_info/";
        public const string GET_WIKI_RECORD_INFO = HTTP_SERVER_ADDRESS + " /game_map/get_wiki_info/";

        public const string GET_GIVELIKE = HTTP_SERVER_ADDRESS + " /game_map/get_current_game_group_user/";
        /*
        public const string CONTROL_CENTER_LOGIN = HTTP_SERVER_ADDRESS + "/auth/check_control_center_login/";
        public const string REQUEST_WS_TOKEN = HTTP_SERVER_ADDRESS + "/auth/get_ws_token/";

        public const string CHANGE_GAME_STATUS = HTTP_SERVER_ADDRESS + "/game_map/change_game_status/";
        public const string GET_AVAILABLE_GAME_SESSIONS = HTTP_SERVER_ADDRESS + "/game_map/get_available_game_sessions/";

    */
    }
}
