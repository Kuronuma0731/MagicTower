
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UIInfo 
{
    public Text FloorText; // 樓層上的數據顯示
    public Text LvText;    // 等級的數據顯示
    public Text HpText; // 腳色血量 上的數據顯示
    public Text AttackPowerText; // 腳色攻擊力 上的數據顯示
    public Text DefenseText; // 腳色防禦力 上的數據顯示
    public Text AgileText; // 腳色敏捷 上的數據顯示
    public Text Experience_ValueText; // 腳色經驗 上的數據顯示
    public Text YellowKey_Text; // 黃鑰匙數量 上的數據顯示
    public Text BlueKeyText; // 藍鑰匙數量 上的數據顯示
    public Text RedKeyText; // 紅鑰匙數量 上的數據顯示
    public Text MoneyText; // 錢 上的數據顯示
    public Text GetMessage; // 顯示獲得訊息 上的數據顯示
    public Text ShowEnterSure;//顯示 按下Enter通知

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
    //買東西顯示
    public Image BuyImage;
    public Text BuyText;
    public Button BuyButton1;
    public Button BuyButton2;
    public Button BuyButton3;
    public Button BuyButton4;
    public Text BuyBtnText1;
    public Text BuyBtnText2;
    public Text BuyBtnText3;
    public Text BuyBtnText4;
    //
    
}
