using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup group;
    public Image background;
    public void OnPointerClick(PointerEventData eventData)
    {
        group.OnTabEnter(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        group.OnTabHover(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        group.OnTabExit(this);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        background = GetComponent<Image>();
    }
}
