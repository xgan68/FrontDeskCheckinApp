using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;

    public GameSessionDelegate(IResponder _responder)
    {
        m_responder = _responder;

        m_httpService = new HttpService(Const.Url.GET_GAME_SESSIONS, HttpRequestType.Get);
    }

    public void SendRequest()
    {
        m_httpService.SendRequest<GameSessionResponse>(GameSessionCallback);
    }

    private void GameSessionCallback(GameSessionResponse _sessionResponse)
    {
        if ((_sessionResponse as HttpResponse).err_code == 0)
        {
            m_responder.OnResult(_sessionResponse.game_sessions_info);
        }
        else
        {
            m_responder.OnFault(_sessionResponse.err_msg);
        }
    }
}

public class GameSessionResponse : HttpResponse
{
    public List<SessionInfoVO> game_sessions_info;

    public GameSessionResponse(List<SessionInfoVO> _info, int _errCode, string _errMsg) : base(_errCode, _errMsg)
    {
        game_sessions_info = _info;
    }
}
