using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkController : MonoBehaviour
{
    public const string SERVER_NOT_RESPONDING_ERROR_MESSAGE = "服务器无响应";
    public const string GET_REGISER_VERIFY_CODE_URL = "http://152.136.99.117:8088/auth/get_register_verify_code/";
    public const string  QUICK_LOGIN_URL= "http://152.136.99.117:8088/auth/quick_login/";

    public static NetworkController Instance;

    void Start()
    {
        Instance = this;
    }

    public void PostPhoneNumber(string phoneNumber, System.Action<int, string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("phone", phoneNumber);

        StartCoroutine(UploadPhoneNumber(form, callback));
    }

    public void PostVerificationCode(string code, System.Action<int, string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("code", code);

        StartCoroutine(UploadVerificationCode(form, callback));
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


