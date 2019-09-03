using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BindSuccessUI : AUIPage
{
    public void OnScreenTouched()
    {
        GameManager.Instance.ReInitiate();
    }
}
