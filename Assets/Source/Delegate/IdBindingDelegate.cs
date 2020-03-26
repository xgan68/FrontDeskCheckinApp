using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdBindingDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;

    public IdBindingDelegate(IResponder _responder, string _uid, string _wbToken, string _gameId, string _bandId)
    {
        m_responder = _responder;

        WWWForm form = new WWWForm();
        form.AddField("user_id", _uid);
        form.AddField("wb_token", _wbToken);
        form.AddField("band_id", _bandId);
        form.AddField("game_id", _gameId);

        m_httpService = new HttpService(Const.Url.ID_BINGDING, HttpRequestType.Post, form);
    }

    public void Bind()
    {
        m_httpService.SendRequest<HttpResponse>(IdBindingResponse);
    }

    private void IdBindingResponse(HttpResponse _httpResponse)
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
