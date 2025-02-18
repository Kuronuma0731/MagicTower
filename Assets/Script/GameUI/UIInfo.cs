
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UIInfo 
{
    public Text FloorText; // Text 上的數據顯示
    public Text LvText;
    public Text HpText; // Text 上的數據顯示
    public Text AttackPowerText; // Text 上的數據顯示
    public Text DefenseText; // Text 上的數據顯示
    public Text AgileText; // Text 上的數據顯示
    public Text Experience_ValueText; // Text 上的數據顯示
    public Text YellowKey_Text; // Text 上的數據顯示
    public Text BlueKeyText; // Text 上的數據顯示
    public Text RedKeyText; // Text 上的數據顯示
    public Text MoneyText; // Text 上的數據顯示
    public Text GetMessage; // Text 上的數據顯示


    // 戰鬥數值顯示 
    // 怪物顯示
    public Text BattleM_Name;
    public Text BattleM_Hp;
    public Text BattleM_Attack;
    public Text BattleM_Den;
    public Text BattleM_Aglie;
    //腳色顯示
    public Text BattleCh_Name;
    public Text BattleCh_Hp;
    public Text BattleCh_Attack;
    public Text BattleCh_Den;
    public Text BattleCh_Aglie;
}
