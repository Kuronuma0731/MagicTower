using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Characters characters;

   // delegate    �^�I  callback 
   // Action    Action<int>   Func<int,int>
   //Action ���@�w�ݭn�ǭȶi�h ���@�w�S���^��
   // func<int,string> �� ����F��i�h int , return string (����F��X��)
    void Start()
    {
        characters.Init(uiManager.UpdateStatusUI);
    }



}
