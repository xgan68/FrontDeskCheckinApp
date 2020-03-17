using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSessionToggleItem : MonoBehaviour
{
    public string gameID { get; private set; }
    public string gameTime { get; private set; }
    public string gameStatus { get; private set; }

    [SerializeField]
    private Toggle m_toggle;
    public Toggle toggle { get { return m_toggle; } }

    [SerializeField]
    private Text m_gameTimeText;

    public void Init(string _gameID, string _gameTime, string _gameStatus, ToggleGroup toggleGroup)
    {
        gameID = _gameID;
        gameTime = _gameID;
        gameStatus = _gameStatus;
        toggle.group = toggleGroup;

        m_gameTimeText.text = _gameTime;
    }
}
