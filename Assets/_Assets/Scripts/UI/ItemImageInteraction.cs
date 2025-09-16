using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemImageInteraction : MonoBehaviour, IPointerClickHandler
{
    private Sprite img;
    private string nameItem;
    private string descriptionItem;
    public void OnPointerClick(PointerEventData eventData)
    {
        OptionWindowManager.Instance.ShowDescriptionPanel(img, nameItem, descriptionItem);       
    }
    public void Set(Sprite img, string nameItem, string descriptionItem)
    {
        this.img = img;
        this.nameItem = nameItem;
        this.descriptionItem = descriptionItem;
    }
}
