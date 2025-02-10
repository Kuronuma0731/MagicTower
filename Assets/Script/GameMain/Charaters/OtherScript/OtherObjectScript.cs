using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using UnityEngine;

public class OtherObjectScript
{

    // 判斷物品時 給予
    public static void GetOther(GameObject Other, GameObject _Character)
    {
        if (Other != null && _Character != null)
        {
            Characters characters = _Character.GetComponent<Characters>();
            switch (Other.name)
            {
                case "YellowKey":
                    characters.YellowKey += 1;
                    break;
                case "BlueKey":
                    characters.BlueKey += 1;
                    break;
                case "RedKey":
                    characters.RedKey += 1;
                    break;
                case "MagicMoney":
                    characters.MagicMoney += 0;
                    break;
                case "HP_Potion":
                    characters.HP += 150;
                    break;
                case "Defence_Potion":
                    characters.HP += 400;
                    break;
                case "Agile_Potion":
                    //characters. = 150;
                    break;
                case "Attack_MagicGems":
                    characters.AttackPower += 2;
                    //characters. = 150;

                    break;
                case "Defens_MagicGems":
                    characters.Defense += 2;
                    //characters. = 150;
                    break;
                case "YellowDoor":
                    
                    characters.YellowKey -= 1;
                    //characters. = 150;
                    break;
                case "BlueDoor":
                    characters.BlueKey -= 1;
                    //characters. = 150;
                    break;
                case "RedDoor":
                    characters.RedKey -= 1;
                    //characters. = 150;
                    break;
                default:
                    break;

            }
        }
    }

}
