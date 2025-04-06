using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MonsterNumericalValue;

public class Monster : People 
{

    [SerializeField] private MonsterName MonsterName;
    [SerializeField] private Sprite monsterSprite;

    private void Start()
    {
        //取得自身身上數值
        MonsterNumericalValue.SetMonsterStats(MonsterName, this, monsterSprite);
    }
    public override void Die() 
    {
        Destroy(gameObject);
    }   
}
