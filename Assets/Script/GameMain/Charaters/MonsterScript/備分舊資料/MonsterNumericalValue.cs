using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using characters;
// 其他怪物類型可以依此擴展
public class MonsterNumericalValuess
{
    private static Dictionary<string, (int hp, int attack, int defense)> monsterData =
        new Dictionary<string, (int, int, int)>()
        {
            { "GreenSlime", (50, 10, 5) },
            { "RedSlime", (80, 15, 8) },
            { "BlueSlime", (100, 20, 10) }
        };

    public static (int hp, int attack, int defense) GetMonsterValues(string monsterName)
    {
        if (monsterData.ContainsKey(monsterName))
            return monsterData[monsterName];

        Debug.LogWarning($"Monster {monsterName} not found!");
        return (0, 0, 0);
    }
    //public PlayMonster GetMonsterStats(string monsterName)
    //{
    //
    //    Debug.Log(monsterName);
    //    switch (monsterName)
    //    {
    //        case "GreenSlime":
    //            //Debug.Log(3);
    //            
    //            //playMonster.HP = 45;
    //            //playMonster.AttackPower = 10;
    //            //playMonster.Defense = 10;
    //            //playMonster.Agile = 1;
    //            //playMonster.ExperienceValue = 1;
    //            //playMonster.NumberOfAttacks = 1;
    //            return new PlayMonster(monsterName, 45, 10, 10, 1, 1, 1);
    //
    //
    //        // 其他怪物類型可以依此擴展
    //        // case "RedSlime":
    //        //     return new Monster { ... };
    //
    //        default:
    //            Debug.LogWarning($"Monster with name {monsterName} not found.");
    //            return null; // 或者返回一個預設的 Monster
    //    }
    //}

    public void str() 
    {
        Debug.Log("123");
    }
}
