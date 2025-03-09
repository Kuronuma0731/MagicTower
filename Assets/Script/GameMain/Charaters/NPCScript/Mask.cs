using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    private int SaveMoney = 20;

    public int MaskMoney { get { return SaveMoney; } set { SaveMoney = Math.Max(value, 0); } }


    // Start is called before the first frame update
    [SerializeField] private int Floor;
    //
    [SerializeField] private SpriteRenderer _Mask; //針對照片更改
    [SerializeField] private Sprite[] SaveMaskImageSprite; //存照片用參數
    void Start()
    {
        MaskInit();
    }

    void MaskInit()
    {
        Debug.Log(Floor);
        if (SaveMaskImageSprite != null)
        {
            if (Floor == 3)
            {
                _Mask.sprite = SaveMaskImageSprite[0];
            }
            else
            {
                _Mask.sprite = SaveMaskImageSprite[1];
            }
        }
    }
}
