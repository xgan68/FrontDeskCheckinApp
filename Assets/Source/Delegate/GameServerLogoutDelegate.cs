using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameServerLogoutDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;

    public GameServerLogoutDelegate(IResponder _responder)
    {
        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.GAME_SERVER_LOGOUT, HttpRequestType.Get);
    }

    public void LogoutService()
    {
        m_httpService.SendRequest<HttpResponse>(LoginCallback);
    }

    private void LoginCallback(HttpResponse _httpResponse)
    {
        if (_httpResponse.err_code == 0)
        {
            m_responder.OnResult(_httpResponse.err_msg);
        }
        else
        {
            m_responder.OnFault(_httpResponse.err_msg);
        }
    }
}
