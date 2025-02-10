using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : People
{

    [SerializeField] private Animator Door_Animator;
    //[SerializeField] private Grid Door_Grid;

    private void Start()
    {
        //Door_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Door_Animator != null)
        {
            if (Input.GetKeyDown(KeyCode.O)) 
            {
                Door_Animator.SetTrigger("Open");
            }
        }
    }
    //void ont
    public override void CloseObject(string ObjectName, Characters _Characters)
    {
        Debug.Log("ObjectName" + ObjectName + _Characters.YellowKey);
        switch (ObjectName)
        {
            case "YellowKey":
                if (_Characters.YellowKey != 0)
                {
                    _Characters.YellowKey -= 1;


                    Door_Animator.SetTrigger("Open");

                }
                break;
            case "BlueKey":
                if (_Characters.BlueKey != 0)
                {
                    _Characters.BlueKey -= 1;

                }
                break;
            case "RedKey":
                if (_Characters.RedKey != 0)
                {
                    _Characters.RedKey -= 1;

                 
                }
                break;

        }
        //Door_Animator.SetTrigger("Open");

        //Destroy(gameObject);
    }
    void OnAnimationComplete() 
    {
        Destroy(gameObject);
    }
}



