using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionInfoVO
{
    public string status;
    public string game_id;
    public string game_time;

    public SessionInfoVO(string _gameID, string _gameTime, string _status)
    {
        game_id = _gameID;
        game_time = _gameTime;
        status = _status;
    }
}
