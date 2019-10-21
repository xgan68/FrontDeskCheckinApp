using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SelectGameSessionUI : AUIPage
{
    [SerializeField]
    private GameObject m_gameSessionGamePrefab;
    [SerializeField]
    private ToggleGroup m_gameSessionsToggleGroup;

    public override void Show()
    {
        base.Show();

        NetworkController.Instance.Get<GameSessionsResponse>(NetworkController.GET_AVAILABLE_GAME_SESSIONS, GameSessionsCallback);
    }

    public override void ClearAll()
    {
        base.ClearAll();
        ClearToggleGroup();
    }

    private void LoadGameSessionInfos(List<GameSessionInfo> gameSessionInfos)
    {
        ClearToggleGroup();

        for (int i = 0; i < gameSessionInfos.Count; i++)
        {
            GameSessionToggleItem item = Instantiate(m_gameSessionGamePrefab, m_gameSessionsToggleGroup.transform).GetComponent<GameSessionToggleItem>();

            item.Init(gameSessionInfos[i].game_id, gameSessionInfos[i].game_time, gameSessionInfos[i].status, m_gameSessionsToggleGroup);
        }
    }

    private void ClearToggleGroup()
    {
        foreach (Transform child in m_gameSessionsToggleGroup.transform)
        {
            Destroy(child.gameObject);
        }

    }

    private void GameSessionsCallback(GameSessionsResponse response)
    {
        if (response.err_code == 0)
        {
            LoadGameSessionInfos(response.game_sessions_info);
        }
        else
        {
            //TODO: Network warning UI
            Debug.Log("Game session get failed");
        }
    }

    public void OnConfirmButtonClicked()
    {
        if (m_gameSessionsToggleGroup.AnyTogglesOn())
        {
            string SelectedGameID = m_gameSessionsToggleGroup.ActiveToggles().FirstOrDefault().gameObject.GetComponent<GameSessionToggleItem>().gameID;
            QRScanManager.Instance.UpdateGameSessionID(SelectedGameID);
            UIController.Instance.BindWristBandPage.Show();
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
