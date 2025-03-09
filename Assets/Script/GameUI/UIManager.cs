using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // UI 使用狀態更新
    [SerializeField] private UIInfo UIStatesText;
    [SerializeField] private GameObject itemImage;
    [SerializeField] private GameObject itemDescriptionText;
    [SerializeField] private GameObject uiBattleBackGrand;
    [SerializeField] private GameObject uiShowEnterSure;//
    [SerializeField] private GameObject uiShowBuyGameObject;//
    [SerializeField] private Characters _Characters;
    
    ////設定戰鬥UI顯示與隱藏狀態
    private bool isUiBallteState = false;

    private bool isUIVisible = false; // 控制 UI 顯示與隱藏的狀態
    private bool isBuyUIVisible = false; // 控制 UI "買東西" 顯示與隱藏的狀態

    public void Start()
    {
        uiShowBuyGameObject.SetActive(isBuyUIVisible);
        UIStatesText.BuyButton1.onClick.AddListener(() => DetectCilck(1));
        UIStatesText.BuyButton2.onClick.AddListener(() => DetectCilck(2));
        UIStatesText.BuyButton3.onClick.AddListener(() => DetectCilck(3));
        UIStatesText.BuyButton4.onClick.AddListener(() => DetectCilck(4));
    }

    public void Update()
    {
        CloseUI();
    }
    // 更新UI設定
    // 更新Canvas顯示
    public void UpdateStatusUI(PeopleInfo peopleInfo)
    {
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
    public void DetectCilck(int Key)
    {
        //Text 中的字串
        string floorText = UIStatesText.FloorText.text;

        Match mathf = Regex.Match(floorText, @"\d+");

        if (!mathf.Success)
        {
            Debug.Log($"無法在字串中{floorText}中找到數字 ");

        }
        floorText = mathf.Value;
        int floor = int.Parse(floorText);

        if (floor != 0 && floor != 3 && floor != 7)
        {
            //不執行
            return;
        }

        FloorMask(Key);
    }

    private void FloorMask(int key)
    {
        string MoneyText = UIStatesText.BuyText.text;
        Match match = Regex.Match(MoneyText, @"\d+");
        if (!match.Success)
        {
            Debug.Log($"無法在字串中{MoneyText}中找到數字 ");
        }
        int Money = int.Parse(match.Value);
        if (Money > _Characters.MagicMoney)
        {

            _Characters.SetCanMove(true);
            //關閉視窗
            uiShowBuyGameObject.SetActive(false);
            Debug.Log("已經離開 執行於 UImananger -> FloorMask ->  case ->  4");
            return;
        }
        switch (key)
        {
            // 等級 生命 攻擊力 防禦
            case 1:
                //增加生命力
                _Characters.UpMaskHeroStates(0, 500, 0, 0, Money);
                Money += 1;
                UIStatesText.BuyText.text = $"你需要力量嗎?\r\n花錢就可以購買\r\n單價 {Money} 金幣";
                Debug.Log("已經離開 執行於 UImananger -> FloorMask ->  case ->  1");
                break;
            case 2:
                //增加攻擊力
                _Characters.UpMaskHeroStates(0, 0, 3, 0, Money);
                Money += 1;
                UIStatesText.BuyText.text = $"你需要力量嗎?\r\n花錢就可以購買\r\n單價 {Money} 金幣";
                Debug.Log("已經離開 執行於 UImananger -> FloorMask ->  case ->  2");
                break;
            case 3:
                //增加防禦力
                _Characters.UpMaskHeroStates(0, 0, 0, 3, Money);
                Money += 1;
                UIStatesText.BuyText.text = $"你需要力量嗎?\r\n花錢就可以購買\r\n單價 {Money} 金幣";
                Debug.Log("已經離開 執行於 UImananger -> FloorMask ->  case ->  3");
                break;
            case 4:
                //腳色移動
                _Characters.SetCanMove(true);
                //關閉視窗
                uiShowBuyGameObject.SetActive(false);
                Debug.Log("已經離開 執行於 UImananger -> FloorMask ->  case ->  4");
                break;
        }
    }

    public void UpdateMessage(string OtherText)
    {
        // 顯示UI 為True
        isUIVisible = true;
        // 照片顯示
        itemImage.SetActive(isUIVisible);
        //
        itemDescriptionText.SetActive(isUIVisible);
        UIStatesText.GetMessage.text = OtherText;

        uiShowEnterSure.SetActive(isUIVisible);
    }



    public void ShowBattleUI()
    {
        isUiBallteState = !isUiBallteState;
        uiBattleBackGrand.SetActive(isUiBallteState);
        uiShowEnterSure.SetActive(isUiBallteState);
    }
    public void ShowFloor(int Floor)
    {
        UIStatesText.FloorText.text = $"{Floor} 樓";
    }

    public void ShowSkillUi(int ShowLv)
    {
        uiShowBuyGameObject.SetActive(true);
        //初階藍色
        if (ShowLv == 1)
        {

            UIStatesText.BuyText.text = $"你需要力量嗎?\r\n花錢就可以購買\r\n單價 20 金幣";
            UIStatesText.BuyBtnText1.text = $"血量增加500點";
            UIStatesText.BuyBtnText2.text = $"攻擊力增加3點";
            UIStatesText.BuyBtnText3.text = $"防禦力增加3點";
            UIStatesText.BuyBtnText4.text = $"離開";
            
        }
        //初階粉色
        else if (ShowLv == 2)
        {

            UIStatesText.BuyText.text = $"你需要力量嗎?\r\n花費經驗就可以購買\r\n";
            UIStatesText.BuyBtnText1.text = $"增加等級 1 級 花費70點經驗";
            UIStatesText.BuyBtnText2.text = $"攻擊力增加5點 花費20點經驗";
            UIStatesText.BuyBtnText3.text = $"防禦力增加5點 花費20點經驗";
            UIStatesText.BuyBtnText4.text = $"離開";
            
        }
        //高階
        else if (ShowLv == 3)
        {

            UIStatesText.BuyText.text = $"你需要力量嗎?\r\n花錢就可以購買\r\n單價 20 金幣";
            UIStatesText.BuyBtnText1.text = $"血量增加800點";
            UIStatesText.BuyBtnText2.text = $"攻擊力增加6點";
            UIStatesText.BuyBtnText3.text = $"防禦力增加6點";
            UIStatesText.BuyBtnText4.text = $"離開";
            
        }
        //高階
        else if (ShowLv == 4)
        {

            UIStatesText.BuyText.text = $"你需要力量嗎?\r\n花費經驗就可以購買\r\n";
            UIStatesText.BuyBtnText1.text = $"增加等級 3 級 花費190點經驗";
            UIStatesText.BuyBtnText2.text = $"攻擊力增加15點 花費70點經驗";
            UIStatesText.BuyBtnText3.text = $"防禦力增加15點 花費70點經驗";
            UIStatesText.BuyBtnText4.text = $"離開";
            
        }
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
                uiShowEnterSure.SetActive(isUIVisible);
                _Characters.SetCanMove(true);
            }
            // 關閉戰鬥畫面
            if (isUiBallteState == true)
            {
                // 切換成false 下面才更動
                isUiBallteState = !isUiBallteState;
                uiBattleBackGrand.SetActive(isUiBallteState);
                uiShowEnterSure.SetActive(isUIVisible);
                _Characters.SetCanMove(true);
            }
        }
    }
}
