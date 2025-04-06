using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class MonsterNumericalValue : MonoBehaviour
{
    [SerializeField] List<MonsterDetails> monsterDetails = new List<MonsterDetails>();

    //生命 ,攻擊力,防禦力,敏捷,經驗 ,攻擊次數, 怪物身上的錢
    [SerializeField] private static Dictionary<MonsterName, MonsterDetails> monsterStats =
        new Dictionary<MonsterName, MonsterDetails>();


    private void Awake()
    {
        getMonsterSetUp();
    }

    
    // get Monster Stats 
    public static void SetMonsterStats(MonsterName name, Monster monster,Sprite monsterSprite)
    {
        if (monsterStats.ContainsKey(name))
        {
            //預設是沒有照片，添加Monster掛載上的照片
            monsterStats[name].itemSprite = monsterSprite;
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
    // awake 馬上更新
    private void getMonsterSetUp()
    {

        monsterDetails = monsterData.Select(data => new MonsterDetails
        {
            monsterName = data.monsterName,
            hp = data.hp,
            attack = data.attack,
            defense = data.defense,
            agile = data.agile,
            Experience_Value = data.experience,
            Money = data.money,
            Mumber_Of_Attacks = data.attackNumber
        }).ToList();

        foreach (var Item in monsterDetails)
        {
            if (!monsterStats.ContainsKey(Item.monsterName))
            {
                monsterStats.Add(Item.monsterName, Item);
            }
        }
    }
    // 建立怪物資料陣列 (元組)，第一個欄位改為 MonsterName 列舉
    private (MonsterName monsterName, int hp, int attack, int defense, int agile, int experience, int attackNumber, int money)[] monsterData =
    {
    // Slime
    (MonsterName.GreenSlime, 45, 18, 1, 1, 1, 1, 1),
    (MonsterName.RedSlime,   66, 20, 4, 2, 1, 1, 2),
    (MonsterName.BlackSlime, 80, 37, 9, 0, 1, 1, 5),
    (MonsterName.SlimeKing,  172,130,60,2, 2, 1,19),

    // Bat
    (MonsterName.SmallBat, 45, 32, 2, 4, 1, 1, 3),
    (MonsterName.BigBat,   66, 55, 4, 2, 1, 2, 6),
    (MonsterName.RedBat,   210,185,70,4, 3, 3,23),

    // Majician
    (MonsterName.BlueMajician, 70, 10, 5, 0, 1, 1, 4),

    // Zombie
    (MonsterName.Zombie, 190, 90, 33, 2, 2, 1, 4),

    // Guard
    (MonsterName.YellowGuard, 85, 40, 55, 3, 6, 1, 6),
    (MonsterName.BlueGuard, 775, 220, 310, 3, 7, 1, 64),
    (MonsterName.RedGuard, 190, 90, 33, 2, 2, 1, 4),

    // Kinght
    (MonsterName.YellowKinght, 130, 115, 43, 3, 2, 1, 17),
    (MonsterName.BlueKinght, 775, 220, 310, 3, 7, 1, 64),
    (MonsterName.RedKinght, 190, 90, 33, 2, 2, 1, 4),

    // Rock
    (MonsterName.StoneRock, 30, 45, 70, 0, 1, 1, 7),
    (MonsterName.IceRock, 775, 220, 310, 3, 7, 1, 64),

    // SwordMan
    (MonsterName.SwordMan, 280, 210, 110, 4, 4, 1, 34),

    // Skeleton
    (MonsterName.Skeleton, 95, 70, 0, 0, 1, 1, 5),
    (MonsterName.SketetonSwordMan, 190, 100, 5, 3, 2, 1, 13),
    (MonsterName.MedievalSkeletonSwordsman, 290, 170, 23, 3, 2, 1, 21)
    };
    public enum MonsterName
    {
        GreenSlime,
        RedSlime,
        BlackSlime,
        SlimeKing,
        SlimeMan,
        SmallBat,
        BigBat,
        RedBat,
        ajician,
        BlueMajician,
        YellowMajician,
        RedMajician,
        Zombie,
        YellowGuard,
        BlueGuard,
        RedGuard,
        YellowKinght,
        BlueKinght,
        RedKinght,
        StoneRock,
        IceRock,
        SwordMan,
        Skeleton,
        SketetonSwordMan,
        MedievalSkeletonSwordsman
    }

    [SerializeField]
    public class MonsterDetails
    {
        public MonsterName monsterName;
        public Sprite itemSprite;
        public int hp;
        public int attack;
        public int defense;
        public int agile;
        public int Experience_Value;
        public int Mumber_Of_Attacks;
        public int Money;
    }




}