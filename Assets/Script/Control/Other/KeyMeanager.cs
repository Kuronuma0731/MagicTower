using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class KeyMeanager : MonoBehaviour
{
    [SerializeField] List<ArticleDetail> ItemArticle = new List<ArticleDetail>();

    private Dictionary<Article, ArticleDetail> itemarticle = new Dictionary<Article, ArticleDetail>();


    public void Awake()
    {
        foreach (var item in ItemArticle)
        {
            if (!itemarticle.ContainsKey(item.article))
            {
                itemarticle.Add(item.article, item);
            }
        }
    }
    public void AddMoney(Article article, int Money)
    {
        if (itemarticle.ContainsKey(article))
        {
            itemarticle[article].Count += Money;
            string GetKeyMessage = $"獲得金錢 + {Money} ";
            EventHander.UpdateArticleUIEvent(article, itemarticle[article]);
        }
        else
        {
            Debug.LogWarning($"KeyMeanager 中未找到 {article} 金錢資料！");
        }
    }
    //更新鑰匙
    public void AddArticle(Article article)
    {
        if (itemarticle.ContainsKey(article))
        {
            itemarticle[article].Count++;
            string GetKeyMessage = $"獲得鑰匙 + {1} ";
            //Debug.Log(itemarticle[article].Count);
            // 若需要更新英雄 UI 或資料，可透過事件或直接呼叫 HeroInventory 來更新
            // 例如：HeroInventory.Instance.UpdateKeyUI(key, keyDictionary[key].count);
            EventHander.UpdateArticleUIEvent(article, itemarticle[article]);
            EventHander.CallUpdateMessageEvent(GetKeyMessage);
        }
        else
        {
            Debug.LogWarning($"KeyMeanager 中未找到 {article} 鑰匙資料！");
        }
    }
    public bool DeleteArticle(Article article)
    {
        if (itemarticle.ContainsKey(article) && itemarticle[article].Count > 0)
        {
            itemarticle[article].Count--;
            string GetKeyMessage = $"失去 {article} ";
            //Debug.Log(itemarticle[article].Count);
            // 若需要更新英雄 UI 或資料，可透過事件或直接呼叫 HeroInventory 來更新
            // 例如：HeroInventory.Instance.UpdateKeyUI(key, keyDictionary[key].count);
            EventHander.UpdateArticleUIEvent(article, itemarticle[article]);
            //EventHander.CallUpdateMessageEvent(GetKeyMessage);
            return true;
        }
        else
        {
            if (itemarticle[article].Count == 0)
            {
                Debug.LogWarning($"KeyMeanager 中未找到 {article} 鑰匙資料！");
            }
            return false;
        }
    }
}
