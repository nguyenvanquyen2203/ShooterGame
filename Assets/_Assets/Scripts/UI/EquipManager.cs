using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipManager : MonoBehaviour
{
    public List<EquipLoad> equipBtn;
    public void ChangeWindow(int numberEquipLoad)
    {
        for (int i = 0; i < numberEquipLoad; i++)
        {
            equipBtn[i].gameObject.SetActive(true);
        } 
        for (int i = numberEquipLoad; i < equipBtn.Count; i++) equipBtn[i].gameObject.SetActive(false);
    }
}
