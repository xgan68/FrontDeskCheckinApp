using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BindSuccessUI : AUIPage
{
    public override void Show()
    {
        base.Show();
    }

    public void OnScreenTouched()
    {
        GameManager1.Instance.ReInitiate();
    }
}
