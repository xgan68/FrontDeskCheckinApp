using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyCodeDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;

    public VerifyCodeDelegate(IResponder _responder, string _phoneNumber)
    {
        m_responder = _responder;

        WWWForm form = new WWWForm();
        form.AddField("phone", _phoneNumber);

        m_httpService = new HttpService(Const.Url.REQUEST_FOR_VERIFY_CODE, HttpRequestType.Post, form);
    }

    public void SendRequest()
    {
        m_httpService.SendRequest<HttpResponse>(RequestForVerifyCodeCallback);
    }

    private void RequestForVerifyCodeCallback(HttpResponse _httpResponse)
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
