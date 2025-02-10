using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text FloorText; // Text �W���ƾ����
    [SerializeField] private Text LvText;
    [SerializeField] private Text HpText; // Text �W���ƾ����
    [SerializeField] private Text AttackPowerText; // Text �W���ƾ����
    [SerializeField] private Text DefenseText; // Text �W���ƾ����
    [SerializeField] private Text AgileText; // Text �W���ƾ����
    [SerializeField] private Text Experience_ValueText; // Text �W���ƾ����
    [SerializeField] private Text YellowKey_Text; // Text �W���ƾ����
    [SerializeField] private Text BlueKeyText; // Text �W���ƾ����
    [SerializeField] private Text RedKeyText; // Text �W���ƾ����
    [SerializeField] private Text MoneyText; // Text �W���ƾ����

    // ��sUI�]�w
    // ��sCanvas���
    public void UpdateStatusUI(PeopleInfo peopleInfo)
    {
        //FloorText.text = $"{peopleInfo.currentFloor} ��";
        LvText.text = $"����:{peopleInfo.lvevl}";
        HpText.text = $"�ͩR: {peopleInfo.hp}";
        AttackPowerText.text = $"�����O: {peopleInfo.attackPower}";
        DefenseText.text = $"���m�O: {peopleInfo.defense}";
        AgileText.text = $"�ӱ�: {peopleInfo.agile}";
        Experience_ValueText.text = $"�g��: {peopleInfo.experience_Value}";
        YellowKey_Text.text = $" {peopleInfo.yellowKey}";
        BlueKeyText.text = $" {peopleInfo.blueKey}";
        RedKeyText.text = $" {peopleInfo.redKey}";
        MoneyText.text = $" {peopleInfo.magicMoney}";
        FloorText.text = $" {peopleInfo.currentFloor}";
    }
}
