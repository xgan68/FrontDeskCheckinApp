using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Start()
    {
        Instance = this;
    }

    public void ReInitiate()
    {
        Logout();
        UIController.Instance.HideAll();
        UIController.Instance.ClearAll();
        UIController.Instance.WechatLoginPage.Show();
    }

    public void OnLoginSuccess()
    {
        UIController.Instance.SelectGameSessionPage.Show();
    }

    private void Logout()
    {
        NetworkController.Instance.Get<ServerMessage>(NetworkController.LOGOUT, null);
    }

    private void LogoutCallback(ServerMessage response) 
    { 
        if (response.err_code == 0)
        {
            Debug.Log("Logout Successed!");
        }
        else
        { 
            //logout failed
        }
    }
}
