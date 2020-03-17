using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginStatusDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;

    public LoginStatusDelegate(IResponder _responder)
    {
        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.GET_LOGIN_STATUS, HttpRequestType.Get);
    }

    public void GetLoginStatus()
    {
        m_httpService.SendRequest<HttpResponse>(LoginCallback);
    }

    private void LoginCallback(HttpResponse _httpResponse)
    {
        if (_httpResponse.err_code != 0)
        {
            m_responder.OnFault(_httpResponse.err_msg);
        }
        else
        {
            m_responder.OnResult(_httpResponse.err_msg);
        }
    }
}
