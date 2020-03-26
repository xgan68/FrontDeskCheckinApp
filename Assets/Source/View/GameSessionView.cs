using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class GameSessionView : UIViewBase
{
    public event Action OnShow = delegate { };
    public event Action OnNextButtonClicked = delegate { };

    [SerializeField]
    private GameObject m_gameSessionGamePrefab;
    [SerializeField]
    private ToggleGroup m_gameSessionsToggleGroup;
    [SerializeField]
    private GameObject m_preGameSessionsToggleArea;
    [SerializeField]
    private GameObject m_nextGameSessionsToggleArea;
    [SerializeField]
    private GameObject m_inGameSessionsToggleArea;
    [SerializeField]
    private GameObject m_unknownGameSessionsToggleArea;
    [SerializeField]
    private Button m_nextButton;

    private List<GameObject> m_loadedToggleItems = new List<GameObject>();

    void Awake()
    {
        AppFacade.instance.RegisterMediator(new GameSessionViewMediator(this));
        m_nextButton.onClick.AddListener(() => { OnNextButtonClicked(); });
    }

    void OnDestroy()
    {
        AppFacade.instance.RemoveMediator(PhoneLoginViewMediator.NAME);
    }

    public override void Show()
    {
        base.Show();
        ClearUI();
        OnShow();
    }

    public override void Hide()
    {
        base.Hide();
        ClearUI();
    }

    public void LoadGameSessionItem(SessionInfoVO _vo)
    {
        GameObject toggleArea = m_unknownGameSessionsToggleArea;

        if (_vo.next_session)
        {
            toggleArea = m_nextGameSessionsToggleArea;
        }
        else
        {
            switch (_vo.status)
            {
                case "p":
                    toggleArea = m_preGameSessionsToggleArea;
                    break;
                case "s":
                    toggleArea = m_inGameSessionsToggleArea;
                    break;
                default:
                    toggleArea = m_unknownGameSessionsToggleArea;
                    break;
            }
        }


        GameSessionToggleItem item = Instantiate(m_gameSessionGamePrefab, toggleArea.transform).GetComponent<GameSessionToggleItem>();
        item.Init(_vo.game_id, _vo.game_time, _vo.status, m_gameSessionsToggleGroup);

        Canvas.ForceUpdateCanvases();
        toggleArea.GetComponent<GridLayoutGroup>().enabled = false;
        toggleArea.GetComponent<GridLayoutGroup>().enabled = true;

        m_loadedToggleItems.Add(item.gameObject);

        if (m_nextGameSessionsToggleArea.transform.childCount > 0)
        {
            m_nextGameSessionsToggleArea.GetComponentInChildren<Toggle>().isOn = true;
        
        }
    }

    public string GetSelectedSession()
    {
        string selectedGameID = null;

        if (m_gameSessionsToggleGroup.AnyTogglesOn())
        {
            selectedGameID = m_gameSessionsToggleGroup.ActiveToggles().FirstOrDefault().gameObject.GetComponent<GameSessionToggleItem>().gameID;
        }

        return selectedGameID;
    }

    private void ClearUI()
    {
        while(m_loadedToggleItems.Count > 0)
        {
            GameObject temp = m_loadedToggleItems[0];
            m_loadedToggleItems.RemoveAt(0);
            Destroy(temp);
        }
    }

    /*
    private void ClearToggleGroup()
    {
        foreach (Transform child in m_unknownGameSessionsToggleArea.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in m_preGameSessionsToggleArea.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in m_nextGameSessionsToggleArea.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in m_inGameSessionsToggleArea.transform)
        {
            Destroy(child.gameObject);
        }
    }
    */
}
