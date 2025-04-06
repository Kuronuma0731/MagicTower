using System;
using UnityEngine;

public class CharactersEvent : MonoBehaviour
{
    public static event Action<UIManager,PeopleInfo> UpdateUiEvent;
    //更新UI 更新腳色本身
    public static void CallUpdateUiEvent(UIManager uIManager, PeopleInfo peopleInfo) 
    {
        UpdateUiEvent?.Invoke(uIManager, peopleInfo);
        //uIManager.UpdateStatusUI(peopleInfo);
    }

}
