using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabs;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    private TabButton selected;
    private OptionWindowManager optionManager;
    private void Awake()
    {
        optionManager = GetComponent<OptionWindowManager>();
        OnTabEnter(tabs[0]);
    }
    public void OnTabHover(TabButton tab)
    {
        if (selected == tab) return;
        tab.background.sprite = tabHover;
    }
    public void OnTabEnter(TabButton tab)
    {
        if (selected == tab) return;
        if (selected != null) selected.background.sprite = tabIdle;
        selected = tab;
        tab.background.sprite = tabActive;
        optionManager.SetWindowData(tabs.IndexOf(selected));
    }
    public void OnTabExit(TabButton tab)
    {
        if (selected != tab) tab.background.sprite = tabIdle;
    }
}
