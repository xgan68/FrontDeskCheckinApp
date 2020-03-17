using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreGameState : FSMState
{
    public PreGameState(int _id, FSMSystem _fsmSystem) : base(_id, _fsmSystem) { }

    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();
        AppFacade.instance.SendNotification(Const.Notification.CHECK_USER_INFO_EXIST);
        AppFacade.instance.SendNotification(Const.Notification.SETUP_CONNECTION_WITH_SERVER);
        Debug.Log("Enter Pre game State");
    }
}
