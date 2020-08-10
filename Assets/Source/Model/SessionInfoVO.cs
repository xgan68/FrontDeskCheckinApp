using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionInfoVO
{
    public string status { get; set; }
    public string game_id { get; set; }
    public string game_time { get; set; }
    public bool next_session { get; set; }

    public SessionInfoVO(string _gameID, string _gameTime, string _status, bool _nextSession)
    {
        game_id = _gameID;
        game_time = _gameTime;
        status = _status;
        next_session = _nextSession;
    }
}
