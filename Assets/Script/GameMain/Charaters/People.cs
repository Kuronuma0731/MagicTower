using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public PeopleInfo peopleInfo;
    [SerializeField] private int number_Of_Attacks;
    // 屬性公開讀取與設定

    public int HP
    {
        get => peopleInfo.hp;
        set => peopleInfo.hp = Mathf.Max(0, value); // HP 不可低於 0
    }

    public int AttackPower
    {
        get => peopleInfo.attackPower;
        set => peopleInfo.attackPower = value;
    }


    public int Defense
    {
        get => peopleInfo.defense;
        set => peopleInfo.defense = value;
    }
    public int Agile
    {
        get => peopleInfo.agile;
        set => peopleInfo.agile = value;
    }

    public int Experience_Value
    {
        get => peopleInfo.experience_Value;
        set => peopleInfo.experience_Value = value;
    }


    public int Number_Of_Attacks
    {
        get => number_Of_Attacks;
        set => number_Of_Attacks = value;
    }

    public int Lv
    {
        get => peopleInfo.lvevl;
        set => peopleInfo.lvevl = value;
    }

    public int YellowKey
    {
        get => peopleInfo.yellowKey;
        set => peopleInfo.yellowKey = value;
    }

    public int BlueKey
    {
        get => peopleInfo.blueKey;
        set => peopleInfo.blueKey = value;
    }

    public int RedKey
    {
        get => peopleInfo.redKey;
        set => peopleInfo.redKey = value;
    }
    public int MagicMoney
    {
        get => peopleInfo.magicMoney;
        set => peopleInfo.magicMoney = value;
    }
    public Vector3 PeoplepositionStats
    {
        get => peopleInfo.peoplepositionStats;
        set => peopleInfo.peoplepositionStats = value;
    }
    public int CurrentFloor 
    {
        get => peopleInfo.currentFloor;
        set => peopleInfo.currentFloor = value;
    }
    public virtual void Die()
    {

    }
    public virtual void CloseObject(string ObjectName, Characters _Characters)
    {
        //Destroy(this.gameObject);


    }
}
