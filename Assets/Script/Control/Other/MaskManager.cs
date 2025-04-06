using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MaskManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private BuyUIInfo uiBuySkill;
    [SerializeField] private Characters _Characters;
    [SerializeField] private GameObject uiShowSkill;

    void Start()
    {
        //預設關閉
        //uiShowSkill.SetActive(isUISkill);
        //UIStatesText.Skill_btn1.onClick.AddListener(() => SelectOption(1));
        //UIStatesText.Skill_btn2.onClick.AddListener(() => SelectOption(2));
        //UIStatesText.Skill_btn3.onClick.AddListener(() => SelectOption(3));
        //UIStatesText.Skill_btn4.onClick.AddListener(() => SelectOption(4));
    }
    public void ShowSkillUi(int ShowLv)
    {
        //uiShowSkill.SetActive(true);
        if (ShowLv == 1)
        {
            uiBuySkill.SkillText.text = $"你需要力量嗎?\r\n花錢就可以購買\r\n單價 20 金幣";
            uiBuySkill.btn1Text.text = $"血量增加500點";
            uiBuySkill.btn2Text.text = $"攻擊力增加3點";
            uiBuySkill.btn3Text.text = $"防禦力增加3點";
            uiBuySkill.btn4Text.text = $"離開";
            _Characters.SetCanMove(false);
        }
    }

    private void SelectOption(int SelectChange)
    {
        //Text 中的字串
        //string floorText = UIStatesText.FloorText.text;
        //
        //Match match = Regex.Match(floorText, @"\d+");
        //if (!match.Success)
        //{
        //    Debug.Log($"無法在字串中{floorText}中找到數字 ");
        //
        //}
        //floorText = match.Value;
        //int floor = int.Parse(floorText);
        //
        //if (floor != 0 && floor != 3 && floor != 7)
        //{
        //    //不執行
        //    return;
        //}
        //
        //FloorMask(SelectChange);

    }
    private void FloorMask(int SelectChange)
    {
       // string MoneyText = UIStatesText.SkillText.text;
       // Match match = Regex.Match(MoneyText, @"\d+");
       // if (!match.Success)
       // {
       //     Debug.Log($"無法在字串中{MoneyText}中找到數字 ");
       // }
       // int Money = int.Parse(match.Value);
       // if (Money > _Characters.MagicMoney)
       // {
       //     return;
       // }
       // switch (SelectChange)
       // {
       //     // 等級 生命 攻擊力 防禦
       //     case 1:
       //         //增加生命力
       //         _Characters.UpMaskHeroStates(0, 500, 0, 0, Money);
       //         Money += 1;
       //         UIStatesText.SkillText.text = $"你需要力量嗎?\r\n花錢就可以購買\r\n單價 {Money} 金幣";
       //         Debug.Log("已經離開 執行於 UImananger -> FloorMask ->  case ->  1");
       //         break;
       //     case 2:
       //         //增加攻擊力
       //         _Characters.UpMaskHeroStates(0, 0, 3, 0, Money);
       //         Money += 1;
       //         UIStatesText.SkillText.text = $"你需要力量嗎?\r\n花錢就可以購買\r\n單價 {Money} 金幣";
       //         Debug.Log("已經離開 執行於 UImananger -> FloorMask ->  case ->  2");
       //         break;
       //     case 3:
       //         //增加防禦力
       //         _Characters.UpMaskHeroStates(0, 0, 0, 3, Money);
       //         Money += 1;
       //         UIStatesText.SkillText.text = $"你需要力量嗎?\r\n花錢就可以購買\r\n單價 {Money} 金幣";
       //         Debug.Log("已經離開 執行於 UImananger -> FloorMask ->  case ->  3");
       //         break;
       //     case 4:
       //         //腳色移動
       //         _Characters.SetCanMove(true);
       //         //關閉視窗
       //         //uiShowSkill.SetActive(false);
       //         Debug.Log("已經離開 執行於 UImananger -> FloorMask ->  case ->  4");
       //         break;
       // }
    }
}
