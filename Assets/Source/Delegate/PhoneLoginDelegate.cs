using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneLoginDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;

    public PhoneLoginDelegate(IResponder _responder, PhoneLoginVO _vo)
    {
        m_responder = _responder;

        WWWForm form = new WWWForm();
        form.AddField("phone", _vo.phoneNumber);
        form.AddField("verify_code", _vo.verifyCode);

        m_httpService = new HttpService(Const.Url.PHONE_LOGIN, HttpRequestType.Post, form);
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
