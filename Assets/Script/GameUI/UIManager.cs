using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // UI �ϥΪ��A��s
    [SerializeField] private UIInfo UIStatesText;
    [SerializeField] private GameObject itemImage;
    [SerializeField] private GameObject itemDescriptionText;
    [SerializeField] private GameObject uiBattleBackGrand;
    //
    [SerializeField] private Characters _Characters;
    //

    ////�]�w�԰�UI��ܻP���ê��A
    private bool isUiBallteState = false;

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
        UIStatesText.LvText.text = $"����:{peopleInfo.lvevl}";
        UIStatesText.HpText.text = $"�ͩR: {peopleInfo.hp}";
        UIStatesText.AttackPowerText.text = $"�����O: {peopleInfo.attackPower}";
        UIStatesText.DefenseText.text = $"���m�O: {peopleInfo.defense}";
        UIStatesText.AgileText.text = $"�ӱ�: {peopleInfo.agile}";
        UIStatesText.Experience_ValueText.text = $"�g��: {peopleInfo.experience_Value}";
        UIStatesText.YellowKey_Text.text = $" {peopleInfo.yellowKey}";
        UIStatesText.BlueKeyText.text = $" {peopleInfo.blueKey}";
        UIStatesText.RedKeyText.text = $" {peopleInfo.redKey}";
        UIStatesText.MoneyText.text = $" {peopleInfo.magicMoney}";
        //UIStatesText.FloorText.text = $" {peopleInfo.currentFloor}";
    }

    public void UpdateMessage(string OtherText)
    {
        // ���UI ��True
        isUIVisible = true;
        itemImage.SetActive(isUIVisible);
        itemDescriptionText.SetActive(isUIVisible);
        UIStatesText.GetMessage.text = OtherText;
    }

    public static void UpdateBattleUI(Characters characters, Monster monster, UIManager uIManager)
    {

        // Update Text
        uIManager.UIStatesText.BattleCh_Hp.text = $"�ͩR :{characters.HP}";
        uIManager.UIStatesText.BattleCh_Attack.text = $"�����O : {characters.AttackPower}";
        uIManager.UIStatesText.BattleCh_Den.text = $"���m�O : {characters.Defense}";
        uIManager.UIStatesText.BattleCh_Aglie.text = $"�ӱ� : {characters.Agile}";
        uIManager.UIStatesText.BattleM_Hp.text = $"�ͩR : {monster.HP}";
        uIManager.UIStatesText.BattleM_Attack.text = $"�����O : {monster.AttackPower}";
        uIManager.UIStatesText.BattleM_Den.text = $"���m�O : {monster.Defense}";
        uIManager.UIStatesText.BattleM_Aglie.text = $"�ӱ� : {monster.Agile}";

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
            // isUIVisible �w�}�ҩҥH����
            if (isUIVisible == true)
            {
                //������false �U���~�|���
                isUIVisible = !isUIVisible;
                itemImage.SetActive(isUIVisible);
                itemDescriptionText.SetActive(isUIVisible);
                _Characters.SetCanMove(true);
            }

            if (isUiBallteState == true)
            {
                // ������false �U���~���
                isUiBallteState = !isUiBallteState;
                uiBattleBackGrand.SetActive(isUiBallteState);
                _Characters.SetCanMove(true);
            }
        }
    }
}
