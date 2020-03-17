using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : FSMState
{
    public EndGameState(int _id, FSMSystem _fsmSystem) : base(_id, _fsmSystem) { }
    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();
        AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_FORM,Const.UIFormNames.GIVE_LIKE_FORM);
    }
}

