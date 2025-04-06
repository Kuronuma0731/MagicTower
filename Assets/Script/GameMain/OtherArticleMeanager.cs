using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherArticleMeanager : MonoBehaviour
{
    [SerializeField] private OtherArticle otherArticle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Charaters")
        {
            Characters characters = collision.GetComponent<Characters>();
            if (characters != null)
            {
                AddOtherArticle(otherArticle, characters);
                Debug.Log("Update Character Data");
            }
        }
    }


    public void AddOtherArticle(OtherArticle otherArticle, Characters characters)
    {
        string message = "";
        switch (otherArticle)
        {
            case OtherArticle.Hp_Potion:
                characters.HP += 150;
                message = $"獲得藥瓶 增加150點生命";
                break;
            case OtherArticle.Defens_Potion:
                characters.HP += 400;
                message = $"獲得藥瓶 增加400點生命";
                break;
            case OtherArticle.Aglie_Potion:
                characters.Agile += 2;
                message = $"獲得藥瓶 增加2點敏捷";
                break;
            case OtherArticle.Attack_MagicGems:
                characters.AttackPower += 2;
                message = $"獲得攻擊寶石 增加2點攻擊";
                break;
            case OtherArticle.Defens_MagicGems:
                characters.Defense += 2;
                message = $"獲得防禦寶石 增加2點防禦";
                break;
            case OtherArticle.Aglie_MagicGems:
                // 還不確定
                break;
        }
        //更新UI
        EventHander.CallUpdateUiEvent(characters.peopleInfo);
        //更新需要的訊息
        EventHander.CallUpdateMessageEvent(message);
        Destroy(gameObject);
    }
}
