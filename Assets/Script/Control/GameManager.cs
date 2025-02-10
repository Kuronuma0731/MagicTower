using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Characters characters;

   // delegate    回呼  callback 
   // Action    Action<int>   Func<int,int>
   //Action 不一定需要傳值進去 但一定沒有回傳
   // func<int,string> 傳 任何東西進去 int , return string (任何東西出來)
    void Start()
    {
        characters.Init(uiManager.UpdateStatusUI);
    }



}
