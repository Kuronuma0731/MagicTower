using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public class PlayMonster : People
{
    [SerializeField] private string monsterType; 

    private void Start()
    {
       
    }
   

    //Update is called once per frame
    void Update()
    {
        Debug.Log(HP);
    }
    void checkHealth()
    {
        //Monster monster = monsterPlanner.GetMonsterStats(this.tag);
        //if (monster.HP <= 0)
        //{
        //    monster.CheckHealth();
        //    //  Destroy(gameObject);
        //}
    }
}
