using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class NetworkController1 : MonoBehaviour
{
    public const string SERVER_NOT_RESPONDING_ERROR_MESSAGE = "服务器无响应";
    public const string GET_REGISER_VERIFY_CODE_URL = "http://152.136.99.117/auth/get_register_verify_code/";
    public const string QUICK_LOGIN_URL= "http://152.136.99.117/auth/quick_login/";
    public const string BIND_WRIST_BAND_URL = "http://152.136.99.117/auth/bind_wrist_band/";
    public const string GET_WECHAT_LOGIN_QRCODE_URL = "http://152.136.99.117/auth/wechat_qr_login/";
    public const string WECHAT_TOKEN_LOGIN = "http://152.136.99.117/auth/wechat_token_login/";
    public const string GET_AVAILABLE_GAME_SESSIONS = "http://152.136.99.117/game_map/get_available_game_sessions/";
    public const string LOGOUT = "http://152.136.99.117/auth/logout/";

    public static NetworkController1 Instance;

    void Start()
    {
        Instance = this;
    }

    public void Get<T>(string url, System.Action<T> callback) where T : class
    {
        StartCoroutine(DownloadFromServer<T>(url, callback));
    }

    IEnumerator DownloadFromServer<T>(string url, System.Action<T> callback) where T : class
    {
        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("HTTP ERROR" + www.error);
            callback(null);
            //m_UIController.ShowWarningPopup(Constants.ServerParameter.SERVER_NOT_RESPONDING_ERROR_MESSAGE);
        }
        else
        {
            string json = www.downloadHandler.text;
            Debug.Log(www.downloadHandler.text);
            callback(JsonConvert.DeserializeObject<T>(json));
        }
    }

    public void Post<T>(string url, WWWForm form, System.Action<T> callback) where T : class 
    {
        StartCoroutine(UploadToServer(url, form, callback));
    }

    IEnumerator UploadToServer<T>(string url, WWWForm form, System.Action<T> callback)
    {
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            //Popup warning
            Debug.Log(www.error);
        }
        else
        {
            T serverResponse = JsonConvert.DeserializeObject<T>(www.downloadHandler.text);
            callback(serverResponse);
        }
    }

    public void PostPhoneNumber(string phoneNumber, System.Action<int, string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("phone", phoneNumber);

        StartCoroutine(UploadPhoneNumber(form, callback));
    }

    public void PostVerificationCode(string phoneNumber, string code, System.Action<int, string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("phone", phoneNumber);
        form.AddField("verify_code", code);

        StartCoroutine(UploadVerificationCode(form, callback));
    }

    public void PostQRCodeID(string ID, System.Action<int, string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("band_id", ID);

        StartCoroutine(UploadQRCodeID(form, callback));
    }

    IEnumerator UploadQRCodeID(WWWForm form, System.Action<int, string> callback)
    {
        string url = BIND_WRIST_BAND_URL;
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            callback(99, SERVER_NOT_RESPONDING_ERROR_MESSAGE);
            Debug.Log(www.error);
        }
        else
        {
            ServerMessage serverMessage = CreateFromJSON(www.downloadHandler.text);
            callback(serverMessage.err_code, serverMessage.err_msg);
            Debug.Log(serverMessage.err_code.ToString() + serverMessage.err_msg);
        }
    }

    private ServerMessage CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ServerMessage>(jsonString);
    }
    
    IEnumerator UploadPhoneNumber(WWWForm form, System.Action<int, string> callback)
    {
        string url = GET_REGISER_VERIFY_CODE_URL;
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            callback(99, SERVER_NOT_RESPONDING_ERROR_MESSAGE);
            Debug.Log(www.error);
        }
        else
        {
            ServerMessage serverMessage = CreateFromJSON(www.downloadHandler.text);
            callback(serverMessage.err_code, serverMessage.err_msg);
            Debug.Log(serverMessage.err_code.ToString() + serverMessage.err_msg);
        }
    }
    
    IEnumerator UploadVerificationCode(WWWForm form, System.Action<int, string> callback)
    {
        string url = QUICK_LOGIN_URL;
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            callback(99, SERVER_NOT_RESPONDING_ERROR_MESSAGE);
            Debug.Log(www.error);
        }
        else
        {
            ServerMessage serverMessage = CreateFromJSON(www.downloadHandler.text);
            callback(serverMessage.err_code, serverMessage.err_msg);
            Debug.Log(serverMessage.err_code.ToString() + serverMessage.err_msg);
        }
    }
}

public class ServerMessage
{
    public string err_msg;
    public int err_code;
}


