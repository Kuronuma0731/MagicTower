using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text FloorText; // Text 上的數據顯示
    [SerializeField] private Text LvText;
    [SerializeField] private Text HpText; // Text 上的數據顯示
    [SerializeField] private Text AttackPowerText; // Text 上的數據顯示
    [SerializeField] private Text DefenseText; // Text 上的數據顯示
    [SerializeField] private Text AgileText; // Text 上的數據顯示
    [SerializeField] private Text Experience_ValueText; // Text 上的數據顯示
    [SerializeField] private Text YellowKey_Text; // Text 上的數據顯示
    [SerializeField] private Text BlueKeyText; // Text 上的數據顯示
    [SerializeField] private Text RedKeyText; // Text 上的數據顯示
    [SerializeField] private Text MoneyText; // Text 上的數據顯示

    // 更新UI設定
    // 更新Canvas顯示
    public void UpdateStatusUI(PeopleInfo peopleInfo)
    {
        //FloorText.text = $"{peopleInfo.currentFloor} 樓";
        LvText.text = $"等級:{peopleInfo.lvevl}";
        HpText.text = $"生命: {peopleInfo.hp}";
        AttackPowerText.text = $"攻擊力: {peopleInfo.attackPower}";
        DefenseText.text = $"防禦力: {peopleInfo.defense}";
        AgileText.text = $"敏捷: {peopleInfo.agile}";
        Experience_ValueText.text = $"經驗: {peopleInfo.experience_Value}";
        YellowKey_Text.text = $" {peopleInfo.yellowKey}";
        BlueKeyText.text = $" {peopleInfo.blueKey}";
        RedKeyText.text = $" {peopleInfo.redKey}";
        MoneyText.text = $" {peopleInfo.magicMoney}";
        FloorText.text = $" {peopleInfo.currentFloor}";
    }
}
