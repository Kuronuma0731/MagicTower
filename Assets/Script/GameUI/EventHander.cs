using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static UnityEngine.ParticleSystem;
public class EventHander
{
    
    public static event Action<PeopleInfo> UpdateUiEvent;
    //更新UI 更新腳色本身
    public static void CallUpdateUiEvent(PeopleInfo peopleInfo)
    {
        UpdateUiEvent?.Invoke(peopleInfo);
    }
    public static Action<Article, ArticleDetail> UpdateArticleUIEvent;
    //更新鑰匙UI
    public static void CallUpdateArticleUIEvent(Article article, ArticleDetail articleDetail)
    {
        UpdateArticleUIEvent?.Invoke(article, articleDetail);
    }
    
    public static event Action<string> UpdateMessageEvent;
    public static void CallUpdateMessageEvent(string message)
    {
        UpdateMessageEvent?.Invoke(message);
    }
    public static event Action UpdateBattleEvent;
    public static void CallUpdateBattleEvent()
    {
        UpdateBattleEvent?.Invoke();
    }
    public static event Action<PeopleInfo, Monster> UpdateBattleUIEvent;
    public static void CallUpdateBattleUIEvent(PeopleInfo ch, Monster monster)
    {
        UpdateBattleUIEvent?.Invoke(ch, monster);
    }
}
