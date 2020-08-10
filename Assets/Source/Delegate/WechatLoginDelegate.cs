using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WechatLoginDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;

    public WechatLoginDelegate(IResponder _responder, string _token)
    {
        m_responder = _responder;

        WWWForm form = new WWWForm();
        form.AddField("token", _token);
        m_httpService = new HttpService(Const.Url.WECHAT_LOGIN, HttpRequestType.Post, form);
    }

    public void SendRequest()
    {
        m_httpService.SendRequest<WechatLoginResponse>(RequestForVerifyCodeCallback);
    }

    private void RequestForVerifyCodeCallback(WechatLoginResponse _httpResponse)
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

public class WechatLoginResponse : HttpResponse 
{
    public string wb_token { get; set; }
    public string user_id { get; set; }

    public WechatLoginResponse(int _errCode, string _errMsg, string _wbToken, string _userID) : base(_errCode, _errMsg)
    {
        wb_token = _wbToken;
        user_id = _userID;
    }
}
