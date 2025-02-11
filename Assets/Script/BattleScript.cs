using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

public class BattleScript
{
    //private Action<PeopleInfo> updateUI;
    public static void StartBattle(Characters _Characters, Monster _monster)
    {
        // 邏輯順序為
        // hero and monster 
        // hero 先被攻擊 on motsters to attack
        // 可以判斷怪物 再放入音效
        
        while (_Characters != null && _monster != null)
        {
            _Characters.HP = _Characters.HP - (_monster.AttackPower - _Characters.Defense);
            Debug.Log(_Characters.HP);
            if (_Characters.HP <= 0)
            {
               
                return;
            }
            _monster.HP = _monster.HP - (_Characters.AttackPower - _monster.Defense);
            Debug.Log(_monster.HP);
            if (_monster.HP <= 0)
            {
                _Characters.MagicMoney += _monster.MagicMoney;
                _Characters.Experience_Value += _monster.Experience_Value;
                _monster.Die();

                return;
            }
        }
    }
}
