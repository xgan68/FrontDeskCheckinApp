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
        m_httpService.SendRequest<PhoneLoginResponse>(RequestForVerifyCodeCallback);
    }

    private void RequestForVerifyCodeCallback(PhoneLoginResponse _httpResponse)
    {
        if (_httpResponse.err_code == 0)
        {
            m_responder.OnResult(_httpResponse);
        }
        else
        {
            m_responder.OnFault(_httpResponse.err_msg);
        }
    }
}

public class PhoneLoginResponse : HttpResponse 
{
    public string wb_token { get; set; }
    public string user_id { get; set; }

    public PhoneLoginResponse(int _errCode, string _errMsg, string _wbToken, string _userID) : base(_errCode, _errMsg)
    {
        wb_token = _wbToken;
        user_id = _userID;
    }
}
