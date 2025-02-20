using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // UI 使用狀態更新
    [SerializeField] private UIInfo UIStatesText;
    [SerializeField] private GameObject itemImage;
    [SerializeField] private GameObject itemDescriptionText;
    [SerializeField] private GameObject uiBattleBackGrand;
    //
    [SerializeField] private Characters _Characters;
    //

    ////設定戰鬥UI顯示與隱藏狀態
    private bool isUiBallteState = false;

    private bool isUIVisible = false; // 控制 UI 顯示與隱藏的狀態

    public void Update()
    {
        CloseUI();
    }
    // 更新UI設定
    // 更新Canvas顯示
    public void UpdateStatusUI(PeopleInfo peopleInfo)
    {
        //FloorText.text = $"{peopleInfo.currentFloor} 樓";
        UIStatesText.LvText.text = $"等級:{peopleInfo.lvevl}";
        UIStatesText.HpText.text = $"生命: {peopleInfo.hp}";
        UIStatesText.AttackPowerText.text = $"攻擊力: {peopleInfo.attackPower}";
        UIStatesText.DefenseText.text = $"防禦力: {peopleInfo.defense}";
        UIStatesText.AgileText.text = $"敏捷: {peopleInfo.agile}";
        UIStatesText.Experience_ValueText.text = $"經驗: {peopleInfo.experience_Value}";
        UIStatesText.YellowKey_Text.text = $" {peopleInfo.yellowKey}";
        UIStatesText.BlueKeyText.text = $" {peopleInfo.blueKey}";
        UIStatesText.RedKeyText.text = $" {peopleInfo.redKey}";
        UIStatesText.MoneyText.text = $" {peopleInfo.magicMoney}";
        //UIStatesText.FloorText.text = $" {peopleInfo.currentFloor}";
    }

    public void UpdateMessage(string OtherText)
    {
        // 顯示UI 為True
        isUIVisible = true;
        itemImage.SetActive(isUIVisible);
        itemDescriptionText.SetActive(isUIVisible);
        UIStatesText.GetMessage.text = OtherText;
    }

    public static void UpdateBattleUI(Characters characters, Monster monster, UIManager uIManager)
    {

        // Update Text
        uIManager.UIStatesText.BattleCh_Hp.text = $"生命 :{characters.HP}";
        uIManager.UIStatesText.BattleCh_Attack.text = $"攻擊力 : {characters.AttackPower}";
        uIManager.UIStatesText.BattleCh_Den.text = $"防禦力 : {characters.Defense}";
        uIManager.UIStatesText.BattleCh_Aglie.text = $"敏捷 : {characters.Agile}";
        uIManager.UIStatesText.BattleM_Hp.text = $"生命 : {monster.HP}";
        uIManager.UIStatesText.BattleM_Attack.text = $"攻擊力 : {monster.AttackPower}";
        uIManager.UIStatesText.BattleM_Den.text = $"防禦力 : {monster.Defense}";
        uIManager.UIStatesText.BattleM_Aglie.text = $"敏捷 : {monster.Agile}";

    }

    public void ShowBattleUI()
    {
        isUiBallteState = !isUiBallteState;
        uiBattleBackGrand.SetActive(isUiBallteState);
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
                itemImage.SetActive(isUIVisible);
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
