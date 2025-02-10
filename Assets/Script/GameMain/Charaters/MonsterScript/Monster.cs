using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : People
{

    [SerializeField] private string MonsterName;

    private void Start()
    {
        MonsterNumericalValue.SetMonsterStats(MonsterName, this);
    }
    public override void Die() 
    {
        //base.Die();
        Destroy(gameObject);
    }
}
