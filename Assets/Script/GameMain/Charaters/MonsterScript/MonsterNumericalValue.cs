using System.Collections.Generic;
using UnityEngine;

public static class MonsterNumericalValue
{
    //生命 ,攻擊力,防禦力,敏捷,經驗 ,攻擊次數, 怪物身上的錢
    private static Dictionary<string, (int hp, int attack, int defense, int agile, int Experience_Value, int Mumber_Of_Attacks, int Money)> monsterStats =
        new Dictionary<string, (int, int, int, int, int, int, int)>
        {

            //Slime
            { "GreenSlime", (45, 10, 2, 1, 1, 1,1) },
            { "RedSlime", (66, 20, 4, 2, 1, 1,2) },
            { "BlackSlime", (80, 37, 9, 0, 1, 1,5) },
            { "SlimeKing", (172, 130, 60, 2, 2, 1,19) },
            //Bat
            { "SmallBat", (45, 32, 2, 4, 1, 1,3) },
            { "BigBat", (66, 55, 4, 2, 1, 2,6) },
            { "RedBat", (210, 185, 70, 4, 3, 3,23) },
            //Majician
            { "BlueMajician", (70, 10, 5, 0, 1, 1,4) },

            //Zombie
            { "Zombie", (190, 90, 33, 2, 2, 1,4) },
            //Guard
            { "YellowGuard", (85, 40, 55, 3, 6, 1,6) },
            { "BlueGuard", (775, 220, 310, 3, 7, 1,64) },
            { "RedGuard", (190, 90, 33, 2, 2, 1,4) },
            //Kinght
            { "YellowKinght", (130, 115, 43, 3, 2, 1,17) },
            { "BlueKinght", (775, 220, 310, 3, 7, 1,64) },
            { "RedKinght", (190, 90, 33, 2, 2, 1,4) },
            //Rock
            { "StoneRock", (30, 45, 70, 0, 1, 1,7) },
            { "IceRock", (775, 220, 310, 3, 7, 1,64) },
            
            //SwordMan
            { "SwordMan", (280, 210, 110, 4, 4, 1,34) },
            //Sketeton
            { "Skeleton", (95, 70, 0, 0, 1, 1,5) },
            { "SketetonSwordMan", (190, 100, 5, 3, 2, 1,13) },
            { "MedievalSketetonSwordMan", (290, 170, 23, 3, 2, 1,21) },
            //
        };

    // get Monster Stats 
    public static void SetMonsterStats(string name, Monster monster)
    {
        //int Gren =  (int)MonsterNumber.GreenSlime;
        //name = "GreenSlime";
        //Debug.Log($"未定義的怪物名稱: {name}");
        if (monsterStats.ContainsKey(name))
        {
            //Debug.Log($"未定義的怪物名稱: {name}");
            var stats = monsterStats[name];
            monster.HP = stats.hp;
            monster.AttackPower = stats.attack;
            monster.Defense = stats.defense;
            monster.Agile = stats.agile;
            monster.Experience_Value = stats.Experience_Value;
            monster.Number_Of_Attacks = stats.Mumber_Of_Attacks;
            monster.MagicMoney = stats.Money;
        }
        else
        {
            Debug.LogError($"未定義的怪物名稱: {name}");
        }
    }


    private enum MonsterNumber
    {
        GreenSlime = 1,
        RedSlime = 2,
        Zombie = 3
    }
}