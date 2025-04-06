using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CamareControl : MonoBehaviour
{
    // 檢查是否支援 1920x1080
    bool support1080p = false;
    bool support720p = false;

    void Start()
    {
        // 先取得系統支援的解析度清單
        Resolution[] resolutions = Screen.resolutions;

        foreach (Resolution r in resolutions)
        {
            if (r.width == 1920 && r.height == 1200) support1080p = true;
            if (r.width == 1280 && r.height == 720) support720p = true;
        }


        // 假設希望玩家只能使用 1920x1080 > 否則用 1280x720 > 否則用當前解析度
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
            // 如果都不支援，就保持使用者當前解析度或做其他備案
            Debug.Log("使用者不支援 1920x1080 / 1280x720，維持當前解析度");
        }
    }



}
