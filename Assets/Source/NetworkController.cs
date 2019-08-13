using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkController : MonoBehaviour
{
    public static NetworkController Instance;

    void Start()
    {
        Instance = this;
    }


    public void PostPhoneNumber(string phoneNumber, System.Action callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("phoneNumber", phoneNumber);

        Debug.Log(phoneNumber);

        //StartCoroutine(Upload(form), null);
    }

    public void PostVerificationCode(string code, System.Action callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("code", code);

        Debug.Log(code);

        //StartCoroutine(UploadVerificationCode(form), callback);
    }

    IEnumerator UploadPhoneNumber(WWWForm form, System.Action callback)
    {
        string url = "";
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

    IEnumerator UploadVerificationCode(WWWForm form, System.Action<bool> callback)
    {
        string url = "";
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            callback(false);
            Debug.Log(www.error);
        }
        else
        {
            callback(true);
            Debug.Log("Form upload complete!");
        }
    }

}
