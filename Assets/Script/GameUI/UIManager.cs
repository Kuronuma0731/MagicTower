using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // UI 使用狀態更新
    [SerializeField] private UIInfo UIStatesText;
    [SerializeField] private GameObject GetImage;
    [SerializeField] private GameObject itemDescriptionText;
    [SerializeField] private GameObject uiBattleBackGrand;
    
    [SerializeField] private Characters _Characters;
    //

    ////設定戰鬥UI顯示與隱藏狀態
    private bool isUiBallteState = false;

    private bool isUIVisible = false; // 控制 UI 顯示與隱藏的狀態
    //private bool isUISkill = false; // 控制 UI 顯示與隱藏的狀態


    private void OnEnable()
    {
        EventHander.UpdateArticleUIEvent += UpdateArticleUI;
        EventHander.UpdateUiEvent += UpdateStatusUI;
        EventHander.UpdateMessageEvent += UpdateMessage;
        EventHander.UpdateBattleEvent += ShowBattleUI;
        EventHander.UpdateBattleUIEvent += UpdateBattleUI;
    }
    private void OnDisable()
    {
        EventHander.UpdateArticleUIEvent -= UpdateArticleUI;
        EventHander.UpdateUiEvent -= UpdateStatusUI;
        EventHander.UpdateMessageEvent -= UpdateMessage;
        EventHander.UpdateBattleEvent -= ShowBattleUI;
        EventHander.UpdateBattleUIEvent -= UpdateBattleUI;
    }
   
    public void Update()
    {
        CloseUI();
    }
    public void UpdateStatusUI(PeopleInfo peopleInfo)
    {
        UIStatesText.LvText.text = $"等級:{peopleInfo.lvevl}";
        UIStatesText.HpText.text = $"生命: {peopleInfo.hp}";
        UIStatesText.AttackPowerText.text = $"攻擊力: {peopleInfo.attackPower}";
        UIStatesText.DefenseText.text = $"防禦力: {peopleInfo.defense}";
        UIStatesText.AgileText.text = $"敏捷: {peopleInfo.agile}";
        UIStatesText.Experience_ValueText.text = $"經驗: {peopleInfo.experience_Value}";
    }
    //更新鑰匙、錢資訊
    public void UpdateArticleUI(Article article, ArticleDetail articleDetail)
    {
        //更新Key money UI
        switch (article)
        {
            case Article.YellowKey:
                UIStatesText.YellowKey_Text.text = $"" + articleDetail.Count + "";
                break;
            case Article.BlueKey:
                UIStatesText.BlueKeyText.text = $"" + articleDetail.Count + "";
                break;
            case Article.RedKey:
                UIStatesText.RedKeyText.text = $"" + articleDetail.Count + "";
                break;
            case Article.MegicMoney:
                UIStatesText.MoneyText.text = $"" + articleDetail.Count + "";
                break;
        }
    }
    
    // 更新 獲得UI訊息
    public void UpdateMessage(string message)
    {
        // 顯示UI 為True
        isUIVisible = true;
        GetImage.SetActive(isUIVisible);
        itemDescriptionText.SetActive(isUIVisible);
        UIStatesText.GetMessage.text = message;
        //關閉腳色移動
        _Characters.SetCanMove(!isUIVisible);
    }
    //開啟 Battle Ui
    public void ShowBattleUI()
    {
        isUiBallteState = !isUiBallteState;
        _Characters.SetCanMove(isUiBallteState);
        uiBattleBackGrand.SetActive(isUiBallteState);
    }
    //更新BattleUI
    public void UpdateBattleUI(PeopleInfo Ch, Monster monster)
    {

        // Update Text
        UIStatesText.BattleCh_Name.text = $"英      雄";
        UIStatesText.BattleCh_Hp.text = $"生命 :{Ch.hp}";
        UIStatesText.BattleCh_Attack.text = $"攻擊力 : {Ch.attackPower}";
        UIStatesText.BattleCh_Den.text = $"防禦力 : {Ch.defense}";
        UIStatesText.BattleCh_Aglie.text = $"敏捷 : {Ch.agile}";


        //UIStatesText.BattleM_Image.sprite = monster.m
        UIStatesText.BattleM_Name.text = $" {monster.name} ";
        UIStatesText.BattleM_Hp.text = $"生命 : {monster.HP}";
        UIStatesText.BattleM_Attack.text = $"攻擊力 : {monster.AttackPower}";
        UIStatesText.BattleM_Den.text = $"防禦力 : {monster.Defense}";
        UIStatesText.BattleM_Aglie.text = $"敏捷 : {monster.Agile}";
    }


    public void ShowFloor(int Floor)
    {
        UIStatesText.FloorText.text = $"{Floor}樓";
    }


    void CloseUI()
    {
        if (Input.GetKeyDown(KeyCode.Return))//Input Enter
        {
            //Debug.Log(isUIVisible);
            // isUIVisible 已開啟所以關閉
            if (isUIVisible == true)
            {
                //切換成false 下面才會更動
                isUIVisible = !isUIVisible;
                GetImage.SetActive(isUIVisible);
                itemDescriptionText.SetActive(isUIVisible);
                _Characters.SetCanMove(true);
            }

            if (isUiBallteState == true)
            {
                // 切換成false 下面才更動
                isUiBallteState = !isUiBallteState;
                uiBattleBackGrand.SetActive(isUiBallteState);
                _Characters.SetCanMove(true);
                
            }
        }
    }

   
}
