using System;
using UnityEngine;


// 製造一個箱子 將全部素材匯入進去
[Serializable]
public class PeopleInfo
{
    //血量
    public int hp;
    //攻擊力
    public int attackPower;
    //防禦力
    public int defense;
    //敏捷
    public int agile;
    //經驗
    public int experience_Value;

    //等級
    public int lvevl;
    public int yellowKey;
    public int blueKey;
    public int redKey;
    public int magicMoney;
    //樓層
    public int currentFloor;
    //
    public Vector3 peoplepositionStats;
}

