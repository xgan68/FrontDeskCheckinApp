using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameSessionUI : AUIPage
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Show()
    {
        base.Show();

        NetworkController.Instance.Get<GameSessionsResponse>(NetworkController.GET_AVAILABLE_GAME_SESSIONS, GameSessionsCallback);
    }

    private void GameSessionsCallback(GameSessionsResponse response)
    {
        Debug.Log(response.game_sessions_info.Count);
        if (response.err_code == 0)
        {
            QRScanManager.Instance.UpdateGameSessionID(response.game_sessions_info[0].game_id);
            //TODO: remove after finished game session select UI
            UIController.Instance.BindWristBandPage.Show();
        }
        else
        {
            //TODO: Network warning UI
            Debug.Log("Game session get failed");
        }
    }
}

public class GameSessionsResponse : ServerMessage
{
    public List<GameSessionInfo> game_sessions_info;
}

public class GameSessionInfo
{
    public string status;
    public string game_id;
    public string game_time;
}
