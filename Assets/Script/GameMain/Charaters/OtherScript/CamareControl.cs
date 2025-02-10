using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CamareControl : MonoBehaviour
{
    // �ˬd�O�_�䴩 1920x1080
    bool support1080p = false;
    bool support720p = false;

    void Start()
    {
        // �����o�t�Τ䴩���ѪR�ײM��
        Resolution[] resolutions = Screen.resolutions;

        foreach (Resolution r in resolutions)
        {
            if (r.width == 1920 && r.height == 1200) support1080p = true;
            if (r.width == 1280 && r.height == 720) support720p = true;
        }


        // ���]�Ʊ檱�a�u��ϥ� 1920x1080 > �_�h�� 1280x720 > �_�h�η�e�ѪR��
        if (support1080p)
        {
            Screen.SetResolution(1920, 1200, false);
            //Screen.SetResolution(1280, 960, false);
        }
        else if (support720p)
        {
            Screen.SetResolution(1280, 960, false);
        }
        else
        {
            // �p�G�����䴩�A�N�O���ϥΪ̷�e�ѪR�שΰ���L�Ʈ�
            Debug.Log("�ϥΪ̤��䴩 1920x1080 / 1280x720�A������e�ѪR��");
        }
    }



}
