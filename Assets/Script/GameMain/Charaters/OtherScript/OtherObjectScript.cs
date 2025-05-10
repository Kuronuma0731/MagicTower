using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using UnityEngine;

public class OtherObjectScript
{

    // 判斷物品時 給予
    public static string GetOther(GameObject Other, GameObject _Character)
    {
        if (Other != null && _Character != null)
        {
            Characters characters = _Character.GetComponent<Characters>();
            switch (Other.name)
            {
                case "YellowKey":
                    characters.YellowKey += 1;
                    return $"獲得一把黃鑰匙";
                case "BlueKey":
                    characters.BlueKey += 1;
                    return $"獲得一把藍鑰匙";

                case "RedKey":
                    return $"獲得一把紅鑰匙";
                case "MagicMoney":
                    characters.MagicMoney += 0;
                    return $"獲得一把金幣200元";
                case "HP_Potion":
                    characters.HP += 150;
                    return $"獲得紅藥水增加 150 血量";
                case "Defence_Potion":
                    characters.HP += 400;
                    return $"獲得藍藥水增加 400 血量";
                case "Agile_Potion":
                    //characters. = 150;
                    return $"獲得敏捷藥水增加  敏捷";
                case "Attack_MagicGems":
                    characters.AttackPower += 2;
                    return $"獲得攻擊寶石 2 點攻擊力";
                case "Defens_MagicGems":
                    characters.Defense += 2;
                    return $"獲得防禦寶石 2 點防禦力";
                case "YellowDoor":

                    characters.YellowKey -= 1;
                    return "";

                case "BlueDoor":
                    characters.BlueKey -= 1;
                    //characters. = 150;
                    return "";
                case "RedDoor":
                    characters.RedKey -= 1;
                    //characters. = 150;
                    return "";
                default:
                    return "";
            }
        }
        return null;
    }

}
