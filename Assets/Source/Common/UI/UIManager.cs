using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class UIManager : MonoBehaviour
{
    private static UIManager m_instance;

    private readonly Dictionary<string, UIFormBase> m_loadedForms = new Dictionary<string, UIFormBase>();
    private readonly Stack<string> m_openedForms = new Stack<string>();

    [SerializeField]
    private Transform m_UIContentRoot;
    [SerializeField]
    private Transform m_UIPopupRoot;
    [SerializeField]
    private WarningPopupView m_warningPopupView;

    private string m_currentFormName = "";
    private GameObject m_uiRoot;
    private string m_homeFormName;
    
    public static UIManager instance { get { return m_instance; } }
    
    void Awake()
    {
        DontDestroyOnLoad(this);

        m_instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void ShowLastOpenedForm()
    {
        if (m_openedForms.Count > 0)
        {
            m_loadedForms[m_currentFormName].Hide();
            m_currentFormName = m_openedForms.Pop();
            m_loadedForms[m_currentFormName].Show();
        }
    }

    public void ShowForm(string _formName, bool _isRoot)
    {
        if (m_loadedForms.ContainsKey(m_currentFormName))
        {
            m_openedForms.Push(m_currentFormName);
            m_loadedForms[m_currentFormName].Hide();
        }

        if (_isRoot)
        {
            m_openedForms.Clear();
            m_homeFormName = _formName;
        }

        m_currentFormName = _formName;

        if (!m_loadedForms.ContainsKey(_formName))
        {
            LoadForm(_formName);
        }
        else
        {
            m_loadedForms[m_currentFormName].Show();
        }
    }

    public void ShowHomeForm()
    {
        if (m_homeFormName != null)
        {
            ShowForm(m_homeFormName, true);
        }
    }

    public void PopWarning(PopupWarningVO _vo)
    {
        m_warningPopupView.Show();
        m_warningPopupView.UpdatePopupwarningVO(_vo);
    }
    
    private void LoadForm(string _formName)
    {
        Addressables.InstantiateAsync(_formName).Completed += OnFormInstantiated;
    }

    private void OnFormInstantiated(AsyncOperationHandle<GameObject> _obj)
    {
        UIFormBase form = _obj.Result.GetComponent<UIFormBase>();
        form.transform.SetParent(m_UIContentRoot, false);
        form.Anchor(0, 0, 0);

        form.Show();
        m_loadedForms.Add(form.formName, form);
    }
}
