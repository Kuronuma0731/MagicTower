using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using UnityEngine;

public class OtherObjectScript
{

    // �P�_���~�� ����
    public static string GetOther(GameObject Other, GameObject _Character)
    {
        if (Other != null && _Character != null)
        {
            Characters characters = _Character.GetComponent<Characters>();
            switch (Other.name)
            {
                case "YellowKey":
                    characters.YellowKey += 1;
                    return $"��o�@����_��";
                case "BlueKey":
                    characters.BlueKey += 1;
                    return $"��o�@�����_��";

                case "RedKey":
                    return $"��o�@����_��";
                case "MagicMoney":
                    characters.MagicMoney += 0;
                    return $"��o�@�����200��";
                case "HP_Potion":
                    characters.HP += 150;
                    return $"��o���Ĥ��W�[ 150 ��q";
                case "Defence_Potion":
                    characters.HP += 400;
                    return $"��o���Ĥ��W�[ 400 ��q";
                case "Agile_Potion":
                    //characters. = 150;
                    return $"��o�ӱ��Ĥ��W�[  �ӱ�";
                case "Attack_MagicGems":
                    characters.AttackPower += 2;
                    return $"��o�����_�� 2 �I�����O";
                case "Defens_MagicGems":
                    characters.Defense += 2;
                    return $"��o���m�_�� 2 �I���m�O";
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
