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
    [SerializeField] private Text GetMessage; // Text �W���ƾ����

    [SerializeField] private GameObject itemImage;
    [SerializeField] private GameObject itemDescriptionText;

    private bool isUIVisible = false; // ���� UI ��ܻP���ê����A


    public void Update()
    {
        CloseUI();
    }
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

    public void UpdateMessage(string OtherText)
    {
        // ���UI ��True
        isUIVisible = true;
        itemImage.SetActive(isUIVisible);
        itemDescriptionText.SetActive(isUIVisible);
        GetMessage.text = OtherText;
    }

    void CloseUI()
    {
        if (Input.GetKeyDown(KeyCode.Return))//Input Enter
        {
            //Debug.Log(isUIVisible);
            // isUIVisible �w�}�ҩҥH����
            if (isUIVisible == true)
            {
                //������false �U���~�|���
                isUIVisible = !isUIVisible;
                itemImage.SetActive(isUIVisible);
                itemDescriptionText.SetActive(isUIVisible);
                
               
            }
        }
    }
}
