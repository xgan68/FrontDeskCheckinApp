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

    private void Logout()
    { 
        //Post Logout;
    }
}
