using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public abstract class UIFormBase : MonoBehaviour
{
    [SerializeField]
    protected string m_formName;
    public string formName { get { return m_formName; } }
    [SerializeField]
    protected List<ViewInfo> m_uiViewInfos;
    
    protected readonly Stack<UIViewBase> m_viewStack = new Stack<UIViewBase>();
    protected readonly HashSet<UIViewBase> m_loadUiViews = new HashSet<UIViewBase>();
    protected virtual void Start()
    {
        InitForm();
    }

    public virtual void Show()
    {
        this.gameObject.SetActive(true);
        foreach (var uiView in m_loadUiViews)
        {
            uiView.Show();
        }
    }

    public virtual void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void LoadView(UIViewBase m_uiViewBase)
    {
        if (!m_loadUiViews.Contains(m_uiViewBase))
        {
            m_loadUiViews.Add(m_uiViewBase);
            m_uiViewBase.Show();
        }
        else
        {
            m_uiViewBase.Show();
        }
    }

    public virtual void HideTopView()
    {
        if (m_viewStack.Count > 0)
        {
            m_viewStack.Pop().Hide();
        }
    }

    public virtual void Anchor(float _x, float _y, float _z)
    {
        this.transform.localPosition = new Vector3(_x, _y, _z);
    }

    /*
    protected virtual void LoadView(string _uiViewName)
    {
        ResourcesService resourcesService = new ResourcesService();
        GameObject viewGO = resourcesService.Load<GameObject>(_uiViewName);

        Addressables.InstantiateAsync(_uiViewName).Completed += OnViewInstantiated;

    }
    */

    protected virtual void InitForm()
    {
        foreach (ViewInfo viewInfo in m_uiViewInfos)
        {
            if (viewInfo.layer == UIViewLayer.Background)
            {
                viewInfo.uiView.InstantiateAsync().Completed += OnBackGroundViewInstantiated;
            }
            else if (viewInfo.layer == UIViewLayer.Content)
            {
                viewInfo.uiView.InstantiateAsync().Completed += OnContentViewInstantiated;
            }
        }
    }

    protected virtual void OnBackGroundViewInstantiated(AsyncOperationHandle<GameObject> _obj)
    {
        UIViewBase uiView = _obj.Result.GetComponent<UIViewBase>();
        uiView.transform.SetParent(this.transform);
        uiView.transform.SetAsFirstSibling();
        uiView.Anchor(0, 0, 0);
        LoadView(uiView);
    }

    protected virtual void OnContentViewInstantiated(AsyncOperationHandle<GameObject> _obj)
    {
        UIViewBase uiView = _obj.Result.GetComponent<UIViewBase>();
        uiView.transform.SetParent(this.transform);
        uiView.Anchor(0, 0, 0);
        LoadView(uiView);
    }
}

[System.Serializable]
public class ViewInfo
{
    [SerializeField]
    private AssetReference m_uiView;
    public AssetReference uiView { get { return m_uiView; } }
    [SerializeField]
    private UIViewLayer m_layer;
    public UIViewLayer layer { get { return m_layer; } }
}

public enum UIViewLayer
{ 
    Background,
    Content
}