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
        InitMainFSMSystem();
    }

    public void ChangeMainFSMState(MainFSMStateID _stateID)
    {
        m_fsmSystem.PerformTransition((int)_stateID);
    }

    private void InitMainFSMSystem()
    {
        m_fsmSystem = new FSMSystem();

        FSMState loginState = new LoginState((int)MainFSMStateID.LoginState, m_fsmSystem);
        loginState.AddTransition((int)MainFSMTransition.InGame, (int)MainFSMStateID.InGame);
        loginState.AddTransition((int)MainFSMTransition.PreGame, (int)MainFSMStateID.PreGame);
        loginState.AddTransition((int)MainFSMTransition.Login, (int)MainFSMStateID.LoginState);
        loginState.AddTransition((int)MainFSMTransition.EndGame, (int)MainFSMStateID.EndGame);
        m_fsmSystem.AddState(loginState);

        FSMState InGame = new InGameState((int)MainFSMStateID.InGame, m_fsmSystem);
        InGame.AddTransition((int)MainFSMTransition.PreGame, (int)MainFSMStateID.PreGame);
        InGame.AddTransition((int)MainFSMTransition.Login, (int)MainFSMStateID.LoginState);
        InGame.AddTransition((int)MainFSMTransition.EndGame, (int)MainFSMStateID.EndGame);
        m_fsmSystem.AddState(InGame);

        FSMState PreGame = new PreGameState((int)MainFSMStateID.PreGame, m_fsmSystem);
        PreGame.AddTransition((int)MainFSMTransition.InGame, (int)MainFSMStateID.InGame);
        PreGame.AddTransition((int)MainFSMTransition.Login, (int)MainFSMStateID.LoginState);
        PreGame.AddTransition((int)MainFSMTransition.EndGame, (int)MainFSMStateID.EndGame);
        m_fsmSystem.AddState(PreGame);

        FSMState EndGame = new EndGameState((int)MainFSMStateID.EndGame,m_fsmSystem);
        EndGame.AddTransition((int)MainFSMTransition.EndGame, (int)MainFSMStateID.EndGame);
        EndGame.AddTransition((int)MainFSMTransition.Login, (int)MainFSMStateID.LoginState);
        m_fsmSystem.AddState(EndGame);

        m_fsmSystem.PerformTransition((int)MainFSMStateID.LoginState);
    }
}
