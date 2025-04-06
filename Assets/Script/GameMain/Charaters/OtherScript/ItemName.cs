using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public enum ItemName { 

    Other,
    Key,
    Door,
    Potion,
    Sword,
    Shield,
    MagicGams
}
// key 
public enum Article
{
    YellowKey,
    BlueKey,
    RedKey,
    MegicMoney
}

public enum OtherArticle
{
    Attack_MagicGems,
    Defens_MagicGems,
    Aglie_MagicGems,
    Hp_Potion,
    Defens_Potion,
    Aglie_Potion,
}
[Serializable]
public class ArticleDetail
{
    public Article article;
    public int Count;
    public Sprite itemSprite;
}

