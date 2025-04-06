using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;
using static UnityEngine.EventSystems.EventTrigger;

public class BattleManager : MonoBehaviour
{
    // 動畫延遲時間，可依需求調整
    [SerializeField] private float animationDelay = 0.1f;
    // 取得鑰匙物件
    [SerializeField] private KeyMeanager keyMeanager; 
    public void StartBattle(Characters characters, Monster monster)
    {
        //進入戰鬥特效
        StartCoroutine(BattleCoroutine(characters, monster));
    }
    IEnumerator BattleCoroutine(Characters characters, Monster monster)
    {
        characters.SetCanMove(true);
        int round = 1;
        while (characters != null && monster != null)
        {
            Debug.Log("回合 " + round + " 開始");

            // 若敵人血量歸零則結束戰鬥
            if (monster.HP <= 0)
            {
                MonsterDie(characters,monster);
                break;
            }

            // 玩家攻擊回合
            yield return StartCoroutine(AttackChAnimation(characters.peopleInfo, monster.peopleInfo));
            EventHander.CallUpdateBattleUIEvent(characters.peopleInfo, monster);
           
            if (characters.HP <= 0)
            {
                CharactersDie(characters);   
                break;
            }
            // 敵人攻擊回合
            yield return StartCoroutine(AttackMonsterAnimation(monster.peopleInfo, characters.peopleInfo));
            EventHander.CallUpdateBattleUIEvent(characters.peopleInfo, monster);
            round++;
            // 回合結束後的延遲，可用於顯示回合結束動畫或資訊
            yield return new WaitForSeconds(animationDelay);
        }
        //return null;
    }
    //腳色攻擊
    IEnumerator AttackChAnimation(PeopleInfo Attack, PeopleInfo NotAttack)
    {
        // 播放攻擊動畫
        //if (attacker.animator)
        //{
        //    attacker.animator.SetTrigger("Attack");
        //}
        // 等待動畫播放
        yield return new WaitForSeconds(animationDelay);

        // 計算傷害，至少造成 1 點傷害
        int damage = Mathf.Max(1, Attack.attackPower - NotAttack.defense);
        NotAttack.hp -= damage;
        
        //Debug.Log(defender.characterName + " 受到 " + damage + " 點傷害，剩餘 HP：" + defender.hp);

        // 可在這裡觸發受傷動畫或數值浮動效果
        //if (monster.animator)
        //{
        //    monster.animator.SetTrigger("Hit");
        //}
        
        yield return new WaitForSeconds(animationDelay);
    }
    // 怪物攻擊
    IEnumerator AttackMonsterAnimation(PeopleInfo Attack, PeopleInfo NotAttack)
    {
        //Debug.Log(charactersPeopleInfo. + " 發起攻擊！");

        // 播放攻擊動畫
        //if (attacker.animator)
        //{
        //    attacker.animator.SetTrigger("Attack");
        //}
        // 等待動畫播放
        yield return new WaitForSeconds(animationDelay);

        // 計算傷害，至少造成 1 點傷害
        int damage = Mathf.Max(1, Attack.attackPower - NotAttack.defense);
        NotAttack.hp -= damage;

        //Debug.Log(defender.characterName + " 受到 " + damage + " 點傷害，剩餘 HP：" + defender.hp);

        // 可在這裡觸發受傷動畫或數值浮動效果
        //if (monster.animator)
        //{
        //    monster.animator.SetTrigger("Hit");
        //}

        yield return new WaitForSeconds(animationDelay);
    }

    //怪物死亡
    private void MonsterDie(Characters characters, Monster monster) 
    {
        Debug.Log(monster.name + " 被擊敗！");
        //更新金錢
        keyMeanager.AddMoney(Article.MegicMoney, monster.MagicMoney);
        //更新經驗值
        characters.peopleInfo.experience_Value += monster.Experience_Value;
        characters.SetCanMove(false);
        monster.Die();
        //更新 腳色UI
        EventHander.CallUpdateUiEvent(characters.peopleInfo);
    }
    private void CharactersDie(Characters characters)
    {
        //Debug.Log(characters.name + " 被擊敗！");
        // 彈跳出來 死亡訊息 並跳出是否重新開始
        //更新 腳色UI
        EventHander.CallUpdateUiEvent(characters.peopleInfo);
    }
}
