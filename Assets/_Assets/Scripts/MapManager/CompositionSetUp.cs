using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositionSetUp : MonoBehaviour
{
    public SpriteRenderer bg1;
    public SpriteRenderer bg2;
    public SpriteRenderer foregroundPrefab;
    public int numberFG;
    private List<SpriteRenderer> fgs = new();
    private void Awake()
    {
        for (int i = 0; i < numberFG; i++)
        {
            SpriteRenderer fg = CreateSR();
            fgs.Add(fg);
        }
    }
    public void SetBG(Sprite spr1, Sprite spr2)
    {
        bg1.sprite = spr1;
        bg2.sprite = spr2;
    }
    public void SetFG(List<ForeGround> foreGrounds)
    {
        for (int i = 0; i < foreGrounds.Count; i++)
        {
            if (i >= fgs.Count) CreateSR();
            fgs[i].sprite = foreGrounds[i].sprite;
            fgs[i].transform.position = foreGrounds[i].position;
            fgs[i].gameObject.SetActive(true);
        }
    }
    private SpriteRenderer CreateSR()
    {
        SpriteRenderer fg = Instantiate(foregroundPrefab, transform);
        fg.gameObject.SetActive(false);
        return fg;
    }
}
