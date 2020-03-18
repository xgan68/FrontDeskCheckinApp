using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MainFSMStateID
{
    NullState = FSMState.NULL_STATE_ID,
    LoginState,
    PreGame,
    InGame,
    EndGame
}

public enum MainFSMTransition
{
    NullState = FSMState.NULL_STATE_ID,
    Login,
    PreGame,
    InGame,
    EndGame
}

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    private FSMSystem m_fsmSystem;

    public static GameManager instance
    {
        get
        {
            return m_instance;
        }
    }

    void Start()
    {
        m_instance = this;
        DontDestroyOnLoad(this.gameObject);
        AppFacade.instance.startup();
    }
}
