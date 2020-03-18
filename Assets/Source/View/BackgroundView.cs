using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BackgroundView : UIViewBase
{
    [SerializeField]
    private Image m_backgroundImage;
    private ModeConfigsProxy m_modeConfigProxy;

    private void Awake()
    {
        m_modeConfigProxy = AppFacade.instance.RetrieveProxy(ModeConfigsProxy.NAME) as ModeConfigsProxy;
    }

    public override void Show()
    {
        base.Show();

        Color color = m_modeConfigProxy.GetCurrentModeConfigVO().backgroundColor;
        m_backgroundImage.color = color;
    }


}
